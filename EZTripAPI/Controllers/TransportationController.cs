using EZTripAPI.Models.Domain;
using EZTripAPI.Models.DTOs;
using EZTripAPI.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EZTripAPI.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TransportationController : ControllerBase
    {

        private readonly ITransportationRepository _TransportationRepos;
        private readonly IWebHostEnvironment _env;
        public TransportationController(ITransportationRepository TranRepo, IWebHostEnvironment env)
        {
            _TransportationRepos = TranRepo;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _TransportationRepos.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            var data = _TransportationRepos.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddUpdate(Transportation model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Validation failed";
            }
            var result = _TransportationRepos.AddUpdate(model);

            status.StatusCode = result ? 1 : 0;
            status.Message = result ? "Saved successfully" : "Error has occured";
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _TransportationRepos.Delete(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                Message = result ? "deleted successfully" : "Error has occured"
            };
            return Ok(status);
        }
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/Transportations/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("Noimage.png");
            }

        }
    }
}
