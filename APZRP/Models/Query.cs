using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APZRP.Models
{
    public class Query
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int Arab { get; set; }
        [Required]
        public string Roman { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("Id")]
        public AppUser User { get; set; }
        public string UserId { get; set; }
    }
}
