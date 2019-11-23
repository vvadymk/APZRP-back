using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APZRP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APZRP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _singInManager;

        public AppController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(UserModel model)
        {
            var applicationUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}