using EStoreProject.BusinessLogic.Interfaces;
using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EStoreProject.BusinessLogic
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IAdminRepository _contextDb;

        public AdminRepository(IAdminRepository contextDb)
        {
            _contextDb = contextDb;
        }
   
        public void AddAdmin(Admin objAdmin)
        {
            _contextDb.AddAdmin(objAdmin);
        }

        /*
        public void DeleteAdmin(int admin)
        {
            _contextDb.DeleteAdmin(admin);
        }
        */
        public List<Admin> GetAllAdmin()
        {
            return _contextDb.GetAllAdmin().ToList();
        }

        

        /*
                public int GetByAdEmail_id(string AdEmail_id, string AdPassword)
                {
                    var email_id = _contextDb.GetByAdEmail_id(AdEmail_id,  AdPassword);
                    return email_id;
                }
             */

    }
}
