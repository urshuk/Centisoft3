﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Centisoft3.Models;

namespace Centisoft3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksApiController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksApiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TasksApi
        [HttpGet]
        public IEnumerable<Models.Task> GetTasks()
        {
            return _context.Tasks;
        }

        // GET: api/TasksApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/TasksApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask([FromRoute] int id, [FromBody] Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TasksApi
        [HttpPost]
        public async Task<IActionResult> PostTask([FromBody] Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/TasksApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}