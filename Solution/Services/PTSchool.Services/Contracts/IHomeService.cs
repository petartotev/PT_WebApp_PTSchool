using PTSchool.Services.Models.Home;
using System.Threading.Tasks;

namespace PTSchool.Services.Contracts
{
    public interface IHomeService
    {
        bool SendEmail(EmailSendServiceModel model);

        Task UpdateNewsLocalDb();

        Task<HomeServiceModel> GetHomePageInformationPackage();
    }
}
