using HangOut.Models;

namespace HangOut.Controllers
{
    public abstract class PlaceController<TModel> : BasePlaceController<TModel,PlaceViewModel>
        where TModel:class
    {
    }
}