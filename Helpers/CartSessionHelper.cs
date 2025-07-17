using Entities.DomainModels;
using MvcWebUI.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MvcWebUI.Helpers
{
    public class CartSessionHelper : ICardSessionHelper
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Clear(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if (cartToCheck == null)
            {
                SetCart(key, new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            }
            return cartToCheck;
        }

        public void SetCart(string key, Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject<Cart>(key, cart);
        }
    }
}
