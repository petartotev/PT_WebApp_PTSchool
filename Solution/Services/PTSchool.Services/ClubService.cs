using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Services.Models.ApiMLNet;
using PTSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class ClubService : IClubService
    {
        private const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public ClubService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClubLightServiceModel>> GetAllClubsLightByPageAsync(int page = 1)
        {
            var clubs = await this.db.Clubs
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Students)
                //.Include(x => x.Teachers)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<ClubLightServiceModel>>(clubs);
        }

        public async Task<ClubFullServiceModel> GetClubFullByIdAsync(Guid id)
        {
            ValidateClubId(id);
            ValidateIfClubIsDeleted(id);

            var club = await this.db.Clubs
                .Include(x => x.Students)
                .ThenInclude(clubStudent => clubStudent.Student)
                .Include(x => x.Teachers)
                .ThenInclude(clubTeacher => clubTeacher.Teacher)
                .FirstOrDefaultAsync(x => x.Id == id);

            var output = this.mapper.Map<ClubFullServiceModel>(club);
            output.ClubsRecommendedByMLNet = GetRecommendedClubsByMLNet(id);
            return output;
        }

        public async Task<bool> DeleteClubByIdAsync(Guid id)
        {
            ValidateClubId(id);
            ValidateIfClubIsDeleted(id);

            var clubToDelete = await this.db.Clubs.FindAsync(id);
            clubToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<ClubFullServiceModel> UpdateClubAsync(ClubFullServiceModel club)
        {
            ValidateClubId(club.Id);
            ValidateIfClubIsDeleted(club.Id);
            ValidateIfInputIsNotNullOrEmpty(club.Name);
            ValidateIfInputIsNotNullOrEmpty(club.Description);

            var clubInDb = await db.Clubs.FindAsync(club.Id);

            clubInDb.Name = club.Name;
            clubInDb.Description = club.Description;
            clubInDb.Image = club.Image;
            await db.SaveChangesAsync();

            var clubInDbUpdated = await db.Clubs
                .Include(x => x.Students)
                .ThenInclude(clubStudent => clubStudent.Student)
                .Include(x => x.Teachers)
                .ThenInclude(clubTeacher => clubTeacher.Teacher)
                .FirstOrDefaultAsync(x => x.Id == club.Id);

            return this.mapper.Map<ClubFullServiceModel>(clubInDbUpdated);
        }

        public async Task<ClubFullServiceModel> CreateClubAsync(ClubFullServiceModel club)
        {
            ValidateIfObjectIsNotNull(club);
            ValidateIfInputIsNotNullOrEmpty(club.Name);
            ValidateIfNameAlreadyExists(club.Name);

            Club clubToCreate = this.mapper.Map<Club>(club);

            await SetDefaultImagePathIfImagePathIsNull(clubToCreate);
            await SetDefaultDescriptionIfDescriptionIsNull(clubToCreate);

            await db.Clubs.AddAsync(clubToCreate);
            await db.SaveChangesAsync();

            Club clubCreated = db.Clubs.FirstOrDefault(x => x.Name == club.Name && x.Description == clubToCreate.Description);
            return this.mapper.Map<ClubFullServiceModel>(clubCreated);
        }

        public Dictionary<ClubLightServiceModel, float> GetRecommendedClubsByMLNet(Guid id)
        {
            //MLModelBuilder.CreateModel();

            // Create single instance of sample data from first line of dataset for model input
            List<ModelInput> modelInputs = new List<ModelInput>();

            var student = db.Students.First(x => x.Id == db.ClubsStudents.First(y => y.ClubId == id).StudentId);                       
                        
            foreach (var club in this.db.Clubs.Where(x => x.Id != id))
            {
                modelInputs.Add(new ModelInput
                {
                    StudentId = student.Id.ToString().ToUpper(),
                    ClubId = club.Id.ToString().ToUpper(),
                });
            }

            // Make a single prediction on the sample data and print results
            //var predictionResult = ConsumeModel.Predict(sampleData);

            Dictionary<ClubLightServiceModel, float> dictionary = new Dictionary<ClubLightServiceModel, float>();

            foreach (var input in modelInputs)
            {
                var predictionResult = ConsumeModel.Predict(input);
                var predictionResultScore = predictionResult.Score;

                Club club = this.db.Clubs.First(x => x.Id == Guid.Parse(input.ClubId));
                ClubLightServiceModel model = this.mapper.Map<ClubLightServiceModel>(club);

                dictionary.Add(model, predictionResultScore);
            }

            //Console.WriteLine("Using model to make single prediction -- Comparing actual Score with predicted Score from sample data...\n\n");
            //Console.WriteLine($"StudentId: {sampleData.StudentId}");
            //Console.WriteLine($"ClubId: {sampleData.ClubId}");
            //Console.WriteLine($"\n\nPredicted Score: {predictionResult.Score}\n\n");
            //Console.WriteLine("=============== End of process, hit any key to finish ===============");
            //Console.ReadKey();

            return dictionary
                .Where(x => x.Value >= 0.1f)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Clubs.Count();
        }

        public int GetTotalCountStudentsInClubs()
        {
            int test = this.db.Clubs.Select(x => x.Students.Count()).ToList().Sum();

            return test;
        }

        public int GetTotalCountTeachersInClubs()
        {
            int test = this.db.Clubs.Select(x => x.Teachers.Count()).ToList().Sum();

            return test;
        }


        private async Task<string> SetDefaultImagePathIfImagePathIsNull(Club club)
        {
            if (club.Image is null)
            {
                string imagePathDefault = $"/images/clubs/default.jpg";
                club.Image = imagePathDefault;
                await db.SaveChangesAsync();
            }

            return club.Image;
        }

        private async Task<string> SetDefaultDescriptionIfDescriptionIsNull(Club club)
        {
            if (string.IsNullOrEmpty(club.Description))
            {
                string subjectDefault = $"{club.Name} is a school club which is a symbiosis between Teachers and Students and an additional attempt for those to contribute.";
                club.Description = subjectDefault;
                await db.SaveChangesAsync();
            }

            return club.Description;
        }

        private void ValidateClubId(Guid id)
        {
            if (!db.Clubs.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Club with such id.");
            }
        }

        private void ValidateIfClubIsUnlisted(Guid id)
        {
            if (db.Clubs.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Club is unlisted.");
            }
        }

        private void ValidateIfClubIsDeleted(Guid id)
        {
            if (db.Clubs.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Club is deleted.");
            }
        }

        private void ValidateIfInputIsNotNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Name / Description of a Club cannot be null or empty.");
            }
        }

        private void ValidateIfNameAlreadyExists(string name)
        {
            if (this.db.Clubs.Any(x => x.Name == name))
            {
                throw new ArgumentException("There is already an entity with this name.");
            }
        }

        private void ValidateIfObjectIsNotNull(ClubFullServiceModel club)
        {
            if (club is null)
            {
                throw new ArgumentNullException("The Club cannot be null and needs to have value.");
            }
        }
    }
}
