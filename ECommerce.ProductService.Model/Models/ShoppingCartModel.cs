using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.Models.Models
{
    public class ShoppingCartModel : AuditTrail
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ValidateNever]
        public ProductModel Product { get; set; }

        public int UserId { get; set; }
        [ValidateNever]
        [ForeignKey("UserId")]
        public UserModel User { get; set; }

        [NotMapped]
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
