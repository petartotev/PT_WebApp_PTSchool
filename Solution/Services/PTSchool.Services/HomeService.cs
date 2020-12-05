using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PTSchool.Data;
using PTSchool.Data.Models.ApiNews;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.ApiNews;
using PTSchool.Services.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using static PTSchool.Services.ApiKeys.StaticApiKeyStorage;

namespace PTSchool.Services
{
    public class HomeService : IHomeService
    {
        private readonly Random random = new Random();

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public HomeService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public bool SendEmail(EmailSendServiceModel model)
        {
            #region CommentsOnSmtpClient
            // MailAddress fromAddress/string fromPassword - email/password in Gmail to get access to the SmtpClient Host ("smpt.gmail.com").
            // That would throw a SmtpException: 5.7.0 Authentication Required.
            // You would also receive an email in Gmail saying "Critical security alert".
            // What you need to do is to press "Check Activity" => Less secure app blocked => Learn more => Less secure app access => Allow less secure apps: ON.
            // Now it should work.
            #endregion

            MailAddress fromAddress = new MailAddress("gmail@gmail.gmail");
            string fromPassword = "gmailpassword";
            var toAddress = new MailAddress("domain@domain.domain");

            string subject = model.Subject;
            string body = model.Message;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                    return true;
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task UpdateNewsLocalDb()
        {
            await RemoveCurrentArticlesAndSources();

            var root = GetNewsRoot();
            await AddArticlesAndSourcesToDb(root);
        }

        public async Task<HomeServiceModel> GetHomePageInformationPackage()
        {
            HomeServiceModel model = new HomeServiceModel
            {
                News = await Get3RandomNews(),
                CountClasses = this.db.Classes.Count(),
                CountClubs = this.db.Clubs.Count(),
                CountParents = this.db.Parents.Count(),
                CountTeachers = this.db.Teachers.Count(),
                CountStudents = this.db.Students.Count(),
                CountSubjects = this.db.Subjects.Count()
            };

            return model;
        }


        private async Task<string> GatherInfo(string url)
        {
            string result = string.Empty;

            var client = new HttpClient();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsStringAsync();
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                }
            }

            return result;
        }

        private RootServiceModel GetNewsRoot()
        {
            string url = $"http://newsapi.org/v2/everything?q=education&language=en&sources=bbc-news&sortBy=publishedAt&apiKey={NewsApi.ApiKey}";

            var responseString = GatherInfo(url).GetAwaiter().GetResult();

            if (!string.IsNullOrEmpty(responseString))
            {
                RootServiceModel rootNewsApi = JsonConvert.DeserializeObject<RootServiceModel>(responseString);
                return rootNewsApi;
            }

            return null;
        }

        private async Task<IEnumerable<ArticleServiceModel>> Get3RandomNews()
        {
            var countNews = db.Articles.Count();
            var randomStartPoint = random.Next(0, countNews - 4);

            var collectionArticles = await this.db.Articles
                .Skip(randomStartPoint)
                .Take(3)
                .Include(x => x.Source)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<ArticleServiceModel>>(collectionArticles);
        }

        private async Task RemoveCurrentArticlesAndSources()
        {
            var countCurrentArticles = this.db.Articles.Count();

            for (int i = 0; i < countCurrentArticles; i++)
            {
                this.db.Articles.Remove(this.db.Articles.First());
                await this.db.SaveChangesAsync();
            }

            var countCurrentSources = this.db.Sources.Count();

            for (int i = 0; i < countCurrentSources; i++)
            {
                this.db.Sources.Remove(this.db.Sources.First());
                await this.db.SaveChangesAsync();
            }
        }

        private async Task AddArticlesAndSourcesToDb(RootServiceModel root)
        {
            if (root != null)
            {
                foreach (var article in root.Articles)
                {
                    if (!this.db.Sources.Any(x => x.Id == article.Source.Id))
                    {
                        db.Sources.Add(new Source
                        {
                            Id = article.Source.Id,
                            Name = article.Source.Name,
                        });
                        await db.SaveChangesAsync();
                    }

                    db.Articles.Add(new Article
                    {
                        Author = article.Author,
                        Title = article.Title,
                        Description = article.Description,
                        Url = article.Url,
                        UrlToImage = article.UrlToImage,
                        PublishedAt = article.PublishedAt,
                        Content = article.Content,
                        SourceId = article.Source.Id,
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
