using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HangOut.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace HangOut.Controllers
{
    public abstract class BasePlaceController<TModel, TViewModel> : Controller 
        where TModel:class 
        where TViewModel: PlaceViewModel
    {
        protected readonly HangOutEntities Database = new HangOutEntities();
        protected readonly IMapper MapperConfig = HangOut.MapperConfig.GetMapperConfig();
        protected abstract DbSet<TModel> Table { get; }
        protected abstract IQueryable<TModel> Items { get; }

        public BasePlaceController()
        {
            SetCityList();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.ControllerName = ControllerContext.RouteData.GetRequiredString("controller");
            base.OnActionExecuting(filterContext);
        }

        public void SetCityList()
        {
            ViewBag.CityList = Database.Cities.Select(x => new System.Web.Mvc.SelectListItem() {Text = x.Name, Value = x.Id.ToString()});
        }
        public ActionResult Index(int pageNumber=0)
        {
            int totalCount = Items.Count();
            const int itemsPerPage = 4;
            ViewBag.PageCount = (totalCount/itemsPerPage);
            ViewBag.CurrentPageNumber = pageNumber;
            var items = Items.Skip(itemsPerPage*(pageNumber)).Take(itemsPerPage);
            return View(MapperConfig.Map<IQueryable<TModel>, IEnumerable<TViewModel>>(items));
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Table.Add(MapperConfig.Map<TViewModel, TModel>(viewModel));
                Database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var place = Table.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(MapperConfig.Map<TViewModel>(place));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, string message)
        {
            var userId = User.Identity.GetUserId() ?? "b7e9f6b1-ab79-4e5d-8ab3-39b7586c25aa";
            var review = new Review()
            {
                PlaceId = id,
                ParentId = 0,
                Time = DateTime.Now,
                Text = message,
                UserId = userId
            };
            Database.Reviews.Add(review);
            Database.SaveChanges();
            return RedirectToAction("Details", new { Id = id });
        }

        protected abstract void OnSaveChanges(TModel model);
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TViewModel viewModel)
        {
            var model = MapperConfig.Map<TViewModel, TModel>(viewModel);
            if (ModelState.IsValid)
            {
                OnSaveChanges(model);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        protected virtual void onLoad(TViewModel model)
        {
            
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var place = Table.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            var viewModel = MapperConfig.Map<TModel, TViewModel>(place);
            var reviews = Database.Reviews.Where(x => x.PlaceId == id);
            var commentsViewModel = MapperConfig.Map<IQueryable<Review>, List<CommentsViewModel>>(reviews);
            viewModel.Comments = commentsViewModel;
            viewModel.Comments.ForEach(x => x.UserName = UserManager.FindById(x.UserId).UserName);
            onLoad(viewModel);
            return View(viewModel);
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationUserManager _userManager;
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var place = Table.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            Database.Entry(place).State = EntityState.Deleted;
            Database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}