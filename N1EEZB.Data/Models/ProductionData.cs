using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.Data.Models
{
    [Table("ProductionData")]
    public class ProductionData
    {
        [Key]
        public int ProductionId { get; set; }

        [Required]
        public Storage Storage { get; set; }
        
        [Required]
        [StringLength(60)]
        public string GS1Barcode { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }
    }
}
