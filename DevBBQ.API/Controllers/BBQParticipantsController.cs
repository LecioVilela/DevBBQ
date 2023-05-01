using DevBBQ.Application.InputModels;
using DevBBQ.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevBBQ.API.Controllers
{
    [ApiController]
    [Route("api/BBQ/{id}/bbqparticipants")]
    public class BBQParticipantsController : ControllerBase
    {
        private readonly IBBQParticipantsService _participants;

        public BBQParticipantsController(IBBQParticipantsService participants)
        {
            _participants = participants;
        }

        /// <summary>
        /// Create a participant for the barbecue
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Insert the data of the participant and the Id of wich barbecue.
        /// ### Returns ###
        /// Status Code 201 = Created
        /// </remarks>
        /// <param name="id">Barbecue</param>
        /// <param name="newBBQParticipantsInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(int id, [FromBody] NewBBQParticipantsInputModel newBBQParticipantsInputModel)
        {
            var bbqIdParticipants = _participants.Create(id, newBBQParticipantsInputModel);

            return CreatedAtAction(nameof(GetById), new { id }, bbqIdParticipants);

            // Return 201 as the payload from the response body.
        }

        /// <summary>
        /// Get information of a participant for the barbecue
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Choose the participant Id that you'd like to see.
        /// ### Returns ###
        /// Status Code 200 = Ok
        /// </remarks>
        /// <param name="id">Barbecue</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var bbqparticipants = _participants.GetById(id);

            if (bbqparticipants is null)
            {
                return NotFound();
            }

            return Ok(bbqparticipants);
        }

        /// <summary>
        /// Delete a participant for the barbecue
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Choose the participant Id that you'd like to remove.
        /// ### Returns ###
        /// Status Code 204 = NoContent
        /// </remarks>
        /// <param name="id">Barbecue</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            _participants.Delete(id);

            return NoContent();
        }
    }
}