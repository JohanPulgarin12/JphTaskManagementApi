using JphTaskManagementApi.Domain.Models;
using JphTaskManagementApi.Domain.Models.Dto;
using JphTaskManagementApi.Domain.Models.Farma.SP;
using JphTaskManagementApi.Domain.Models.TaskManagement.SP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JphTaskManagementApi.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class TasksController : BaseController
    {
        private readonly IConfiguration _configuration;
        public TasksController(IServiceProvider serviceProvider, IOptions<SectionConfiguration> configuration, IConfiguration configurationSettings)
            : base(serviceProvider, configuration)
        {
            _configuration = configurationSettings;
        }

        #region POST

        [HttpPost]
        [Route("PostTasks")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult<ResultOperation<bool>> PostTasks([FromBody] Tasks tasks)
        {
            try
            {
                var response = _tasksService.PostTasks(tasks);
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
        #endregion


        [HttpGet]
        [Route("GetTaskById/{id}")]
        [ProducesResponseType(200, Type = typeof(Tasks))]
        public ActionResult<Tasks> GetTaskById(int id)
        {
            try
            {
                var response = _tasksService.GetTaskById(id);

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
        [Route("UpdateTask")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult<ResultOperation<bool>> UpdateTask([FromBody] Tasks tasks)
        {
            try
            {
                var response = _tasksService.UpdateTask(tasks);
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
        [Route("DeleteTask")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public ActionResult<ResultOperation<bool>> DeleteTask([FromBody] DeleteTask id)
        {
            try
            {

                var response = _tasksService.DeleteTask(id.Id);
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
