using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.BusinessLogic
{
     public class AdminRepository : IAdminRepository
    {
        private readonly IAdminContextDb _contextDb;

        public AdminRepository(IAdminContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public void AddAdmin(Admin objAdmin)
        {
            _contextDb.AddAdmin(objAdmin);
        }

        public Admin GetByAdEmail_id(string AdEmail_id)
        {
            var email_id = _contextDb.GetByAdEmail_id(AdEmail_id);
            return email_id;
        
   
        }
    }
}
