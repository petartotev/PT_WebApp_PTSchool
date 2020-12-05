using PTSchool.Services.Models.ApiNews;
using PTSchool.Services.Models.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSchool.Services.Contracts
{
    public interface IHomeService
    {
        bool SendEmail(EmailSendServiceModel model);

        Task UpdateNewsLocalDb();

        Task<IEnumerable<ArticleServiceModel>> Get3RandomNews();
    }
}
