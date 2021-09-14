namespace SCommerce.Main.Services
{
    public interface ICartService
    {
        void Add(int productId, int quantity);
    }
}