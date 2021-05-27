using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using five_star.server.Interfaces;
using five_star.server.Models;
using five_star.server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace five_star.server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase, IController<Review>
    {
        private readonly ReviewsService _service;

        public ReviewsController(ReviewsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Review>> GetAll()
        {
            try
            {
                List<Review> reviews = _service.GetAll();
                return reviews;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")]
        public ActionResult<Review> GetById(int id)
        {
            throw new NotImplementedException();
        }



        [HttpPost]
        public Task<ActionResult<Review>> Create([FromBody] Review newReview)
        {
            throw new NotImplementedException();
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Review>> Update([FromBody] Review edit, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                edit.Id = id;
                Review update = _service.Update(edit, userInfo.Id);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                // TODO[epic=Auth] Get the user info to set the creatorID
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // safety to make sure an account exists for that user before DELETE-ing stuff.
                _service.Delete(id, userInfo.Id);
                return Ok("Successfully Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}