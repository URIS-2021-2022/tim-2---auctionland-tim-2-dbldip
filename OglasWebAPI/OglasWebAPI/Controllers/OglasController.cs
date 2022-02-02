using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OglasWebAPI.Data.Interfaces;
using OglasWebAPI.Entities;
using OglasWebAPI.Models.Oglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Controllers
{
    [Route("api/oglas")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OglasController : ControllerBase
    {
        private readonly IOglasRepository _oglasRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public OglasController(IOglasRepository oglasRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            _oglasRepository = oglasRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<OglasDto>>> GetAllOglasi()
        {
            var oglasi = await _oglasRepository.GetAllOglasi();

            if (oglasi == null || oglasi.Count == 0)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<OglasDto>>(oglasi));
        }

        [HttpGet("{oglasId}")]
        public async Task<ActionResult<OglasDto>> GetOglas(Guid oglasId)
        {
            var oglas = await _oglasRepository.GetOglasById(oglasId);
            if (oglas == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OglasDto>(oglas));
        }

        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<OglasCreateDto>> CreateOglas([FromBody] OglasCreateDto oglas)
        {
            try
            {

                Oglas createdOglas = await _oglasRepository.CreateOglas(_mapper.Map<Oglas>(oglas));
                string location = _linkGenerator.GetPathByAction("GetOglas", "Oglas", new { oglasId = createdOglas.OglasId });

                return Created(location, _mapper.Map<OglasCreateDto>(createdOglas));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create Oglas error!");
            }
        }

        [Consumes("application/json")]
        [HttpPut("{oglasId}")]
        public async Task<ActionResult<OglasUpdateDto>> UpdateOglas(Guid oglasId, [FromBody] OglasUpdateDto oglas)
        {
            try
            {
                var oglasEntity = await _oglasRepository.GetOglasById(oglasId);

                if (oglasEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(oglas, oglasEntity);

                await _oglasRepository.UpdateOglas(_mapper.Map<Oglas>(oglas));

                return Ok(oglas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update Oglas error!");
            }
        }

        [HttpDelete("{oglasId}")]
        public async Task<ActionResult> DeleteOglas(Guid oglasId)
        {
            try
            {
                var oglas = await _oglasRepository.GetOglasById(oglasId);

                if (oglas == null)
                {
                    return NotFound();
                }

                await _oglasRepository.DeleteOglas(oglasId);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Oglas error!");
            }
        }

    }
}
