using PTSchool.Services.Models.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Contracts
{
    public interface IHomeService
    {
        bool SendEmail(EmailSendServiceModel model);
    }
}
