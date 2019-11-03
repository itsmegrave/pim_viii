using PIM_VIII.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PIM_VIII.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaDBContext db = new TarefaDBContext();

        // GET: Tarefas
        public ActionResult Index()
        {
            return View(db.Tarefas.ToList());
        }

        public ActionResult Overdue()
        {
            var hoje = DateTime.Now.Date;

            return View(db.Tarefas.Where(a => DbFunctions.TruncateTime(a.Vencimento) < hoje).ToList());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nome,descricao,vencimento")] TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaModel tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,Vencimento")] TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaModel tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TarefaModel tarefa = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefa);
            db.SaveChanges();
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