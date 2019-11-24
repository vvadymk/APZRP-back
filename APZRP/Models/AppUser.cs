using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace APZRP.Models
{
    public class AppUser :IdentityUser
    {

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
    }
}
