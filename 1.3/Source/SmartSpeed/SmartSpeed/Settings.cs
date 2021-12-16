using UnityEngine;
using Verse;
using System.Collections.Generic;

namespace SmartSpeed.Detouring
{
    public class Settings : ModSettings
    {
        //Default Variables used later on
        public static float onespeed = 1f;
        public static float twospeed = 3f;
        public static float threespeed = 6f;
        public static float fourspeed = 15f;
        public static bool Nomapselected = true;
        public static bool Nothinghappening = true;


        //Saving the Data to an .xml for future retreval
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref onespeed, "onespeed", 1f);
            Scribe_Values.Look(ref twospeed, "twospeed", 3f);
            Scribe_Values.Look(ref threespeed, "threespeed", 6f);
            Scribe_Values.Look(ref fourspeed, "fourspeed", 15f);
            Scribe_Values.Look(ref Nomapselected, "Nomapselected", true);
            Scribe_Values.Look(ref Nothinghappening, "Nothinghappening", true);
        }



    }
    public class SmartSpeed : Mod
    {
        Settings settings;
        public SmartSpeed(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<Settings>();

        }
       //The GUI
        public override void DoSettingsWindowContents(Rect canvas)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.ColumnWidth = canvas.width;
            listingStandard.Begin(canvas);
            listingStandard.Label("Settings.onespeed".Translate(Settings.onespeed.SecondsToTicks()));
            Settings.onespeed = listingStandard.Slider(Settings.onespeed, .1f, 2f);
            listingStandard.Label("Settings.twospeed".Translate(Settings.twospeed.SecondsToTicks()));
            Settings.twospeed = listingStandard.Slider(Settings.twospeed, 1f, 6f);
            listingStandard.Label("Settings.threespeed".Translate(Settings.threespeed.SecondsToTicks()));
            Settings.threespeed = listingStandard.Slider(Settings.threespeed, 3f, 10f);
            listingStandard.Label("Settings.fourspeed".Translate(Settings.fourspeed.SecondsToTicks().ToString()));
            Settings.fourspeed = listingStandard.Slider(Settings.fourspeed, 5f, 20f);
            listingStandard.CheckboxLabeled("Speed up map if one is not active", ref Settings.Nomapselected, "This will speed up the map significantly on faster speeds when one is not selected");
            listingStandard.CheckboxLabeled("Speed up map if nothing is happening", ref Settings.Nothinghappening, "This will speed up the map significantly on faster speeds  when nothing is happening in game");
            listingStandard.End();
            base.DoSettingsWindowContents(canvas);
        }
        //displayname
        public override string SettingsCategory() => "Smart Speed";
    }
}
