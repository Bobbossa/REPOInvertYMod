using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

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
			mls.LogInfo("InvertYMod has awoken.");

			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(InputManager))]
	class InvertYPatch{
		[HarmonyPatch("GetMouseY")]
		[HarmonyPostfix]
		static void GetInvertedMouseY(ref float __result){
			__result *= -1f;
		}
	}
}
