using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.DataAccess.Interfaces
{
    public interface ILoginContextDb
    {
        int GetByAdEmail_id(string AdEmail_id, string AdPassword);

    }
}
