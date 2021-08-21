using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCE_SITE.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        /// <summary>
        /// the consumer facing name of the product
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// the retail price of the product 
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// The category of the product
        /// </summary>
        public string Category { get; set; }
    }
}
