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
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices service)
        {
            this._productServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productServices.AddProduct(product);
                return CreatedAtAction("AddProduct", product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                _productServices.UpdateProduct(product);
                return CreatedAtAction("UpdateProduct", product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                _productServices.DeleteProduct(product);
                return CreatedAtAction("DeleteProduct", product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{productId}")]
        [Produces("application/json")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(_productServices.GetProductById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{productName}")]
        [Produces("application/json")]
        public IActionResult GetProductByName(string name)
        {
            try
            {
                return Ok(_productServices.GetProductByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productServices.GetAllProducts());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
