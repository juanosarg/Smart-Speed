using RimWorld;
using UnityEngine;
using Verse;
using System;


namespace SmartSpeed
{


    public class SmartSpeed_Settings : ModSettings

    {



        public static float normalSpeed = normalSpeedBase;
        public const float normalSpeedBase = 1;
        public const float maxNormalSpeed = 3;

        public static float fastSpeed = fastSpeedBase;
        public const float fastSpeedBase = 3;
        public const float maxFastSpeed = 6;

        public static float superfastSpeed = superfastSpeedBase;
        public const float superfastSpeedBase = 6;
        public const float maxSuperfasSpeed = 15;

        public static float ultrafastSpeed = ultrafastSpeedBase;
        public const float ultrafastSpeedBase = 15;
        public const float maxUltrafastSpeed = 200;

        public static Option currSetting = Option.Normal;






        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref normalSpeed, "normalSpeed", normalSpeedBase, true);
            Scribe_Values.Look(ref fastSpeed, "fastSpeed", fastSpeedBase, true);
            Scribe_Values.Look(ref superfastSpeed, "superfastSpeed", superfastSpeedBase, true);
            Scribe_Values.Look(ref ultrafastSpeed, "ultrafastSpeed", ultrafastSpeedBase, true);
            Scribe_Values.Look(ref currSetting, "currSetting", Option.Normal, true);




        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();


            ls.Begin(inRect);

            var normalSpeedLabel = ls.LabelPlusButton("SS_normalSpeed".Translate() + ": " + normalSpeed, "SS_normalSpeedTooltip".Translate());
            normalSpeed = (float)Math.Round(ls.Slider(normalSpeed, normalSpeedBase, maxNormalSpeed), 2);

            if (ls.Settings_Button("SS_Reset".Translate(), new Rect(0f, normalSpeedLabel.position.y + 35, 250f, 29f)))
            {
                normalSpeed = normalSpeedBase;
            }

            var fastSpeedLabel = ls.LabelPlusButton("SS_fastSpeed".Translate() + ": " + fastSpeed, "SS_fastSpeedTooltip".Translate());
            fastSpeed = (float)Math.Round(ls.Slider(fastSpeed, fastSpeedBase, maxFastSpeed), 2);

            if (ls.Settings_Button("SS_Reset".Translate(), new Rect(0f, fastSpeedLabel.position.y + 35, 250f, 29f)))
            {
                fastSpeed = fastSpeedBase;
            }

            var superfastSpeedLabel = ls.LabelPlusButton("SS_superfastSpeed".Translate() + ": " + superfastSpeed, "SS_superfastSpeedTooltip".Translate());
            superfastSpeed = (float)Math.Round(ls.Slider(superfastSpeed, superfastSpeedBase, maxSuperfasSpeed), 2);

            if (ls.Settings_Button("SS_Reset".Translate(), new Rect(0f, superfastSpeedLabel.position.y + 35, 250f, 29f)))
            {
                superfastSpeed = superfastSpeedBase;
            }

            var ultrafastSpeedLabel = ls.LabelPlusButton("SS_ultrafastSpeed".Translate() + ": " + ultrafastSpeed, "SS_ultrafastSpeedTooltip".Translate());
            ultrafastSpeed = (float)Math.Round(ls.Slider(ultrafastSpeed, ultrafastSpeedBase, maxUltrafastSpeed), 1);

            if (ls.Settings_Button("SS_Reset".Translate(), new Rect(0f, ultrafastSpeedLabel.position.y + 35, 250f, 29f)))
            {
                ultrafastSpeed = ultrafastSpeedBase;
            }



            ls.End();
        }



    }










}
