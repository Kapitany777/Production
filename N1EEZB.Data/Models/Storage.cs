using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.Data.Models
{
    [Table("Storages")]
    public class Storage
    {
        public int StorageId { get; set; }

        [Required]
        [StringLength(40)]
        public string StorageName { get; set; }
    }
}
