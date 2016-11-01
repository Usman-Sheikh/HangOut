using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class TransportsController : Controller
    {
        private HangOutEntities db = new HangOutEntities();

        // GET: Transports
        public ActionResult Index(int transType=1)
        {
            var transports = db.Transports.Include(t => t.City).Include(t => t.City1).Include(t => t.TransportType)
                .Where(x => x.TransType == transType);
            ViewBag.TransType = transType;
            ViewBag.TransTypeName = db.TransportTypes.First(x => x.Id == transType).Name;
            return View(transports.ToList());
        }

        // GET: Transports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transports/Create
        public ActionResult Create(int transType=1)
        {
            ViewBag.TransTypeName = db.TransportTypes.First(x => x.Id == transType).Name;
            ViewBag.DepartureFrom = new SelectList(db.Cities, "Id", "Name");
            ViewBag.DepartureTo = new SelectList(db.Cities, "Id", "Name");
            //ViewBag.TransType = new SelectList(db.TransportTypes, "Id", "Name");
            ViewBag.TransType = transType;
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TransType,DepartureFrom,DepartureTo,Time")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Transports.Add(transport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartureFrom = new SelectList(db.Cities, "Id", "Name", transport.DepartureFrom);
            ViewBag.DepartureTo = new SelectList(db.Cities, "Id", "Name", transport.DepartureTo);
            ViewBag.TransType = new SelectList(db.TransportTypes, "Id", "Name", transport.TransType);
            return View(transport);
        }

        // GET: Transports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartureFrom = new SelectList(db.Cities, "Id", "Name", transport.DepartureFrom);
            ViewBag.DepartureTo = new SelectList(db.Cities, "Id", "Name", transport.DepartureTo);
            ViewBag.TransType = new SelectList(db.TransportTypes, "Id", "Name", transport.TransType);
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TransType,DepartureFrom,DepartureTo,Time")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartureFrom = new SelectList(db.Cities, "Id", "Name", transport.DepartureFrom);
            ViewBag.DepartureTo = new SelectList(db.Cities, "Id", "Name", transport.DepartureTo);
            ViewBag.TransType = new SelectList(db.TransportTypes, "Id", "Name", transport.TransType);
            return View(transport);
        }

        // GET: Transports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = db.Transports.Find(id);
            db.Transports.Remove(transport);
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
