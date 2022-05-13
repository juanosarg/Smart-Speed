using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

using UnityEngine;




namespace SmartSpeed
{

    [HarmonyPatch(typeof(TimeControls))]
    [HarmonyPatch("DoTimeControlsGUI")]
    public static class SmartSpeed_TimeControls_DoTimeControlsGUI_Transpiler
    {

        public static bool Yes() { return true; }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {


            var codes = instructions.ToList();
            bool found = false;
            int instructionNumber = 0;
            FieldInfo buttons = AccessTools.Field(typeof(TexButton), "SpeedButtonTextures");
            FieldInfo newButtons = AccessTools.Field(typeof(AlternateButtons), "SpeedButtonTextures");
            MethodInfo getdevmode = AccessTools.Method(typeof(Prefs), "get_DevMode");
          

            for (var i = 0; i < codes.Count; i++)
            {

                var code = codes[i];

                if (code.opcode == OpCodes.Ldloc_3 &&!found)
                {
                    found = true;
                    instructionNumber = i;
                    yield return new CodeInstruction(OpCodes.Nop);
                }else
                if(found && (i== instructionNumber + 1|| i == instructionNumber + 2))
                {
                    yield return new CodeInstruction(OpCodes.Nop);
                }else
                if (code.opcode == OpCodes.Ldsfld && code.LoadsField(buttons))
                {
                    
                    yield return new CodeInstruction(OpCodes.Ldsfld,newButtons);
                }
                else
                if (code.opcode == OpCodes.Call && code.Calls(getdevmode))
                {

                    CodeInstruction newcode = new CodeInstruction(opcode: OpCodes.Call, AccessTools.Method(typeof(SmartSpeed_TimeControls_DoTimeControlsGUI_Transpiler), nameof(Yes)));
                    newcode.labels = code.labels;
                    yield return newcode;


                }
                else
                {
                    yield return code;
                }


            }


        }

       

        
    }
    [HarmonyPatch(typeof(TimeControls))]
    [HarmonyPatch("DoTimeControlsGUI")]
    public static class SmartSpeed_TimeControls_DoTimeControlsGUI_Prefix
    {
        [HarmonyPrefix]
        static void CallGUIConfig(ref Rect timerRect)
        {
            DoConfigGUI(timerRect);
            timerRect.x -= 14f;
            FieldInfo size = AccessTools.Field(typeof(TimeControls), "TimeButSize");
            size.SetValue(typeof(TimeControls), new Vector2(28, 24f));

           

        }



        public static void DoConfigGUI(Rect timeRect)
        {
            if (Mouse.IsOver(timeRect) && (Event.current.button == 1))
                if (Event.current.type == EventType.MouseDown)
                {
                    var floatOptionList = new List<FloatMenuOption>();

                    floatOptionList.Add(new FloatMenuOption(string.Format("SS_Slow".Translate() + " {0}", SmartSpeed_Settings.currSetting == SmartSpeed.Option.Slow ? "V" : ""), delegate { SmartSpeed_Settings.currSetting = SmartSpeed.Option.Slow; }));
                    floatOptionList.Add(new FloatMenuOption(string.Format("SS_Normal".Translate() + " {0}", SmartSpeed_Settings.currSetting == SmartSpeed.Option.Normal ? "V" : ""), delegate { SmartSpeed_Settings.currSetting = SmartSpeed.Option.Normal; }));
                    floatOptionList.Add(new FloatMenuOption(string.Format("SS_Fast".Translate() + " {0}", SmartSpeed_Settings.currSetting == SmartSpeed.Option.Fast ? "V" : ""), delegate { SmartSpeed_Settings.currSetting = SmartSpeed.Option.Fast; }));
                    floatOptionList.Add(new FloatMenuOption(string.Format("SS_Half".Translate() + " {0}", SmartSpeed_Settings.currSetting == SmartSpeed.Option.Half ? "V" : ""), delegate { SmartSpeed_Settings.currSetting = SmartSpeed.Option.Half; }));
                    floatOptionList.Add(new FloatMenuOption(string.Format("SS_Ignore".Translate() + " {0}", SmartSpeed_Settings.currSetting == SmartSpeed.Option.Ignore ? "V" : ""), delegate { SmartSpeed_Settings.currSetting = SmartSpeed.Option.Ignore; }));
                    var window = new FloatMenu(floatOptionList, "SS_EventSpeed".Translate());
                    Find.WindowStack.Add(window);

                    // use event so it doesn't bubble through
                    Event.current.Use();
                }
        }


    }

}