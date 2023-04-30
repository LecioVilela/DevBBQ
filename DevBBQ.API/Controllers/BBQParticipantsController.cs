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
        public async Task<IActionResult> Post([FromBody] NewBBQParticipantsInputModel newBBQParticipantsInputModel)
        {
            var id = _participants.Create(newBBQParticipantsInputModel);

            return CreatedAtAction(nameof(GetById), new { id }, newBBQParticipantsInputModel);

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
    }
}