﻿using Fluid_ConsoleManager.src.Events.Interfaces;

namespace Fluid_ConsoleManager.src.Events
{
    public class ReadEvent : IEvent
    { 
        public static string Prompt() => Console.ReadLine(); 
    }

}
