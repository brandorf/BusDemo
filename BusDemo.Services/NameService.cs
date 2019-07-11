using System;

namespace BusDemo.Services
{
    public class NameService
    {
        private static readonly string[] FirstNames = {"Big", "Blast", "Bolt", "Bridge", "Buck", "Buff", "Butch", "Crud", "Crunch", "Crush", "Dirk", "Fist", "Flint", "Gristle", "Hack", "Punch", "Reef", "Rip", "Slab", "Slate", "Smash", "Smoke", "Splint", "Stump", "Thick", "Trunk", "Zap"};
        private static readonly string[] LastNames = { "Beefknob", "Bigplank", "Blastbody", "Blowfist", "Bulkhead", "Buttsteak", "Chesthair", "Deadlift", "Drinklots", "Fistcrunch", "Hardback", "Hardcheese", "Hardpeck", "Ironstag", "Large-Huge", "Manmuscle", "Plankchest", "Punchbeef", "Rockbone", "Rockgroin", "Runfast", "Sideiron", "Slabrock", "Slamchest", "Squat-Thrust", "Steakface", "Thickneck", "Thornbody", "vander Huge"};



        public string GetName()
        {
            var rnd = new Random();

            if (rnd.Next() % 999 == 666)
                return "Bob Johnson";


            return $"{FirstNames[rnd.Next() % FirstNames.Length]} {(rnd.Next() % 5 == 4? "Mc" : "")} {LastNames[rnd.Next() % FirstNames.Length]}";
        }
    }
}