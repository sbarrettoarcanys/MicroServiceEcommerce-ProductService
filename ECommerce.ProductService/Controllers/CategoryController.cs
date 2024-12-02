using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Models.ViewModels;
using ECommerce.ProductService.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ECommerce.ProductService.Controllers
{
    [ApiController]
    [Route("api/category")]
    [Authorize(Roles = ConstantValues.Role_Admin)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private ResponseViewModel _response;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
            _response = new ResponseViewModel();
        }

        [HttpPost("AddCategory")]
        public IActionResult Add(CreateCategoryViewModel categoryCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryId = _categoryManager.Add(categoryCreateViewModel);

                    _response.Result = _categoryManager.Get(categoryId);

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
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            try
            {
                CategoryViewModel categoryViewModel = _categoryManager.Get(id.Value);

                if (categoryViewModel == null)
                {
                    return NotFound();
                }

                _response.Result = categoryViewModel;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }


        [HttpPut("UpdateCategory")]
        public IActionResult Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (updateCategoryViewModel == null || updateCategoryViewModel.Id == 0)
                {
                    return NotFound();
                }

                try
                {
                    var existingCategory = _categoryManager.Get(updateCategoryViewModel.Id);

                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    updateCategoryViewModel.CreateDate = existingCategory.CreateDate;
                    var categoryId = _categoryManager.Update(updateCategoryViewModel);

                    _response.Result = _categoryManager.Get(categoryId);
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

        [HttpGet("GetAllCategory")]
        public IActionResult GetAll()
        {
            try
            {
                _response.Result = _categoryManager.GetAll();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return Ok(_response);
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            try
            {
                var existingCategory = _categoryManager.Get(id.Value);

                if (existingCategory == null || !existingCategory.IsActive)
                {
                    return NotFound();
                }

                int categoryId = _categoryManager.Delete(id.Value);

                _response.Message = "Category Successfully deleted";

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
