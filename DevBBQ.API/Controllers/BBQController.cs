using DevBBQ.Application.InputModels;
using DevBBQ.Application.Services.Interfaces;
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

        /// <summary>
        /// Return all barbecues from database
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Input the string query for the result.
        /// ### Returns ###
        /// Status Code 200 = Ok
        /// </remarks>
        /// <param name="query">Barbecue</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string query)
        {
            var bbq = _bbqService.GetAll(query);

            return Ok(bbq);
        }

        /// <summary>
        /// Return a barbecue from database by id
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Choose the barbecue id that you want to see.
        /// ### Returns ###
        /// Status Code 200 = Ok
        /// </remarks>
        /// <param name="id">Barbecue</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var bbqAll = _bbqService.GetCompleteBBQ(id);

            if (bbqAll is null)
            {
                return NotFound();
            }

            return Ok(bbqAll);
        }

        /// <summary>
        /// Create a barbecue
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Insert all the information you will need.
        /// ### Returns ###
        /// Status Code 201 = Created
        /// </remarks>
        /// <param name="bbq">Barbecue</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] NewBBQInputModel bbq)
        {
            var id = _bbqService.Create(bbq);

            return CreatedAtAction(nameof(GetById), new { id }, bbq);
            // Return 201 as the payload from the response body.
        }

        /// <summary>
        /// Update a barbecue from database
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Choose the ID you want to update.
        /// ### Returns ###
        /// Status Code 204 = No Content
        /// </remarks>
        /// <param name="bbq">Barbecue</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update([FromBody] UpdateBBQInputModel bbq)
        {
            _bbqService.Update(bbq);

            return NoContent();
        }

        /// <summary>
        /// Delete a barbecue from database
        /// </summary>
        /// <remarks>
        /// ### Process ###
        ///   - Choose the ID you want to delete.
        /// ### Returns ###
        /// Status Code 204 = No Content
        /// </remarks>
        /// <param name="id">Barbecue IDs</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            _bbqService.Delete(id);

            return NoContent();
        }
    }
}