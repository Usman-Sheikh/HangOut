using System;
using System.Data.Entity;
using System.Linq;
using HangOut.Models;
using Microsoft.Ajax.Utilities;

namespace HangOut.Controllers
{
    public class FoodController : BasePlaceController<Resturant, FoodViewModel>
    {
        protected override DbSet<Resturant> Table => Database.Resturants;

        protected override IQueryable<Resturant> Items
        {
            get
            {
                var items = Database.Resturants.OrderBy(x => x.Id);
                ViewBag.CityList = items.DistinctBy(x => x.Place.Town).Select(x => new System.Web.Mvc.SelectListItem(){Value= x.Place.City.Id.ToString(), Text= x.Place.City.Name});
                int townFilter = 0;
                int foodFilter = 0;
                Int32.TryParse(Request["foodFilter"], out foodFilter);
                Int32.TryParse(Request["townFilter"], out townFilter);
                ViewBag.SelectedTownFilter = townFilter.ToString();
                ViewBag.SelectedFoodFilter = foodFilter.ToString();
                
                return items.Where(x => (townFilter == 0 || x.Place.Town == townFilter)
                && (foodFilter == 0 || x.RestType ==  foodFilter));
            }
        }


        protected override void OnSaveChanges(Resturant model)
        {
            Database.Entry(model).State = EntityState.Modified;
            Database.Entry(model.Place).State = EntityState.Modified;
            Database.SaveChanges();
        }
    }
}