using AutoMapper;
using MagicHouse_HouseAPI.Models;
using MagicHouse_HouseAPI.Models.Dto;
using MagicHouse_HouseAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicRoomNumber_RoomNumberNumberAPI.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/RoomNumberAPI")]
    [ApiController]
    public class RoomNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogger<RoomNumberAPIController> _logger;
        private readonly IRoomNumberRepository _db;
        private readonly IHouseRepository _houseDb;
        private readonly IMapper _mapper;
        public RoomNumberAPIController(ILogger<RoomNumberAPIController> logger, IRoomNumberRepository db, IHouseRepository hdb, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _houseDb = hdb;
            _mapper = mapper;
            this._response = new ();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRoomNumbers()
        {
            try
            {
                IEnumerable<RoomNumber> RoomNumberList = await _db.GetAllAsync(includeProperties:"House");
                _logger.LogInformation("Getting all RoomNumbers");
                _response.Result = _mapper.Map<List<RoomNumberDto>>(RoomNumberList);
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

        [HttpGet("{id:int}", Name = "GetRoomNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetRoomNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Get RoomNumber Error with Id: " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var RoomNumber = await _db.GetAsync();
                if (RoomNumber == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<RoomNumberDto>(RoomNumber);
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
        public async Task<ActionResult<APIResponse>> CreateRoomNumber([FromBody] RoomNumberDto RoomNumberDto)
        {
            try
            {
                if (await _db.GetAsync(u => u.RoomNo == RoomNumberDto.RoomNo) != null)
                {
                    ModelState.AddModelError("ErrorsMessages", "Room number already exists!");
                    return BadRequest(_response);
                }
                if (await _houseDb.GetAsync(u => u.Id == RoomNumberDto.HouseID) == null)
                {
                    ModelState.AddModelError("ErrorsMessages", "House ID is invalid!");
                    return BadRequest(_response);
                }
                if (RoomNumberDto == null)
                {
                    return BadRequest(RoomNumberDto);
                }
                if (RoomNumberDto.RoomNo < 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                RoomNumber myRoomNumber = _mapper.Map<RoomNumber>(RoomNumberDto);

                await _db.CreateAsync(myRoomNumber);
                _response.Result = _mapper.Map<RoomNumberDto>(myRoomNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetRoomNumber", new { id = myRoomNumber.RoomNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteRoomNumber")]
        public async Task<ActionResult<APIResponse>> DeleteRoomNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Get RoomNumber Error with Id: " + id);
                    return BadRequest();
                }
                var RoomNumber = await _db.GetAsync(u => u.RoomNo == id);
                if (RoomNumber == null)
                {
                    return NotFound();
                }

                await _db.RemoveAsync(RoomNumber);
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

        [HttpPut("{id:int}", Name = "UpdateRoomNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateRoomNumber(int id, [FromBody] RoomNumberDto RoomNumberDto)
        {
            try
            {
                if (RoomNumberDto == null || id != RoomNumberDto.RoomNo)
                {
                    return BadRequest();
                }
                if (await _houseDb.GetAsync(u => u.Id == RoomNumberDto.HouseID) == null)
                {
                    ModelState.AddModelError("ErrorsMessages", "House ID is invalid!");
                    return BadRequest(_response);
                }
                RoomNumber myRoomNumber = _mapper.Map<RoomNumber>(RoomNumberDto);
                await _db.UpdateAsync(myRoomNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = myRoomNumber;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialRoomNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialRoomNumber(int id, JsonPatchDocument<RoomNumberDto> RoomNumberDto)
        {
            try
            {
                if (RoomNumberDto == null || id == 0)
                {
                    return BadRequest();
                }
                var RoomNumber = _db.GetAsync(u => u.RoomNo == id);
                RoomNumberDto myRoomNumberDto = _mapper.Map<RoomNumberDto>(RoomNumber);
                if (RoomNumber == null)
                {
                    return BadRequest();
                }

                RoomNumberDto.ApplyTo(myRoomNumberDto, ModelState);

                RoomNumber realRoomNumber = _mapper.Map<RoomNumber>(myRoomNumberDto);

                await _db.UpdateAsync(realRoomNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = realRoomNumber;
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
