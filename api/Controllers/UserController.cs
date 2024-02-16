using api.Data;
using api.Mappers;
using api.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList()
            .Select(s => s.ToUserRequestDto());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();
            return Ok(user.ToUserRequestDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDTO();
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = userModel.id }, userModel.ToUserRequestDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequestDto userDto)
        {
            var userModel = _context.Users.Find(id);
            if (userModel == null)
                return NotFound();
            userDto.UpdateToUserFromUserDTO(userModel);
            _context.SaveChanges();
            return Ok(userModel.ToUserRequestDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var userModel = _context.Users.Find(id);
            if (userModel == null)
                return NotFound();
            _context.Users.Remove(userModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}