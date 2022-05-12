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

   
    [HarmonyPatch(typeof(TickManager))]
    [HarmonyPatch("TickRateMultiplier", MethodType.Getter)]
    public static class SmartSpeed_TickManager_TickRateMultiplier_PreAndPostfix
    {
		[HarmonyPrefix]
        static bool ModifyTickRate(ref float __result, bool ___UltraSpeedBoost, TickManager __instance)
        {

			var slower = Find.TickManager.slower;
			var curTimeSpeed = Find.TickManager.CurTimeSpeed;
			
			

			if (slower.ForcedNormalSpeed)
			{
				if (curTimeSpeed == TimeSpeed.Paused)
				{
					__result= 0f;
				}
				switch (SmartSpeed_Settings.currSetting)
				{
					case SmartSpeed.Option.Slow:
						__result = SmartSpeed_Settings.normalSpeed/2;
						break;
					case SmartSpeed.Option.Normal:
						__result = SmartSpeed_Settings.normalSpeed;
						break;
					case SmartSpeed.Option.Fast:
						__result = SmartSpeed_Settings.normalSpeed*2;
						break;
					case SmartSpeed.Option.Half:
						__result = TickRate(curTimeSpeed, ___UltraSpeedBoost, __instance) / 2f;
						break;
					case SmartSpeed.Option.Ignore:
						__result = TickRate(curTimeSpeed, ___UltraSpeedBoost, __instance);
						break;
					
						
				}
            }
            else { __result = TickRate(curTimeSpeed, ___UltraSpeedBoost, __instance); }
			
			return false;

		}

		private static float TickRate(TimeSpeed currTimeSpeed, bool ultraspeedboost, TickManager manager)
		{
			MethodInfo privatemethod = AccessTools.Method(typeof(TickManager), "NothingHappeningInGame");
			switch (currTimeSpeed)
			{
				case TimeSpeed.Paused:
					return 0f;
				case TimeSpeed.Normal:
					return SmartSpeed_Settings.normalSpeed;
				case TimeSpeed.Fast:
					return SmartSpeed_Settings.fastSpeed;
				case TimeSpeed.Superfast:
					if (Find.Maps.Count == 0)
					{
						return SmartSpeed_Settings.superfastSpeed*20;
					}
					if ((bool)privatemethod.Invoke(manager,null))
					{
						return SmartSpeed_Settings.superfastSpeed*2;
					}
					return SmartSpeed_Settings.superfastSpeed;
				case TimeSpeed.Ultrafast:
					if (Find.Maps.Count == 0 || ultraspeedboost)
					{
						return SmartSpeed_Settings.ultrafastSpeed*10;
					}
					return SmartSpeed_Settings.ultrafastSpeed;
				default:
					return -1f;
			}
		}





	}

}