using HarmonyLib;
using RimWorld;

namespace PredatorHuntAlert;

[HarmonyPatch(typeof(JobDriver_PredatorHunt), "CheckWarnPlayer")]
internal class JobDriver_PredatorHunt_CheckWarnPlayer
{
    private static bool Prefix()
    {
        return false;
    }
}