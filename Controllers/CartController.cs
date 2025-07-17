using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICardSessionHelper _cardSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICardSessionHelper cardSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cardSessionHelper = cardSessionHelper;
            _productService = productService;
        }
        public IActionResult AddToCart(int productId)
        {
            // ürünü çek
            Product product = _productService.GetById(productId);
            var cart = _cardSessionHelper.GetCart("cart");

            _cartService.AddToCart(cart, product);

            _cardSessionHelper.SetCart("cart", cart);
            TempData.Add("message", product.ProductName + " sepetinize eklendi.");

            return RedirectToAction("Index", "Product");
        }
        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cardSessionHelper.GetCart("cart")
            };
            return View(model);
        }
        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            var cart = _cardSessionHelper.GetCart("cart");

            _cartService.RemoveFromCart(cart, productId);

            _cardSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + " sepetinizden silindi.");

            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Siparişiniz alınmıştır. Teşekkür ederiz.");
            _cardSessionHelper.Clear("cart");
            return RedirectToAction("Index", "Cart");
        }
    }
}
