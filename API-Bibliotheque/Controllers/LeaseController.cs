﻿using API_Bibliotheque.Mapper;
using API_Bibliotheque.Models.Post;
using Commun_Bibliotheque.Repositories;
using Microsoft.AspNetCore.Mvc;
using BLL = BLL_Bibliotheque.Entities;

namespace API_Bibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaseController : ControllerBase
    {
        private ILeaseRepository<BLL.Lease> _leaseService;
        public LeaseController(ILeaseRepository<BLL.Lease> leaseService)
        {
            _leaseService = leaseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_leaseService.Get().Select(l => l.ToAPI()));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var lease = _leaseService.Get(id);
            if (lease == null)
            {
                return NotFound();
            }
            return Ok(lease.ToAPIDetails());
        }

        [HttpPost]
        public IActionResult Post([FromBody] LeasePost lease)
        {
            try
            {
                if (lease == null)
                {
                    return BadRequest();
                }
                _leaseService.Insert(lease.ToBLL());
                return CreatedAtAction(nameof(Get), lease);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id)
        {
            _leaseService.Update(id, new BLL.Lease { ReturnDate = DateTime.Now});
            return NoContent();
        }
    }
}
