using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APZRP.Models
{
    public class AppUser :IdentityUser
    {
        //[Key]
        //public string Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
    }
}
