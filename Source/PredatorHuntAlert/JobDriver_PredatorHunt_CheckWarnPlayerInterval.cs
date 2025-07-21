using HarmonyLib;
using RimWorld;

namespace PredatorHuntAlert;

[HarmonyPatch(typeof(JobDriver_PredatorHunt), "CheckWarnPlayerInterval")]
internal class JobDriver_PredatorHunt_CheckWarnPlayerInterval
{
    private static bool Prefix()
    {
        return false;
    }
}