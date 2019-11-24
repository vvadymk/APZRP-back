using System;
using System.Linq;
using System.Threading.Tasks;
using APZRP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APZRP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly Models.AppContext _context;
        private UserManager<AppUser> _userManager;
        public UserProfileController(UserManager<AppUser> userManager, Models.AppContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }

        [HttpGet]
        [Route("history")]
        [Authorize]
        public async Task<Query> GetHistory()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            Query a = await _context.Query.SingleOrDefaultAsync(m => m.Id == userId);
            return a;
        }

        [HttpPost]
        [Route("addQuery")]
        [Authorize]
        public object PostQuery(QueryModel model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var query = new Query()
            {
                Arab = model.Arab,
                Roman = "s",
                Date = DateTime.Now,
                UserId = userId
            };

            try
            {
                _context.Query.Add(query);
                return new OkObjectResult(new { Ok = true });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}