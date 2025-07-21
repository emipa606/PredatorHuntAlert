using Mlie;
using UnityEngine;
using Verse;

namespace PredatorHuntAlert;

public class PredatorHuntAlertMod : Mod
{
    private static string currentVersion;
    private readonly PredatorHuntAlertSettings settings;

    public PredatorHuntAlertMod(ModContentPack content)
        : base(content)
    {
        settings = GetSettings<PredatorHuntAlertSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public static PredatorHuntAlertSettings Settings => LoadedModManager.GetMod<PredatorHuntAlertMod>().settings;

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard
        {
            ColumnWidth = (float)((inRect.width - 34.0) / 2.0)
        };
        listingStandard.Begin(inRect);
        listingStandard.Label("PredatorHuntAlert.SettingAlertType".Translate());
        var tabIn = 7f;
        if (listingStandard.RadioButton("PredatorHuntAlert.SettingAlertTypeMessage".Translate(),
                settings.alertType == PredatorHuntAlertSettings.AlertType.Message, tabIn))
        {
            settings.alertType = PredatorHuntAlertSettings.AlertType.Message;
        }

        if (listingStandard.RadioButton("PredatorHuntAlert.SettingAlertTypeLetter".Translate(),
                settings.alertType == PredatorHuntAlertSettings.AlertType.Letter, tabIn))
        {
            settings.alertType = PredatorHuntAlertSettings.AlertType.Letter;
        }

        listingStandard.Gap();
        listingStandard.Label("PredatorHuntAlert.SettingFocusTarget".Translate());
        if (listingStandard.RadioButton("PredatorHuntAlert.SettingFocusTargetPredator".Translate(),
                settings.focusTarget == PredatorHuntAlertSettings.FocusTarget.Predator, tabIn))
        {
            settings.focusTarget = PredatorHuntAlertSettings.FocusTarget.Predator;
        }

        if (listingStandard.RadioButton("PredatorHuntAlert.SettingFocusTargetVictim".Translate(),
                settings.focusTarget == PredatorHuntAlertSettings.FocusTarget.Victim, tabIn))
        {
            settings.focusTarget = PredatorHuntAlertSettings.FocusTarget.Victim;
        }

        listingStandard.Gap();
        listingStandard.Label("PredatorHuntAlert.SettingAlertCulpritSequence".Translate());
        if (listingStandard.RadioButton("PredatorHuntAlert.SettingAlertCulpritSequenceNoAlert".Translate(),
                settings.alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.NoAlert, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.NoAlert;
        }

        if (listingStandard.RadioButton("PredatorHuntAlert.SettingAlertCulpritSequencePredatorOnly".Translate(),
                settings.alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.PredatorOnly, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.PredatorOnly;
        }

        if (listingStandard.RadioButton("PredatorHuntAlert.SettingAlertCulpritSequenceVictimOnly".Translate(),
                settings.alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.VictimOnly, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.VictimOnly;
        }

        if (listingStandard.RadioButton(
                "PredatorHuntAlert.SettingAlertCulpritSequenceAlternatePredatorAndVictim".Translate(),
                settings.alertCulpritSequence ==
                PredatorHuntAlertSettings.AlertCulpritSequence.AlternatePredatorAndVictim, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.AlternatePredatorAndVictim;
        }

        listingStandard.Gap();
        listingStandard.CheckboxLabeled("PredatorHuntAlert.SettingPauseOnTargeted".Translate(),
            ref settings.pauseOnTargeted);
        listingStandard.CheckboxLabeled("PredatorHuntAlert.SettingEnablePredatorAlert".Translate(),
            ref settings.enablePredatorAlert);
        listingStandard.CheckboxLabeled("PredatorHuntAlert.SettingEnableManhunterAlert".Translate(),
            ref settings.enableManhunterAlert);
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("PredatorHuntAlert.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override string SettingsCategory()
    {
        return "Predator Hunt Alert";
    }
}