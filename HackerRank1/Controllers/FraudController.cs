using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudService _fraudService;

        public FraudController(IFraudService fraudService)
        {
            _fraudService = fraudService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _fraudService.GetAll();
            return Ok(reports);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Fraud fraud)
        {
            if (fraud == null)
            {
                return BadRequest("El reporte no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(fraud.ImpostorDetails))
            {
                return BadRequest("Debe indicar los detalles del impostor.");
            }

            if (string.IsNullOrWhiteSpace(fraud.ContactInfo))
            {
                return BadRequest("Debe indicar el medio de contacto usado por el impostor.");
            }

            var createdFraud = await _fraudService.Add(fraud);

            return CreatedAtAction(nameof(GetAll), new { id = createdFraud.Id }, createdFraud);
        }
    }
}