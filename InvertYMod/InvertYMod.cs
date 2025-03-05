﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Windows;

namespace InvertYMod
{
	[BepInPlugin(modGUID, modName, modVersion)]
	[BepInProcess("REPO.exe")]
    public class InvertYMod : BaseUnityPlugin
    {
		private const string modGUID = "Bobbossa.REPOInvertYMod";
		private const string modName = "InvertYMod";
		private const string modVersion = "0.1";

		private readonly Harmony harmony = new Harmony(modGUID);

		private static InvertYMod Instance;

		internal ManualLogSource mls;

		void Awake(){
			if(Instance == null){
				Instance = this;
			}

			mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
			mls.LogInfo("InvertYMod is running.");

			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(InputManager))]
	class InvertMouseYPatch{
		//Takes output from InputManager.instance.GetMouseY and multiplies it by -1.
		[HarmonyPatch("GetMouseY")]
		[HarmonyPostfix]		
		static void GetInvertedMouseY(ref float __result){
			__result *= -1f;
		}
	}

	[HarmonyPatch(typeof(Input))]
	class InvertGamepadYPatch2{
		[HarmonyPatch("GetAxis")]
		[HarmonyPostfix]
		static void GetInvertedYAxis(){
			/*if(){

			}*/
		}
	}
}
