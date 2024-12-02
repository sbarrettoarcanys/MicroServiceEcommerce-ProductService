using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Models.ViewModels;
using ECommerce.ProductService.Utility;
using ECommerce.ProductService.BusinessLogic.Managers;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.ProductService.Controllers
{
    [Route("api/productUser")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly ITokenProviderManager _tokenProvider;
        private readonly IUserManager _userManager;
        private ResponseViewModel _response;

        public UserController(IAuthManager authManager, ITokenProviderManager tokenProvider, IUserManager userManager)
        {
            _authManager = authManager;
            _tokenProvider = tokenProvider;
            _response = new ResponseViewModel();

            _userManager = userManager;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = ConstantValues.Role_Admin)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _response.Result = _userManager.GetUsers();
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

                return BadRequest(_response);
            }

        }




        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestViewModel loginRequestViewModel)
        {
            try
            {
                ResponseViewModel responseViewModel = await _authManager.LoginAsync(loginRequestViewModel);

                if (responseViewModel != null && responseViewModel.IsSuccess)
                {
                    LoginResponseViewModel loginResponseViewModel =
                        JsonConvert.DeserializeObject<LoginResponseViewModel>(Convert.ToString(responseViewModel.Result));


                    UserViewModel existingUser = _userManager.GetUser(loginResponseViewModel.User.ExternalId);
                    if (existingUser == null)
                    {
                        //register user if logging in without existing productService.UserModel
                        _userManager.Add(loginResponseViewModel.User);
                    }

                    await SignInUser(loginResponseViewModel);
                    _tokenProvider.SetToken(loginResponseViewModel.Token);

                    _response.Result = loginResponseViewModel;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = responseViewModel.Message;

                }
                return Ok(_response);

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;

                return BadRequest(_response);
            }

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationRequestViewModel registrationRequestViewModel)
        {
            try
            {
                ResponseViewModel result = await _authManager.RegisterAsync(registrationRequestViewModel);

                if (result == null && !result.IsSuccess)
                {

                    _response.IsSuccess = false;
                    _response.Message = result.Message;
                }
                else
                {
                    _response.Message = "Registration successful";
                }
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

                return BadRequest(_response);
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                _tokenProvider.ClearToken();

                _response.Message = "User Logged Out";

                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

                return BadRequest(_response);
            }

        }


        private async Task SignInUser(LoginResponseViewModel loginResponseViewModel)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(loginResponseViewModel.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));



            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
