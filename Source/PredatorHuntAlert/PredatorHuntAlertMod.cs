using Mlie;
using UnityEngine;
using Verse;

namespace PredatorHuntAlert;

public class PredatorHuntAlertMod : Mod
{
    private static string currentVersion;
    public readonly PredatorHuntAlertSettings settings;

    public PredatorHuntAlertMod(ModContentPack content)
        : base(content)
    {
        settings = GetSettings<PredatorHuntAlertSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public static PredatorHuntAlertSettings Settings => LoadedModManager.GetMod<PredatorHuntAlertMod>().settings;

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing_Standard = new Listing_Standard
        {
            ColumnWidth = (float)((inRect.width - 34.0) / 2.0)
        };
        listing_Standard.Begin(inRect);
        listing_Standard.Label("PredatorHuntAlert.SettingAlertType".Translate());
        var tabIn = 7f;
        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingAlertTypeMessage".Translate(),
                settings.alertType == PredatorHuntAlertSettings.AlertType.Message, tabIn))
        {
            settings.alertType = PredatorHuntAlertSettings.AlertType.Message;
        }

        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingAlertTypeLetter".Translate(),
                settings.alertType == PredatorHuntAlertSettings.AlertType.Letter, tabIn))
        {
            settings.alertType = PredatorHuntAlertSettings.AlertType.Letter;
        }

        listing_Standard.Gap();
        listing_Standard.Label("PredatorHuntAlert.SettingFocusTarget".Translate());
        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingFocusTargetPredator".Translate(),
                settings.focusTarget == PredatorHuntAlertSettings.FocusTarget.Predator, tabIn))
        {
            settings.focusTarget = PredatorHuntAlertSettings.FocusTarget.Predator;
        }

        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingFocusTargetVictim".Translate(),
                settings.focusTarget == PredatorHuntAlertSettings.FocusTarget.Victim, tabIn))
        {
            settings.focusTarget = PredatorHuntAlertSettings.FocusTarget.Victim;
        }

        listing_Standard.Gap();
        listing_Standard.Label("PredatorHuntAlert.SettingAlertCulpritSequence".Translate());
        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingAlertCulpritSequenceNoAlert".Translate(),
                settings.alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.NoAlert, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.NoAlert;
        }

        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingAlertCulpritSequencePredatorOnly".Translate(),
                settings.alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.PredatorOnly, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.PredatorOnly;
        }

        if (listing_Standard.RadioButton("PredatorHuntAlert.SettingAlertCulpritSequenceVictimOnly".Translate(),
                settings.alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.VictimOnly, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.VictimOnly;
        }

        if (listing_Standard.RadioButton(
                "PredatorHuntAlert.SettingAlertCulpritSequenceAlternatePredatorAndVictim".Translate(),
                settings.alertCulpritSequence ==
                PredatorHuntAlertSettings.AlertCulpritSequence.AlternatePredatorAndVictim, tabIn))
        {
            settings.alertCulpritSequence = PredatorHuntAlertSettings.AlertCulpritSequence.AlternatePredatorAndVictim;
        }

        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("PredatorHuntAlert.SettingPauseOnTargeted".Translate(),
            ref settings.pauseOnTargeted);
        listing_Standard.CheckboxLabeled("PredatorHuntAlert.SettingEnablePredatorAlert".Translate(),
            ref settings.enablePredatorAlert);
        listing_Standard.CheckboxLabeled("PredatorHuntAlert.SettingEnableManhunterAlert".Translate(),
            ref settings.enableManhunterAlert);
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("PredatorHuntAlert.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override string SettingsCategory()
    {
        return "Predator Hunt Alert";
    }
}