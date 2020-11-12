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
    [Route("api/InventoryItem")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly InventoryItemServices _inventoryItemServices;

        public InventoryItemController(InventoryItemServices service)
        {
            this._inventoryItemServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _inventoryItemServices.AddInventoryItem(inventoryItem);
                return CreatedAtAction("AddInventoryItem", inventoryItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _inventoryItemServices.UpdateInventoryItem(inventoryItem);
                return CreatedAtAction("UpdateInventoryItem", inventoryItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _inventoryItemServices.DeleteInventoryItem(inventoryItem);
                return CreatedAtAction("DeleteInventoryItem", inventoryItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{locationId}/{productId}")]
        [Produces("application/json")]
        public IActionResult GetInventoryItemByLocationIdProductId(int locationId, int productId)
        {
            try
            {
                return Ok(_inventoryItemServices.GetInventoryItemByLocationIdProductId(locationId, productId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetAllInventoryItemsByLocationId(int locationId)
        {
            try
            {
                return Ok(_inventoryItemServices.GetAllInventoryItemsByLocationId(locationId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
