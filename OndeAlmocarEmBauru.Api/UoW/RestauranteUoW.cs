using OndeAlmocarEmBauru.Api.UoW.Infra;
using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW
{
    public class RestauranteUoW : IRestauranteUoW
    {
        public IRestauranteBLL restauranteBLL { get; }

        public RestauranteUoW(IRestauranteBLL restauranteBLL)
        {
            this.restauranteBLL = restauranteBLL;
        }
    }
}
