using Verse;

namespace PredatorHuntAlert;

public class PredatorHuntAlertSettings : ModSettings
{
    public enum AlertCulpritSequence
    {
        NoAlert,
        PredatorOnly,
        VictimOnly,
        AlternatePredatorAndVictim
    }

    public enum AlertType
    {
        Message,
        Letter
    }

    public enum FocusTarget
    {
        Predator,
        Victim
    }

    public AlertCulpritSequence alertCulpritSequence;

    public AlertType alertType;

    public bool enableManhunterAlert;

    public bool enablePredatorAlert;

    public FocusTarget focusTarget;

    public bool pauseOnTargeted;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref alertType, "alertType");
        Scribe_Values.Look(ref focusTarget, "focusTarget");
        Scribe_Values.Look(ref alertCulpritSequence, "alertCulpritSequence");
        Scribe_Values.Look(ref pauseOnTargeted, "pauseOnTargeted", true);
        Scribe_Values.Look(ref enablePredatorAlert, "enablePredatorAlert", true);
        Scribe_Values.Look(ref enableManhunterAlert, "enableManhunterAlert", true);
    }
}