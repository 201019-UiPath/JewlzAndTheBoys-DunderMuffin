﻿using System;
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
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;

        public EmployeeController(EmployeeServices service)
        {
            this._employeeServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                _employeeServices.AddEmployee(employee);
                return CreatedAtAction("AddEmployee", employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                _employeeServices.UpdateEmployee(employee);
                return CreatedAtAction("UpdateEmployee", employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteEmployee(Employee employee)
        {
            try
            {
                _employeeServices.DeleteEmployee(employee);
                return CreatedAtAction("DeleteEmployee", employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // [HttpGet("get/{employeeID}")]
        // [Produces("application/json")]
        // public IActionResult GetEmployeeById(int employeeID)
        // {
        //    try
        //    {
        //        return Ok(_employeeServices.GetEmployeeById(employeeID));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500);
        //    }
        // }

        [HttpGet("get/{employeeEmail}")]
        [Produces("application/json")]
        public IActionResult GetEmployeeByEmail(string employeeEmail)
        {
            try
            {
                return Ok(_employeeServices.GetEmployeeByEmail(employeeEmail));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_employeeServices.GetAllEmployees());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
