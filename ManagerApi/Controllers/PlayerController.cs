using AutoMapper;
using ManagerApi.Context;
using ManagerApi.Entities;
using ManagerApi.Models;
using ManagerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Controllers
{
    [Route("api/[controller]s/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ManagerDbContext db;
        private readonly IMapper mapper;
        private readonly ServiceBase<Player> serviceBase;
        private readonly IService<Player, PlayerViewModel> service;

        public PlayerController(ManagerDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
            serviceBase = new ServiceBase<Player>(db);
            service = new PlayerService(serviceBase, mapper);
        }

        // GET: api/<PlayerController>
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

        // GET api/<PlayerController>/5
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
        // GET api/<PlayerController>?<id>=2
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

        // POST api/<PlayerController>
        [HttpPost]
        public IActionResult Post([FromBody] PlayerViewModel model)
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

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlayerViewModel model)
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

        // PUT api/<PlayerController>?<id>=2
        [HttpPut]
        public IActionResult PutQ([FromQuery] int id, [FromBody] PlayerViewModel model)
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

        // DELETE api/<PlayerController>/5
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
