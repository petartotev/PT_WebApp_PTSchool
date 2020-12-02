using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Contracts
{
    public interface IPageable
    {
        int GetPageSize();

        int GetTotalCount();
    }
}
