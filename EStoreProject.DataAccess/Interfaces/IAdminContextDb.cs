using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.DataAccess.Interfaces
{
    public interface IAdminContextDb
    {
        void AddAdmin(Admin objAdmin);

        //int GetByAdEmail_id(string AdEmail_id, string AdPassword);
        List<Admin> GetAllAdmin();
       // void DeleteAdmin(int admin);

    }
}
