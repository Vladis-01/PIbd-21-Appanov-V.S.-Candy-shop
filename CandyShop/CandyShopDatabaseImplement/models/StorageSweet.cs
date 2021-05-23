using CandyShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShopDatabaseImplement.Models
{
    public class StorageSweet
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int SweetId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Sweet Sweet { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
