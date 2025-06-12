using RimWorld;
using UnityEngine;
using Verse;


namespace SmartSpeed
{



    public class SmartSpeed_Mod : Mod
    {


        public SmartSpeed_Mod(ModContentPack content) : base(content)
        {
            GetSettings<SmartSpeed_Settings>();
        }
        public override string SettingsCategory()
        {

            return "Smart Speed";



        }



        public override void DoSettingsWindowContents(Rect inRect)
        {
            SmartSpeed_Settings.DoWindowContents(inRect);
        }
    }


}
