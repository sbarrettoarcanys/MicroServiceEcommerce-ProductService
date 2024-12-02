using ECommerce.ProductService.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace ECommerce.ProductService.Models.ViewModels
{
    public class ProductViewModel : AuditTrail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Display(Name = "Discounted Price")]
        [Range(1, 1000)]
        public double? DiscountedPrice { get; set; }

        [ValidateNever]
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        [ValidateNever]
        public List<ProductImageViewModel> ProductImages { get; set; }

        //[Display(Name = "Categories")]
        //public IEnumerable<int> CategoryIds { get; set; }


        //[ValidateNever]
        //public List<IFormFile> Files { get; set; }
    }

    public class CreateProductViewModel
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Display(Name = "Discounted Price")]
        [Range(1, 1000)]
        public double? DiscountedPrice { get; set; }


        [Display(Name = "Categories")]
        public IEnumerable<int> CategoryIds { get; set; }


        [ValidateNever]
        public List<IFormFile> Files { get; set; }
    }

    public class UpdateProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Display(Name = "Discounted Price")]
        [Range(1, 1000)]
        public double? DiscountedPrice { get; set; }

        public bool IsActive { get; set; }

        [JsonIgnore]
        public DateTime? CreateDate { get; set; }



        [Display(Name = "Categories")]
        public IEnumerable<int> CategoryIds { get; set; }


        [ValidateNever]
        public List<IFormFile> Files { get; set; }
    }
}
