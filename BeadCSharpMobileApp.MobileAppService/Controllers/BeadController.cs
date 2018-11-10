using System;
using Microsoft.AspNetCore.Mvc;

using BeadCSharpMobileApp.Models;

namespace BeadCSharpMobileApp.Controllers {
    [Route("api/[controller]")]
    public class BeadController : Controller {

        private readonly IBeadRepository ItemRepository;

        public BeadController(IBeadRepository itemRepository){
            ItemRepository = itemRepository;
        }

        [HttpGet]
        public IActionResult GetAllBeads(){
            return Ok(ItemRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Bead GetBead(string id){
            Bead bead = ItemRepository.Get(id);
            return bead;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Bead bead){
            try{
                if (bead == null || !ModelState.IsValid){
                    return BadRequest("Invalid State");
                }
                ItemRepository.Add(bead);
            }catch (Exception){
                return BadRequest("Error while creating");
            }
            return Ok(bead);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Bead bead){
            try{
                if (bead == null || !ModelState.IsValid){
                    return BadRequest("Invalid State");
                }
                ItemRepository.Update(bead);
            }catch (Exception){
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(string id){
            ItemRepository.Remove(id);
        }
    }
}
