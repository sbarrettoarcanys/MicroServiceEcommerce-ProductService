using ECommerce.ProductService.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace ECommerce.ProductService.Models.ViewModels
{
    public class ShoppingCartViewModel : AuditTrail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ValidateNever]
        public ProductViewModel Product { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

        public int UserId { get; set; }
        public string ExternalId { get; set; }

        private double price;
        [NotMapped]
        public double Price 
        {
            get { return price; }
            set
            {
                price = value;
                PriceString = value.ToString("c");
            }
        }

        public string PriceString { get; set; }
    }

    public class CreateShoppingCartViewModel
    {
        public int ProductId { get; set; }
        public int Count { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public int UserId { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public string ExternalId { get; set; }
    }

    public class ShoppingCartDetailsViewModel
    {
        public List<ShoppingCartViewModel> ShoppingCartViewModels { get; set; }

        private double orderTotal;
        public double OrderTotal
        {
            get { return orderTotal; }
            set
            {
                orderTotal = value;
                OrderTotalString = value.ToString("c");
            }
        }

        public string OrderTotalString { get; set; }

    }
}
