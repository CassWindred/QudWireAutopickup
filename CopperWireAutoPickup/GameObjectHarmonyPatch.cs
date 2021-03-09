using HarmonyLib;
using XRL.World;
using Fyrefly.CopperWireAutoPickup;
using XRL.World.Parts;

namespace Fyrefly.CopperWireAutoPickup.HarmonyPatches
{
    [HarmonyPatch(typeof(GameObject))]
    class ShouldAutogetWirePatch
    {

        [HarmonyPatch("ShouldAutoget")]
        static void Postfix(ref bool __result, ref GameObject __instance)
        {
            if (Options.AutogetWire 
            && __instance.HasPart("Wire") 
            && ((Wire)__instance.GetPart("Wire")).Length>=Options.AutogetWireMinLength) {
                __result = true;
            }
        }
    }
}
