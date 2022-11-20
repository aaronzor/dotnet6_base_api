using dotnet_web_api_base.Models.DTO;
using dotnet_web_api_base.Data;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api_base.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type =typeof(VillaDTO))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villaList.FirstOrDefault(e => e.Id == id);

            if (villa == null)
            {
                return NotFound();
            }


            return Ok(villa);
        }
    }
}
