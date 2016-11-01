using System;
using System.Data.Entity;
using System.Linq;
using HangOut.Models;

namespace HangOut.Controllers
{
    public class HospitalController : BasePlaceController<Hospital, HospitalViewModel>
    {
        protected override DbSet<Hospital> Table => Database.Hospitals;
        protected override IQueryable<Hospital> Items
        {
            get
            {
                //by default public
                bool isPublic = true;
                if (string.IsNullOrEmpty(Request["isPublic"]) == false)
                    bool.TryParse(Request["isPublic"], out isPublic);
                return Database.Hospitals.Where(x => x.IsPublic == isPublic).OrderBy(x => x.Id);
            }
        }



        protected override void OnSaveChanges(Hospital model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}