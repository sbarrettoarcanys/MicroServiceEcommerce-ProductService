using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Models.ViewModels;
using ECommerce.ProductService.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.ProductService.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IProductImageManager _productImageManager;
        private ResponseViewModel _response;

        public ProductController(IProductManager productManager,
            ICategoryManager categoryManager,
            IProductImageManager productImageManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _productImageManager = productImageManager;
            _response = new ResponseViewModel();
        }

        [Authorize(Roles = ConstantValues.Role_Admin)]
        [HttpPost("AddProduct")]
        public IActionResult Add(CreateProductViewModel createProductViewModel)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    int productId = _productManager.Add(createProductViewModel);


                    if (productId == 0)
                    {
                        return NotFound();
                    }

                    _response.Result = _productManager.Get(productId);

                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }
                return Ok(_response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = ConstantValues.Role_Admin)]
        [HttpPut("UpdateProduct")]
        public IActionResult Update(UpdateProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var existingProduct = _productManager.Get(productViewModel.Id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    productViewModel.CreateDate = existingProduct.CreateDate;
                    int productId = _productManager.Update(productViewModel);
                    if (productId == 0)
                    {
                        return NotFound();
                    }

                    _response.Result = _productManager.Get(productId);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Message = ex.Message;
                }

                return Ok(_response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [Authorize(Roles = ConstantValues.Role_Admin)]
        [HttpGet("GetAllProducts")]
        public IActionResult GetAll()
        {
            try
            {
                List<ProductViewModel> products = _productManager.GetAll();
                _response.Result = products;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }


            return Ok(_response);
        }

        [HttpGet("GetAllActiveProducts")]
        public IActionResult GetAllActive()
        {
            try
            {
                List<ProductViewModel> products = _productManager.GetAllActive();
                _response.Result = products;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }


            return Ok(_response);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductViewModel product = _productManager.Get(id);
                _response.Result = product;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }


            return Ok(_response);
        }

        [Authorize(Roles = ConstantValues.Role_Admin)]
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ProductViewModel productViewModel = _productManager.Get(id.Value);

            if (productViewModel == null || productViewModel.IsActive == false)
            {
                return NotFound();
            }
            try
            {

                _productManager.Delete(id.Value);

                _response.Message = "Product Successfully Deleted";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return Ok(_response);
        }


        [Authorize(Roles = ConstantValues.Role_Admin)]
        [HttpDelete("productImage/{imageId}", Name = "DeleteProductImage")]
        public IActionResult DeleteImage(int imageId)
        {
            try
            {
                int productId = _productImageManager.Delete(imageId);
                _response.Message = "Product Image Successfully Deleted";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return Ok(_response);

        }
    }
}
