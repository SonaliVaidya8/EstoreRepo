using EStoreProject.Model;

namespace EStoreProject.BusinessLogic
{
    public interface IAdminContextDb
    {
        void AddAdmin(Admin objAdmin);
        Admin GetByAdEmail_id(string AdEmail_id);

    }
}