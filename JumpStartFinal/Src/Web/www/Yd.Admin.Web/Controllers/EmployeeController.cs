using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Yd.Server.Core.Data;
using Yd.Server.Core.Model;

namespace Yd.Admin.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private YdAdventureContext db = new YdAdventureContext();

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.JobTitle).Include(e => e.Person);
            return View(await employees.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "JobTitleId", "Name");
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FullName");
            return View();
        }

        // POST: Employee/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeId,PersonId,HireDate,JobTitleId,TeamId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.JobTitleId = new SelectList(db.JobTitles, "JobTitleId", "Name", employee.JobTitleId);
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FullName", employee.PersonId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "JobTitleId", "Name", employee.JobTitleId);
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FullName", employee.PersonId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeId,PersonId,HireDate,JobTitleId,TeamId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.JobTitleId = new SelectList(db.JobTitles, "JobTitleId", "Name", employee.JobTitleId);
            ViewBag.PersonId = new SelectList(db.Persons, "PersonId", "FullName", employee.PersonId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
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
