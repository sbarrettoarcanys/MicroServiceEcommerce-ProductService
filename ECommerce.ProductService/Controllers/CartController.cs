using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Models.ViewModels;
using ECommerce.ProductService.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.ProductService.Controllers
{
    [Route("api/shoppingCart")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IShoppingCartManager _shoppingCartManager;
        private readonly IProductImageManager _productImageManager;
        private readonly ResponseViewModel _response;

        public CartController(IShoppingCartManager shoppingCartManager, IProductImageManager productImageManager)
        {
            _shoppingCartManager = shoppingCartManager;
            _productImageManager = productImageManager;
            _response = new ResponseViewModel();
        }

        [HttpGet("GetCart")]
        public IActionResult GetCart()
        {
            try
            {
                ClaimsIdentity? claimsIdentity = (ClaimsIdentity)User.Identity;
                string externalId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                var shoppingCartDetailsViewModel = _shoppingCartManager.GetShoppingCartDetails(externalId);
                _response.Result = shoppingCartDetailsViewModel;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.Message = ex.Message;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart(CreateShoppingCartViewModel createShoppingCartViewModel)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var externalId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                createShoppingCartViewModel.ExternalId = externalId;

                int id = _shoppingCartManager.Add(createShoppingCartViewModel);
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Error adding to cart";
                    return BadRequest(_response);
                }

                var shoppingCartDetailsViewModel = _shoppingCartManager.GetShoppingCartDetails(externalId);

                _response.Result = shoppingCartDetailsViewModel;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

                return BadRequest(_response);
            }
        }

        [HttpPost("IncreaseCartItem")]
        public IActionResult IncreaseCartItem(int cartid)
        {
            try
            {

                ShoppingCartViewModel shoppingCartViewModel = _shoppingCartManager.Get(cartid);

                if (shoppingCartViewModel == null)
                {
                    _response.Message = "Shopping cart item not found";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                shoppingCartViewModel.Count += 1;
                _shoppingCartManager.Update(shoppingCartViewModel);

                ClaimsIdentity? claimsIdentity = (ClaimsIdentity)User.Identity;
                string externalId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


                var shoppingCartDetailsViewModel = _shoppingCartManager.GetShoppingCartDetails(externalId);

                _response.Result = shoppingCartDetailsViewModel;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }

        }

        [HttpPost("ReduceCartItem")]
        public IActionResult ReduceCartItem(int cartid)
        {
            try
            {
                ShoppingCartViewModel shoppingCartViewModel = _shoppingCartManager.Get(cartid);

                if (shoppingCartViewModel == null)
                {
                    _response.Message = "Shopping cart item not found";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                shoppingCartViewModel.Count -= 1;

                if (shoppingCartViewModel.Count <= 0)
                {
                    //remove that from cart
                    _shoppingCartManager.Delete(cartid);
                }
                else
                {
                    _shoppingCartManager.Update(shoppingCartViewModel);
                }

                ClaimsIdentity? claimsIdentity = (ClaimsIdentity)User.Identity;
                string externalId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                var shoppingCartDetailsViewModel = _shoppingCartManager.GetShoppingCartDetails(externalId);

                _response.Result = shoppingCartDetailsViewModel;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost("RemoveCartItem")]
        public IActionResult RemoveCartItem(int cartid)
        {
            try
            {

                ShoppingCartViewModel shoppingCartViewModel = _shoppingCartManager.Get(cartid);

                if (shoppingCartViewModel == null)
                {
                    _response.Message = "Shopping cart item not found";
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                _shoppingCartManager.Delete(cartid);

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                var shoppingCartDetailsViewModel = _shoppingCartManager.GetShoppingCartDetails(claim.Value);

                _response.Result = shoppingCartDetailsViewModel;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }


        }
    }
}
