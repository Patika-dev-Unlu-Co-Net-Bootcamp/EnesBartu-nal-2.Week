using AutoMapper;
using ManagerApi.Context;
using ManagerApi.Entities;
using ManagerApi.Models;
using ManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ManagerDbContext db;
        private readonly IMapper mapper;
        private readonly ServiceBase<Team> serviceBase;
        private readonly IService<Team, TeamViewModel> service;

        public TeamController(ManagerDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
            serviceBase = new ServiceBase<Team>(db);
            service = new TeamService(serviceBase, mapper);
        }


        // GET: api/<TeamController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = service.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<TeamController>?<id>=2
        [HttpGet]
        public IActionResult GetQ([FromQuery] int id)
        {
            try
            {
                var model = service.GetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TeamController>
        [HttpPost]
        public IActionResult Post([FromBody] TeamViewModel model)
        {
            try
            {
                service.Add(model);
                service.SaveChanges();
                return StatusCode(201, new { message = $"{model.Name} oluşturuldu!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TeamViewModel model)
        {
            try
            {
                model.Id = id;
                service.Update(model);
                service.SaveChanges();
                return Ok(new { message = "İşlem Onaylandı!" });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<TeamController>?<id>=2
        [HttpPut]
        public IActionResult PutQ([FromQuery] int id,[FromBody] TeamViewModel model)
        {
            try
            {
                model.Id = id;
                service.Update(model);
                service.SaveChanges();
                return Ok(new { message = "İşlem Onaylandı!" });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                service.SaveChanges();
                return Ok(new { message = "Takım silindi" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                          }
        }
    }
}
