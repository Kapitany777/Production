using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.Data.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(20)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(14)]
        public string GTIN14 { get; set; }
        
        public ItemType ItemType { get; set; }
    }
}
