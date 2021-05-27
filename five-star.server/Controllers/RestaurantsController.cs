using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using five_star.server.Interfaces;
using five_star.server.Models;
using five_star.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace five_star.server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase, IController<Restaurant>
    {
        private readonly RestaurantsService _service;

        public RestaurantsController(RestaurantsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Restaurant>> GetAll()
        {
            try
            {
                List<Restaurant> restaurants = _service.GetAll();
                return Ok(restaurants);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetById(int id)
        {
            try
            {
                Restaurant restaurant = _service.GetById(id);
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Restaurant>> Create([FromBody] Restaurant data)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                data.CreatorId = userInfo.Id;
                Restaurant newRestaurant = _service.Create(data);
                newRestaurant.Creator = userInfo;
                return Ok(newRestaurant);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Restaurant>> Update([FromBody] Restaurant edit, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                edit.Id = id;
                Restaurant update = _service.Update(edit, userInfo.Id);
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