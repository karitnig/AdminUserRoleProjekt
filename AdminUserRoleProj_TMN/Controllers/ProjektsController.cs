using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminUserRoleProj_TMN.Models;
using AdminUserRoleProj_TMN.Models.ModelDB;
using AdminUserRoleProj_TMN.Models.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdminUserRoleProj_TMN.Controllers
{
    public class ProjektsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly UOW uow = new UOW();
        // GET: Projekts
        public async Task<ActionResult> Index()
        {
            return View(await uow.AdminManagerRepo.GetAll());
        }

        // GET: Projekts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = await uow.AdminManagerRepo.GetById(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            return View(projekt);
        }
        //TODO: Dropdown AppUser

        // GET: Projekts/Create
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create()
        {
            ViewBag.UserList = new SelectList(await uow.AdminManagerRepo.UserDropDown(), "ValueMember", "DisplayMember");

            return View();
        }

        // POST: Projekts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProjektID,ProjektName,ProjektDescription")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                uow.AdminManagerRepo.Add(projekt);
                await uow.CommitAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserList = new SelectList(await uow.AdminManagerRepo.UserDropDown(), "ValueMember", "DisplayMember", projekt.Id);

            return View(projekt);
        }

        // GET: Projekts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = await uow.AdminManagerRepo.GetById(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            return View(projekt);
        }

        // POST: Projekts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjektID,ProjektName,ProjektDescription")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                uow.AdminManagerRepo.Update(projekt);
                await uow.CommitAsync();
                return RedirectToAction("Index");
            }
            return View(projekt);
        }

        // GET: Projekts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = await uow.AdminManagerRepo.GetById(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            return View(projekt);
        }

        // POST: Projekts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Projekt projekt = await uow.AdminManagerRepo.GetById(id);
            uow.AdminManagerRepo.Remove(projekt);
            await uow.CommitAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}
