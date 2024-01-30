using EZTripAPI.Models.Domain;
using EZTripAPI.Models.DTOs;
using EZTripAPI.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EZTripAPI.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository BookRepos;
        public BookingController(IBookingRepository bookRepo)
        {
            BookRepos = bookRepo;
        }

        [HttpGet]
        public IActionResult GetAll(string term = "")
        {
            var data = BookRepos.GetAll(term);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = BookRepos.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddUpdate(Booking model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Validation failed";
            }
            var result = BookRepos.AddUpdate(model);

            status.StatusCode = result ? 1 : 0;
            status.Message = result ? "Saved successfully" : "Error has occured";
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = BookRepos.Delete(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                Message = result ? "deleted successfully" : "Error has occured"
            };
            return Ok(status);
        }

    }
}
