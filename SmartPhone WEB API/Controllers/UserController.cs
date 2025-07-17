using Microsoft.AspNetCore.Mvc;
using SmartPhone.Model;
using SmartPhone.Services;
using System.Collections.Generic;

namespace SmartPhone_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserRespond> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserRespond> Get(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpPost]
        public ActionResult<UserRespond> Create(UserRequest request)
        {
            var user = _userService.Create(request);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserRequest request)
        {
            var updated = _userService.Update(id, request);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _userService.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
} 