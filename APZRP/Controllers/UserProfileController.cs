using System;
using System.Collections.Generic;
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
            Query a = await _context.Query.SingleOrDefaultAsync(m => m.UserId == userId);
            return a;
        }

        [HttpGet]
        [Route("getQuery")]
        [Authorize]
        public async Task<List<Query>> GetQueryHistory()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var query = await _context.Query.Where(m => m.UserId == userId).ToListAsync();
            return query;
        }

        [HttpPost]
        [Route("addQuery")]
        [Authorize]
        public async Task<object> PostQueryAsync(QueryModel model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var query = new Query()
            {
                Arab = model.Arab,
                Roman = ToRoman(model.Arab),
                Date = DateTime.Now,
                UserId = user.Id
            };

            try
            {
                _context.Query.Add(query);
                _context.SaveChanges();
                return new OkObjectResult(new { Ok = true });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }
    }




}
