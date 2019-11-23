using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MOD.DtosLibrary;
using MOD.ModelLibrary;

namespace MOD.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<UserMod> signInManager;
        private readonly UserManager<UserMod> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthController(UserManager<UserMod> userManager,
            SignInManager<UserMod> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }

        [Route("login")]
        [HttpPost]

        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync
                (model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                if (appUser.Active)
                {
                    var response = await GenerateJwtToken(model.Email, appUser);
                    return Ok(response);
                }
                return BadRequest(new { Message = "You have been blocked by administrator." });
            }

            return BadRequest(new { Message = "Invalid Email or Password." });
        }

        [Route("logout")]
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Logout([FromBody] LoginDto model)
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                //InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "LogOut Failed");
            }
            return Ok();
        }

        [Route("register")]
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UserMod
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Contactnumber,
                YearOfExperience = model.YearOfExperience,
                TrainerTechnology = model.TrainerTechnology
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //role
                var roleName = roleManager.Roles.FirstOrDefault(
                    r => r.Id == model.Role.ToString()).NormalizedName;

                var result1 = await userManager.AddToRoleAsync(user, roleName);
                if (result1.Succeeded)
                {
                    //  return Created("Registered", model.Email);
                    //var response = await GenerateJwtToken(model.Email, user);
                    var response = new { Message = "Registered Successfully" };
                    return Ok(response);
                }
                return BadRequest(result1.Errors);
            }
            return BadRequest(result.Errors);
        }
        private async Task<TokenDto> GenerateJwtToken(string email,
            UserMod user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var role = roleManager.Roles.SingleOrDefault(r => r.Name == roles.SingleOrDefault());
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role, role.Name)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration["JwtKey"]));
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(
                Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds);



            var response = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                userInfo = new UserInfoDto
                {
                    Email = user.Email,
                    Role = Convert.ToInt32(role.Id),
                    Id = user.Id,
                    Active = true
                },
                message = "Logged In Successfully"
            };

            return response;
        }
        //[HttpGet]
        //public List<UserDto> GetUsers()
        //{
        //    var users = userManager.Users.ToList();

        //    var userDto = users.Select(u => new UserDto
        //    {
        //        Id = u.Id,
        //        Email = u.Email,
        //        Firstname = u.Firstname,
        //        Lastname = u.Lastname,
        //        Role = roleManager.Roles.SingleOrDefault(
        //                        r => r.NormalizedName == userManager.GetRolesAsync(u).Result.SingleOrDefault()).Id,
        //        Active = u.Active
        //    });

        //    return userDto.ToList();
        //}

    }
}