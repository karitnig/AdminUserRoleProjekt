using AdminUserRoleProj_TMN.Models;
using AdminUserRoleProj_TMN.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AdminUserRoleProj_TMN
{
    public class UOW : IDisposable
    {
        ApplicationDbContext db = new ApplicationDbContext();

        private ProjektUserRepo _adminManagerRepo;

        public ProjektUserRepo AdminManagerRepo
        {
            get 
            {
                if (_adminManagerRepo == null) _adminManagerRepo = new ProjektUserRepo(db);
                return _adminManagerRepo; 
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task CommitAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}