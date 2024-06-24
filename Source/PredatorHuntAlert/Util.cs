using RimWorld;
using Verse;
using Verse.AI;

namespace PredatorHuntAlert;

public static class Util
{
    public static Pawn GetVictim(Job job)
    {
        if (job == null)
        {
            return null;
        }

        if (job.def != JobDefOf.PredatorHunt)
        {
            return null;
        }

        if (job.targetA.Thing is not Pawn pawn)
        {
            return null;
        }

        return PawnUtility.ShouldSendNotificationAbout(pawn) ? pawn : null;
    }

    public static Pawn ResolveFocusTarget(Pawn predator, Pawn victim)
    {
        return PredatorHuntAlertMod.Settings.focusTarget != 0 ? victim : predator;
    }
}