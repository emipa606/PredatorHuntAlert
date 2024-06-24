using System.Reflection;
using HarmonyLib;
using Verse;

namespace PredatorHuntAlert;

[StaticConstructorOnStartup]
internal class Main
{
    static Main()
    {
        new Harmony("com.tammybee.predatorhuntalert").PatchAll(Assembly.GetExecutingAssembly());
    }
}