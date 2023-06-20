using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.Cqrs.CategoriesAI.Commands;
using Application.Cqrs.CategoriesAI.Queries;
using Application.Cqrs.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.IADirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "CategoriesAI")]
    //[Authorize]
    public class CategoriesAIController : ApiControllerBase
    {
        /// <summary>
        /// Agrega una nueva categoria en la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCategoriesAI([FromForm] PostCategoriesAICommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Trae todos las categorias de la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAI([FromQuery] GetCategoriesAIQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Actualiza las categorias
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> UpdateCategoriesAI([FromForm] PutCategoriesAICommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Eliminar las categorias
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategoriesAI(int Id)
        {
            return Ok(await Mediator.Send(new DeleteCategoriesAICommand() { Id = Id }));
        }

        /// <summary>
        /// OBtener categoria por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoriesAIById(int Id)
        {
            return Ok(await Mediator.Send(new GetCategoriesAIByIdQuery() { Id = Id }));
        }
        
    }
}
