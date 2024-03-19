using API_PORTAFOLIO.Models;
using API_PORTAFOLIO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_PORTAFOLIO.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CertificadoController : ControllerBase
    {
        private readonly CertifiacionServices _services;

        public CertificadoController(CertifiacionServices certiservices)
        {
            _services = certiservices;
        }

        [HttpGet]
        public async Task<IActionResult> getCertificados()
        {
            var certificados = await _services.getCertificados();
            return Ok(certificados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var certificado = await _services.GetCertificationById(id);
            return Ok(certificado);
        }

        [HttpPost]
        public async Task <IActionResult> CreateCertificado([FromBody] Certificacion certificacion)
        {
            await _services.InsertCertificado(certificacion);
            return Created("Created", true);
        }

        
    }
}
