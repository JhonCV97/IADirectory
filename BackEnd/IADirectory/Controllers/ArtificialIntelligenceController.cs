using Application.Cqrs.ArtificialIntelligence.Commands;
using Application.Cqrs.ArtificialIntelligence.Queries;
using Application.Cqrs.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Api.IADirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ArtificialIntelligence")]
    //[Authorize]
    public class ArtificialIntelligenceController : ApiControllerBase
    {
        /// <summary>
        /// Agrega una nueva inteligencia Artificial en la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostArtificialIntelligence([FromForm] PostArtificialIntelligenceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Trae todas las inteligencias Artificiales de la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetArtificialIntelligence([FromQuery] GetArtificialIntelligenceQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Actualiza las inteligencias artificiales
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPut]
        public async Task<IActionResult> UpdateArtificialIntelligence([FromForm] PutArtificialIntelligenceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Eliminar inteligencia artificial
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtificialIntelligence(int Id)
        {
            return Ok(await Mediator.Send(new DeleteArtificialIntelligenceCommand() { Id = Id}));
        }

        /// <summary>
        /// OBtener inteligencia artificial por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtificialIntelligenceById(int Id)
        {
            return Ok(await Mediator.Send(new GetArtificialIntelligenceQueryById() { Id = Id }));
        }

    }
}
