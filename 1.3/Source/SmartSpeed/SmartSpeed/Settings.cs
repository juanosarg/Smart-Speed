using UnityEngine;
using Verse;
using System.Collections.Generic;

namespace SmartSpeed.Detouring
{
    public class Settings : ModSettings
    {
        //Variables used later on
        public static float onespeed = 1f;
        public static float twospeed = 3f;
        public static float threespeed = 5f;
        public static float fourspeed = 6f;

       
        //Saving the Data to an .xml for future retreval
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref onespeed, "onespeed", 1f);
            Scribe_Values.Look(ref twospeed, "twospeed", 3f);
            Scribe_Values.Look(ref threespeed, "threespeed", 5f);
            Scribe_Values.Look(ref fourspeed, "fourspeed", 6f);
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
            Settings.onespeed = listingStandard.Slider(Settings.onespeed, .1f, 4f);
            listingStandard.Label("Settings.twospeed".Translate(Settings.twospeed.SecondsToTicks()));
            Settings.twospeed = listingStandard.Slider(Settings.twospeed, 1f, 6f);
            listingStandard.Label("Settings.threespeed".Translate(Settings.threespeed.SecondsToTicks()));
            Settings.threespeed = listingStandard.Slider(Settings.threespeed, 3f, 10f);
            listingStandard.Label("Settings.fourspeed".Translate(Settings.fourspeed.SecondsToTicks().ToString()));
            Settings.fourspeed = listingStandard.Slider(Settings.fourspeed, 5f, 15f);
            listingStandard.End();
            base.DoSettingsWindowContents(canvas);
        }
        //displayname
        public override string SettingsCategory() => "Smart Speed";
    }
}
