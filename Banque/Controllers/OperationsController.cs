using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORM;

namespace Banque.Controllers
{
    public class OperationsController : Controller
    {
        private DB db = new DB();

        // GET: Operations
        public async Task<ActionResult> Index()
        {
            var operation = db.Operation.Include(o => o.Compte);
            return View(await operation.ToListAsync());
        }

        // GET: Operations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = await db.Operation.FindAsync(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle");
            return View();
        }

        // POST: Operations/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdOperation,type,DateOperation,Montant,IdCompte")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Operation.Add(operation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle", operation.IdCompte);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = await db.Operation.FindAsync(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle", operation.IdCompte);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdOperation,type,DateOperation,Montant,IdCompte")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompte = new SelectList(db.Compte, "IdCompte", "Libelle", operation.IdCompte);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = await db.Operation.FindAsync(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Operation operation = await db.Operation.FindAsync(id);
            db.Operation.Remove(operation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
