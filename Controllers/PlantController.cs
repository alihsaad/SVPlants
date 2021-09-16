using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SVPlants.Models;
using SVPlants.Services;

namespace SVPlants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantController : ControllerBase
    {
        public PlantController()
        {
        }

        [HttpGet] //gets all plants
        public ActionResult<List<Plant>> GetAll() =>
            PlantService.GetAll();

        [HttpGet("{id}")] //gets one plant based on id given 
        public ActionResult<Plant> Get(int id)
        {
            var plant = PlantService.Get(id);

            if(plant == null)
                return NotFound();

            return plant;
        }


        // [HttpPost] //creates a plant (might change it to something else )
        // public IActionResult Create(Plant plant)
        // {            
        //     PlantService.Add(plant);
        //     return CreatedAtAction(nameof(Create), new { id = plant.Id }, plant);
        // }


        [HttpPost] //POST  //Waters a plant (might change it to something else )
        public IActionResult Create(Plant plant)
        {
            for (int i = 0; i < 5; i++) {
                PlantService.Water(plant); 
            }
            return NoContent();

        }




        // [HttpPut("{id}")] //updates a plant 
        // public IActionResult Update(int id, Plant plant)
        // {
        //     if (id != plant.Id)
        //         return BadRequest();

        //     var existingPlant = PlantService.Get(id);
        //     if(existingPlant is null)
        //         return NotFound();

        //     PlantService.Update(plant);           

        //     return NoContent();
        // }







        [HttpPut("{id}")] //updates a plant 
        public IActionResult Update(int id, Plant plant)
        {
             if (id != plant.Id)
                return BadRequest();

            var existingPlant = PlantService.Get(id);
            if(existingPlant is null)
                return NotFound();

            PlantService.Water(plant);           

            return NoContent();
        }

        [HttpDelete("{id}")] //deletes a plant 
        public IActionResult Delete(int id)
        {
            var plant = PlantService.Get(id);

            if (plant is null)
                return NotFound();

            PlantService.Delete(id);

            return NoContent();
        }





    }
}