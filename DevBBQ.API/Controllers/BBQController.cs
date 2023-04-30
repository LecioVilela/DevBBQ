using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBBQ.Application.InputModels;
using DevBBQ.Application.Services.Interfaces;
using DevBBQ.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevBBQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BBQController : ControllerBase
    {
        private readonly IBBQService _bbqService;

        public BBQController(IBBQService bbqService)
        {
            _bbqService = bbqService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string query)
        {
            var bbq = _bbqService.GetAll(query);

            return Ok(bbq);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var bbq = _bbqService.GetById(id);

            if (bbq is null)
            {
                return NotFound();
            }

            return Ok(bbq);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] NewBBQInputModel bbq)
        {
            var id = _bbqService.Create(bbq);

            return CreatedAtAction(nameof(GetById), new { id }, bbq);
            // Return 201 as the payload from the response body.
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateBBQInputModel bbq)
        {
            _bbqService.Update(bbq);

            return NoContent();
        }

        /// <summary>
        /// Delete a barbecue from database
        /// </summary>
        /// <remarks>
        /// 
        /// ### Process ###
        ///   - Choose the ID you want to delete
        ///
        /// ### Returns ###
        /// Status Code 204 = No Content;
        /// </remarks>
        /// <param name="id">Barbecue IDs</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            _bbqService.Delete(id);

            return NoContent();
        }

        [HttpGet("{id}/bbq/participants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<BBQ> GetCompleteBBQ(int id)
        {
            var bbqAll = _bbqService.GetCompleteBBQ(id);

            if (bbqAll is null)
            {
                return NotFound();
            }

            var bbq = _bbqService.GetById(bbqAll.Id);
            if (bbq is null)
            {
                return NotFound();
            }

            var participants = bbqAll.Participants.FirstOrDefault(b => b.Id == id);
            if (participants is null)
            {
                return NotFound();
            }

            return Ok(participants);
        }
    }
}