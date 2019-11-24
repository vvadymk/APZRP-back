using System;
using System.ComponentModel.DataAnnotations;


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
        [Required]
        public string UserId { get; set; }
    }
}
