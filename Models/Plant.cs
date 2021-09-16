using System;
using System.Threading.Tasks;

namespace SVPlants.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public int ThirstLevel { get; set; } //Thirst Levels: 1: full, (0-30 second mark) 2: almost full, (30secs-6hours)  3: Thirsty (6 hours and beyond)
        public string Name { get; set; } //might not need this one 
        public bool NeedWatering { get; set; } //6 Hours since last watering and it needs watering 
        public bool CanWater {get; set;} //Can only water 30 seconds after last watering
        public bool gettingWatered {get; set;} //tells u if gettingWatered or not

        // public static async Task WaterTime()

    };

    // a plant takes 10 seconds to water.

};

// R1 As a user, I want to see a list of plants on a web page, as well as their watering status

// R2 As a user, I want to start and stop watering of a plant. A plant takes 10 seconds to
// water.

// R3 The system should support watering multiple plants at the same time.

// R4 Plants need to rest from watering, so as a User, I should not be able to water the plant
// again within 30 seconds of the last watering session.

// R5 As a user, I should be visually alerted if a plant hasn’t been watered for more than 6
// hours.