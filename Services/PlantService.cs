using SVPlants.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SVPlants.Services
{
    public static class PlantService
    {
        static List<Plant> Plants { get; }
        static int nextId = 3;
        private static readonly string[] PlantNames = new[] 
        {
        "Snake Plant Laurentii", "Dracaena Gold Star", "Rubber Tree", "Aloe Vera", 
        "Monstera Deliciosa", "Pothos", "ZZ Plant", "Spider Plant"
        };
        static PlantService()
        {
            var rng = new Random();
            Plants= new List<Plant>
                {
                new Plant { Id = 1, Name = PlantNames[rng.Next(PlantNames.Length)], NeedWatering = false,   CanWater = false, ThirstLevel = 1},
                new Plant { Id = 2, Name = PlantNames[rng.Next(PlantNames.Length)], NeedWatering = true,  CanWater = true, ThirstLevel = 4  },
                new Plant { Id = 3, Name = PlantNames[rng.Next(PlantNames.Length)], NeedWatering = false,   CanWater = true },
                new Plant { Id = 4, Name = PlantNames[rng.Next(PlantNames.Length)], NeedWatering = true,  CanWater = true, ThirstLevel = 4 },
                new Plant { Id = 5, Name = PlantNames[rng.Next(PlantNames.Length)], NeedWatering = true,  CanWater = true, ThirstLevel = 3 }
            };
           
        }
        public static List<Plant> GetAll() => Plants;

        public static Plant Get(int id) => Plants.FirstOrDefault(p => p.Id == id);

        public static void Add(Plant plant)
        {
            plant.Id = nextId++;
            Plants.Add(plant);
        }


        public static void Water(Plant plant) //lets water this plant! (probably going to be async)
        {
            var index = Plants.FindIndex(p => p.Id == plant.Id); //find our plant from our list of plants 
            if(index == -1)
                return; 

            Plant wateredPlant =  Plants[index]; //lets grab our plant 
            bool waterTime = wateredPlant.gettingWatered; //
            wateredPlant.gettingWatered = !wateredPlant.gettingWatered;  //start/stop the watering!
            Plants[index] = wateredPlant; //put it back!

            if (waterTime){
            //waterTimer(plant);
            }
        }

        public static void Delete(int id)
        {
            var plant = Get(id);
            if(plant is null)
                return;

            Plants.Remove(plant);
        }

        public static void Update(Plant plant)
        {
            var index = Plants.FindIndex(p => p.Id == plant.Id);
            if(index == -1)
                return;

            Plants[index] = plant;
        }
    }
}




// function to get thirstlevel of a particular plant (using id) 
// function to set thirstlevel 
// function to get NeedWatering Status


// function to Water/Stop (put: updating waterstatus) 
// function to stop watering 


// function to set 