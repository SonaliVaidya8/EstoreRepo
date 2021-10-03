using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.BusinessLogic
{
    public interface IAdminRepository
    {
        //Repository
      
        void AddAdmin(Admin objAdmin);
        Admin GetByAdEmail_id(string AdEmail_id);

    }
}
