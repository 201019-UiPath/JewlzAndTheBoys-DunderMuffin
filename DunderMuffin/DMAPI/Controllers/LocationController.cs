using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DMDB;
using DMDB.Models;
using DMLib;

namespace DMAPI.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationServices _locationServices;

        public LocationController(LocationServices service)
        {
            this._locationServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLocation(Location location)
        {
            try
            {
                _locationServices.AddLocation(location);
                return CreatedAtAction("AddLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLocation(Location location)
        {
            try
            {
                _locationServices.UpdateLocation(location);
                return CreatedAtAction("UpdateLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLocation(Location location)
        {
            try
            {
                _locationServices.DeleteLocation(location);
                return CreatedAtAction("DeleteLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetLocationById(int id)
        {
            try
            {
                return Ok(_locationServices.GetLocationById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{locationName}")]
        [Produces("application/json")]
        public IActionResult GetLocationByName(string name)
        {
            try
            {
                return Ok(_locationServices.GetLocationByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(_locationServices.GetAllLocations());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
