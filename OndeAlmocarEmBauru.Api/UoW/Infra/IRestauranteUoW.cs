using OndeAlmocarEmBauru.BLL.Infra;

namespace OndeAlmocarEmBauru.Api.UoW.Infra
{
    public interface IRestauranteUoW
    {
        IRestauranteBLL restauranteBLL { get; }
    }
}
