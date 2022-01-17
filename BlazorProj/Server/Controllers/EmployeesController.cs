﻿using BlazorProj.Server.Models;
using BlazorProj.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProj.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Chyba při získávání dat z databáze");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Chyba při získávání dat z databáze");
            }
        }

        [HttpPost]        
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
               if(employee == null)
                    return BadRequest();

               var emp = employeeRepository.GetEmployeeByEmail(employee.Email);
                if(emp == null)
                {
                    ModelState.AddModelError("Email", "Tento email je již používán");
                    return BadRequest(ModelState);
                }

               var createdEmployee = await employeeRepository.AddEmployee(employee);

               return CreatedAtAction(nameof(GetEmployee),
                   new {id = createdEmployee.EmployeeId},createdEmployee);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Chyba při získávání dat z databáze");
            }
        }





    }
}
