using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class City:BasicEntity
    {
        
        public int? StateId { get; set; }
        public string? CityName { get; set; }

        [ForeignKey("StateId")]
        public virtual State? State { get; set; }
        
    }
}
