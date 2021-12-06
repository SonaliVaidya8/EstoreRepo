using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.BusinessLogic.Interfaces
{
    public interface ILoginRepository
    {
        int GetByAdEmail_id(string AdEmail_id, string AdPassword);

    }
}
