using CoreBackend.Data;
using CoreBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == dto.UserName))
            {
                return BadRequest("Username exist!");
            }

            User user = new()
            {
                UserName = dto.UserName,
                PasswordHash = dto.Password,
                DataUser = dto.DataUser,
                Enabled = true        
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(new {userId = user.id});
        }

    }
    

    
}