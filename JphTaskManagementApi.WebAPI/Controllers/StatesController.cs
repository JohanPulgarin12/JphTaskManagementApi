using JphTaskManagementApi.Domain.Models;
using JphTaskManagementApi.Domain.Models.Dto;
using JphTaskManagementApi.Domain.Models.Farma.Core;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Dto;
using Newtonsoft.Json;

namespace JphTaskManagementApi.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class StatesController : BaseController
    {
        private readonly IConfiguration _configuration;
        public StatesController(IServiceProvider serviceProvider, IOptions<SectionConfiguration> configuration, IConfiguration configurationSettings)
            : base(serviceProvider, configuration)
        {
            _configuration = configurationSettings;
        }


        [HttpPost]
        [Route("PostState")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult<ResultOperation<bool>> PostState([FromBody] State state)
        {
            try
            {
                var response = _statesService.PostState(state);
                if (!response.stateOperation)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }

                if (!string.IsNullOrEmpty(response.MessageResult))
                {
                    return Ok(response.MessageResult);
                }

                return Ok(response.Result);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized($"Token inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }

        }


        [HttpGet]
        [Route("GetStates")]
        [ProducesResponseType(200, Type = typeof(List<State>))]
        public ActionResult<List<State>> GetStates()
        {
            try
            {
                var response = _statesService.GetStates();

                if (!response.stateOperation)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response.MessageExceptionTechnical);
                }

               
                if (!string.IsNullOrEmpty(response.MessageResult))
                {
                    return Ok(new List<State>());  
                }

                return Ok(response.Result);  
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized($"Token inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("GetStateById/{id}")]
        [ProducesResponseType(200, Type = typeof(State))]
        public ActionResult<State> GetStateById(int id)
        {
            try
            {
                var response = _statesService.GetStateById(id);

                if (!response.stateOperation)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response.MessageExceptionTechnical);
                }

                if (!string.IsNullOrEmpty(response.MessageResult))
                {
                    return NotFound(response.MessageResult);
                }

                return Ok(response.Result);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized($"Token inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }





        [HttpPatch]
        [Route("UpdateState")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult<ResultOperation<bool>> UpdateState([FromBody] State state)
        {
            try
            {
                var response = _statesService.UpdateState(state);
                if (!response.stateOperation)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }

                if (!string.IsNullOrEmpty(response.MessageResult))
                {
                    return Ok(response.MessageResult);
                }

                return Ok(response.Result);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized($"Token inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("DeleteState")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult<ResultOperation<bool>> DeleteState([FromBody] DeleteState id)
        {
            try
            {

                var response = _statesService.DeleteState(id.Id);
                if (!response.stateOperation)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }

                if (!string.IsNullOrEmpty(response.MessageResult))
                {
                    return Ok(response.MessageResult);
                }

                return Ok(response.Result);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized($"Token inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
