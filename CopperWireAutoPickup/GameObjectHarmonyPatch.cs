using HarmonyLib;
using XRL.World;
using Fyrefly.CopperWireAutoPickup;
using XRL.World.Parts;
using XRL.Core;
using XRL.Messages;

namespace Fyrefly.CopperWireAutoPickup.HarmonyPatches
{
    [HarmonyPatch(typeof(GameObject))]
    class ShouldAutogetWirePatch
    {

        [HarmonyPatch("ShouldAutoget")]
        static void Postfix(ref bool __result, ref GameObject __instance)
        {
            //MessageQueue.AddPlayerMessage($"Running Autoget Postfix on {__instance.DisplayName}");
            if (Options.AutogetWire != "Never")
            {
                //MessageQueue.AddPlayerMessage($"Options not set to Never");
                if ((XRLCore.Core.Game.HasUnfinishedQuest("Weirdwire Conduit.. Eureka!")
                    && !XRLCore.Core.Game.HasFinishedQuestStep("Weirdwire Conduit.. Eureka!", "Find 200 feet of copper wire"))
                    | Options.AutogetWire == "Always")
                {
                    //MessageQueue.AddPlayerMessage($"Either has unfinished quest or option set to Always");
                    if (__instance.HasPart("Wire") && ((Wire)__instance.GetPart("Wire")).Length>=Options.AutogetWireMinLength) {
                        //MessageQueue.AddPlayerMessage($"Wire detected, returning true!");
                        __result = true;
                    }
                }
            }
        }
    }
}
