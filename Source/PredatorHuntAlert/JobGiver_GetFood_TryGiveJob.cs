using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace PredatorHuntAlert;

[HarmonyPatch(typeof(JobGiver_GetFood), "TryGiveJob")]
internal class JobGiver_GetFood_TryGiveJob
{
    private static void Postfix(Job __result, Pawn pawn)
    {
        var victim = Util.GetVictim(__result);
        if (victim == null)
        {
            return;
        }

        if (PredatorHuntAlertMod.Settings.pauseOnTargeted)
        {
            Find.TickManager.Pause();
        }

        if (PredatorHuntAlertMod.Settings.alertType == PredatorHuntAlertSettings.AlertType.Letter)
        {
            SendLetter(pawn, victim);
            return;
        }

        if (PredatorHuntAlertMod.Settings.alertType == PredatorHuntAlertSettings.AlertType.Message)
        {
            SendMessage(pawn, victim);
        }
    }

    private static void SendMessage(Pawn predator, Pawn victim)
    {
        var pawn = Util.ResolveFocusTarget(predator, victim);
        Messages.Message(
            "PredatorHuntAlert.MessageTargetedByPredator".Translate(victim.LabelShort, predator.LabelShort), pawn,
            MessageTypeDefOf.NegativeEvent);
    }

    private static void SendLetter(Pawn predator, Pawn victim)
    {
        var pawn = Util.ResolveFocusTarget(predator, victim);
        string label = "PredatorHuntAlert.LetterLabelTargetedByPredator".Translate();
        string text =
            "PredatorHuntAlert.LetterTextTargetedByPredator".Translate(victim.LabelShort, predator.LabelShort);
        Find.LetterStack.ReceiveLetter((TaggedString)label, (TaggedString)text, LetterDefOf.ThreatSmall, pawn);
    }
}