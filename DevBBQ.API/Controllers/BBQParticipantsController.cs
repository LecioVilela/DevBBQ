using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(int id, [FromBody] NewBBQParticipantsInputModel newBBQParticipantsInputModel)
        {
            var bbqIdParticipants = _participants.Create(id, newBBQParticipantsInputModel);

            return CreatedAtAction(nameof(GetById), new { id }, bbqIdParticipants);

            // Return 201 as the payload from the response body.
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var bbqparticipants = _participants.GetById(id);

            if (bbqparticipants is null)
            {
                return NotFound();
            }

            return Ok(bbqparticipants);
        }

        [HttpGet("totalparticipants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string query)
        {
            var participantsViewModels = _participants.GetAll(query);

            return Ok(participantsViewModels);
        }
    }
}