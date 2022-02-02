using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OglasWebAPI.Data.Interfaces;
using OglasWebAPI.Entities;
using OglasWebAPI.Models.SluzbeniList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Controllers
{
    [Route("api/sluzbeniList")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class SluzbeniListController : ControllerBase
    {
        private readonly ISluzbeniListRepository _sluzbeniListRepository;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public SluzbeniListController(ISluzbeniListRepository sluzbeniListRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            _sluzbeniListRepository = sluzbeniListRepository;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<SluzbeniListDto>>> GetAllSluzbeniListovi()
        {
            var sluzbeniListovi = await _sluzbeniListRepository.GetAllSluzbeniListovi();

            if (sluzbeniListovi == null || sluzbeniListovi.Count == 0)
            {
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<SluzbeniListDto>>(sluzbeniListovi));
        }

        [HttpGet("{sluzbeniListId}")]
        public async Task<ActionResult<SluzbeniListDto>> GetSluzbeniList(Guid sluzbeniListId)
        {
            var sluzbeniList = await _sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);
            if (sluzbeniList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SluzbeniListDto>(sluzbeniList));
        }

        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<SluzbeniListCreateDto>> CreateSluzbeniList([FromBody] SluzbeniListCreateDto sluzbeniList)
        {
            try
            {
                var proveraValidnosti = await _sluzbeniListRepository.IsValidSluzbeniList(sluzbeniList.Broj);

                if (!proveraValidnosti)
                {
                    var response = new
                    {
                        Message = "Vec postoje podaci u bazi. Unesite druge podatke!"
                    };
                    return BadRequest(response);
                }

                SluzbeniList createdSluzbeniList = await _sluzbeniListRepository.CreateSluzbeniList(_mapper.Map<SluzbeniList>(sluzbeniList));
                string location = _linkGenerator.GetPathByAction("GetSluzbeniList", "SluzbeniList", new { sluzbeniListId = createdSluzbeniList.SluzbeniListId });

                return Created(location, _mapper.Map<SluzbeniListCreateDto>(createdSluzbeniList));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create SluzbeniList error!");
            }
        }

        [Consumes("application/json")]
        [HttpPut("{sluzbeniListId}")]
        public async Task<ActionResult<SluzbeniListUpdateDto>> UpdateSluzbeniList(Guid sluzbeniListId, [FromBody] SluzbeniListUpdateDto sluzbeniList)
        {
            try
            {
                var sluzbeniListEntity = await _sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);

                if(sluzbeniListEntity == null)
                {
                    return NotFound();
                }

                var proveraValidnosti = await _sluzbeniListRepository.IsValidSluzbeniList(sluzbeniList.Broj);

                if (!proveraValidnosti)
                {
                    var response = new
                    {
                        Message = "Vec postoje podaci u bazi. Unesite druge podatke!"
                    };
                    return BadRequest(response);
                }

                _mapper.Map(sluzbeniList, sluzbeniListEntity);

                await _sluzbeniListRepository.UpdateSluzbeniList(_mapper.Map<SluzbeniList>(sluzbeniList));

                return Ok(sluzbeniList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update SluzbeniList error!");
            }
        }

        [HttpDelete("{sluzbeniListId}")]
        public async Task<ActionResult> DeleteSluzbeniList(Guid sluzbeniListId)
        {
            try
            {
                var sluzbeniList = await _sluzbeniListRepository.GetSluzbeniListById(sluzbeniListId);

                if(sluzbeniList == null)
                {
                    return NotFound();
                }

                await _sluzbeniListRepository.DeleteSluzbeniList(sluzbeniListId);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete SluzbeniList error!");
            }
        }

    }
}
