using DataMatrix_TestApp.Interfaces;
using DataMatrix_TestApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataMatrix_TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactUserController : Controller
    {
        private readonly IContactUserService _service;

        public ContactUserController(IContactUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Getting contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            if (id <= 0) return BadRequest("Entity with this Id is not exist");

            var result = await _service.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Getting contact list with pagination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _service.GetPaged(page, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Adding new contact to DB
        /// </summary>
        /// <param name="inputContactUser"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] InputContactUser inputContactUser)
        {
            if(!ModelState.IsValid)
                return BadRequest("Model is not valid");

            //here I would add AutoMapper and use it, but I decided to leave it like this
            var contactUser = new ContactUser()
            {
                Email = inputContactUser.Email,
                LastName = inputContactUser.LastName,
                Name = inputContactUser.Name,
                PhoneNumber = inputContactUser.PhoneNumber,
                PhotoUrl = inputContactUser.PhotoUrl,
            };
            var result = await _service.AddContactUser(contactUser);
            return result is not null ? Ok(result) : BadRequest("somethink is wrong");
        }

        /// <summary>
        /// Updating existing contact
        /// </summary>
        /// <param name="contactUser"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateContact(ContactUser contactUser)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");

            var result = await _service.UpdateContactUser(contactUser);
            return result is not null ? Ok(result) : BadRequest("somethink is wrong");
        }

        /// <summary>
        /// Deleting contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteContact([FromBody] int id)
        {
            if (id <= 0) return BadRequest("Entity with this Id is not exist");

            var result = await _service.DeleteContactUser(id);
            return Ok(result);
        }
    }
}
