using AdminUserRoleProj_TMN.Models;
using AdminUserRoleProj_TMN.Models.ModelDB;
using AdminUserRoleProj_TMN.Models.ViewModel;
using AdminUserRoleProj_TMN.Repos.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminUserRoleProj_TMN.Repos
{
    public class ProjektUserRepo : IGenericRepo<Projekt>
    {                                               //ACHTUNG Keine INSTANZ bilden//
        private readonly ApplicationDbContext _db;/* = new ApplicationDbContext();*/

        public ProjektUserRepo(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<List<SelectedItemVM>> UserList()
        {
            var prList = await (from p in _db.Projekts
                         orderby p.ProjektID
                         select new SelectedItemVM
                         {
                             ValueMember = p.ProjektID.ToString(),
                             DisplayMember = p.ProjektName
            
                        }).ToListAsync();
            return prList;
        }

        public async Task<List<SelectedItemVM>> UserDropDown()
        {
            var eList = from e in _db.Users
                        orderby e.Id
                        select new SelectedItemVM
                        {
                            ValueMember = e.Id.ToString(),
                            DisplayMember = e.UserName
                        };
            return await eList.ToListAsync();
        }

        public void Add(Projekt t)
        {
            _db.Projekts.Add(t);
        }

        public async Task<List<Projekt>> GetAll()
        {
            return _db.Projekts.ToList();
        }

        public Task<Projekt> GetById(int? id)
        {
            return _db.Projekts.FindAsync(id);
        }

        public void Remove(Projekt t)
        {
            _db.Projekts.Remove(t);
        }

        public void Update(Projekt t)
        {
            _db.Projekts.Attach(t);
            _db.Entry<Projekt>(t).State = System.Data.Entity.EntityState.Modified;
        }

        //internal void UpdateDropDown(SelectedItemVM selectedItemVM)
        //{
        //    SelectedItemVM projekt = _db.Projekts.Attach(selectedItemVM);
        //    var d = _db.Entry(selectedItemVM).State = EntityState.Modified;
        //}


        //public async Task<NNProjektApplicationUser> GetUserProjektList()
        //{
        //    NNProjektApplicationUser nNProjektApplicationUser = await (from n in _db.Projekts
        //                                                               .Include(ApplicationUser)
        //                                                               where )
        //}
        //public void Add(User user)
        //{

        //}

        //public async Task<AdminMaskeVM> GetDetail(int? id)
        //{
        //    AdminMaskeVM adminMaskeVM = await new AdminMaskeVM(from c in _db.
        //                                       where c.UserID == id
        //                                       select new AdminMaskeVM
        //                                       {
        //                                           NickName = c.Ni
        //                                       }).FirstOrDefault();
        //    return adminMaskeVM;
        //}

    }
}