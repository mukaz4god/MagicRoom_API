using AutoMapper;
using MagicHouse_HouseAPI.Data;
using MagicHouse_HouseAPI.Models;
using MagicHouse_HouseAPI.Models.Dto;
using MagicHouse_HouseAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicHouse_HouseAPI.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/HouseAPI")]
    [ApiController]
    public class HouseAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogger<HouseAPIController> _logger;
        private readonly IHouseRepository _db;
        private readonly IMapper _mapper;
        public HouseAPIController(ILogger<HouseAPIController> logger, IHouseRepository db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            this._response = new ();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetHouses()
        {
            try
            {
                IEnumerable<House> HouseList = await _db.GetAllAsync();
                _logger.LogInformation("Getting all Houses");
                _response.Result = _mapper.Map<List<HouseDto>>(HouseList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetHouse(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Get House Error with Id: " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var House = await _db.GetAsync(d=>d.Id==id);
                if (House == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<HouseDto>(House);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> CreateHouse([FromBody] HouseDto HouseDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (HouseDto == null)
                {
                    return BadRequest(HouseDto);
                }
                if (HouseDto.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                House myHouse = _mapper.Map<House>(HouseDto);

                await _db.CreateAsync(myHouse);
                _response.Result = _mapper.Map<HouseDto>(myHouse);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetHouse", new { id = myHouse.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteHouse(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Get House Error with Id: " + id);
                    return BadRequest();
                }
                var House = await _db.GetAsync(u => u.Id == id);
                if (House == null)
                {
                    return NotFound();
                }

                await _db.RemoveAsync(House);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateHouse(int id, [FromBody] HouseDto HouseDto)
        {
            try
            {
                if (HouseDto == null || id != HouseDto.Id)
                {
                    return BadRequest();
                }
                House myHouse = _mapper.Map<House>(HouseDto);
                await _db.UpdateAsync(myHouse);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = myHouse;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialHouse(int id, JsonPatchDocument<HouseDto> HouseDto)
        {
            try
            {
                if (HouseDto == null || id == 0)
                {
                    return BadRequest();
                }
                var House = _db.GetAsync(u => u.Id == id);
                HouseDto myHouseDto = _mapper.Map<HouseDto>(House);
                if (House == null)
                {
                    return BadRequest();
                }

                HouseDto.ApplyTo(myHouseDto, ModelState);

                House realHouse = _mapper.Map<House>(myHouseDto);

                await _db.UpdateAsync(realHouse);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = realHouse;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return Ok(_response);
        }
    }
}
