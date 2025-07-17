using Entities.DomainModels;

namespace MvcWebUI.Helpers
{
    public interface ICardSessionHelper
    {
        Cart GetCart(string key);
        void SetCart(string key, Cart cart);
        void Clear(string v);
    }
}
