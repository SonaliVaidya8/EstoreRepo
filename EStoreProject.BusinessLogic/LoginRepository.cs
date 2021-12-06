using EStoreProject.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.BusinessLogic
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ILoginRepository _contextDb;

        public LoginRepository(ILoginRepository contextDb)
        {
            _contextDb = contextDb;
        }
        public int GetByAdEmail_id(string AdEmail_id, string AdPassword)
        {
            var email_id = _contextDb.GetByAdEmail_id(AdEmail_id, AdPassword);
            return email_id;
        }
    }
}
