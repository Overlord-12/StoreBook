using AutoMapper;
using BuisnessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessManager.Interface;
using StoreBookWebApi.Models.Register;

namespace StoreBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserProcessManager _employeeProcessManager;
        private IAuthenticationProcessManager _authenticationProcessManager;
        private IMapper _mapper;

        public AuthenticationController(IUserProcessManager employeeProcessManager, IMapper mapper, IAuthenticationProcessManager authenticationProcessManager)
        {
            _authenticationProcessManager = authenticationProcessManager;
            _mapper = mapper;
            _employeeProcessManager = employeeProcessManager;
        }
        [HttpPost("register")]
        public ActionResult Register(RegisterDto registerDto)
        {
            _employeeProcessManager.Register(_mapper.Map<User>(registerDto));
           return Ok(registerDto);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(RegisterDto dto)
        {
            try
            {
                User? user = await _employeeProcessManager.GetByEmail(dto.Name);
                if (user == null)
                    return BadRequest("Неверный логин");
                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                    return BadRequest("Неверный пароль");

                var jwt = _authenticationProcessManager.Generate(user.Name);
                return Ok(jwt);
            }
            catch (Exception)
            {

                return BadRequest("Неверный пароль");
            }
        }
    }
}
