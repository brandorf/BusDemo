﻿using System;

namespace BusDemo.WPF
{
    public class NameService
    {
        private static readonly string[] FirstNames = {"Big", "Blast", "Bolt", "Bridge", "Buck", "Buff", "Butch", "Crud", "Crunch", "Crush", "Dirk", "Fist", "Flint", "Gristle", "Hack", "Punch", "Reef", "Rip", "Slab", "Slate", "Smash", "Smoke", "Splint", "Stump", "Thick", "Trunk", "Zap"};
        private static readonly string[] LastNames = { "Beef.knob", "Big.plank", "Blast.body", "Blow.fist", "Bulk.head", "Butt.steak", "Chest.hair", "Dead.lift", "Drink.lots", "Fist.crunch", "Hard.back", "Hard.cheese", "Hard.peck", "Iron.stag", "Large-.Huge", "Man.muscle", "Plank.chest", "Punch.beef", "Rock.bone", "Rock.groin", "Run.fast", "Side.iron", "Slab.rock", "Slam.chest", "Squat-.Thrust", "Steak.face", "Thick.neck", "Thorn.body", "van. der Huge"};



        public string GetName()
        {
            var rnd = new Random();

            if (rnd.Next() % 999 == 666)
                return "Bob Johnson";


            return $"{FirstNames[rnd.Next() % FirstNames.Length]} {(rnd.Next() % 5 == 4? "Mc" : "")} {LastNames[rnd.Next() % FirstNames.Length]}";
        }
    }
}