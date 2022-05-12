
using RimWorld;
using System;
using System.Linq;
using System.Reflection;
using Verse;

namespace SmartSpeed
{
    [StaticConstructorOnStartup]
    public class SmartSpeed
    {
        public enum Option
        {
            Slow,
            Normal,
            Fast,
            Half,
            Ignore
        }

        public static SmartSpeed.Option currSetting;

       

        static SmartSpeed()
        {
            SmartSpeed.currSetting = SmartSpeed.Option.Normal;
           
          
        }

       

      
    }
}