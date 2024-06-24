using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace PredatorHuntAlert;

public class Alert_Manhunter : Alert_Critical
{
    private readonly List<Pawn> manhunters = [];

    public Alert_Manhunter()
    {
        defaultLabel = "PredatorHunt.AlertManhunterLabel".Translate();
    }

    private List<Pawn> Manhunters
    {
        get
        {
            manhunters.Clear();
            foreach (var item in PawnsFinder.AllMaps_Spawned)
            {
                if (item.MentalStateDef == MentalStateDefOf.ManhunterPermanent)
                {
                    manhunters.Add(item);
                }
            }

            foreach (var item2 in PawnsFinder.AllMaps_Spawned)
            {
                if (item2.MentalStateDef == MentalStateDefOf.Manhunter)
                {
                    manhunters.Add(item2);
                }
            }

            return manhunters;
        }
    }

    public override TaggedString GetExplanation()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("PredatorHunt.AlertManhunterDescriptionBase".Translate());
        foreach (var item in from x in Manhunters
                 group x by $"{x.kindDef.defName}/{x.MentalStateDef.defName}")
        {
            var pawn = item.First();
            var text = pawn.MentalStateDef == MentalStateDefOf.ManhunterPermanent
                ? "PredatorHunt.AlertManhunterDescriptionItemsPermanent".Translate().ToString()
                : "";
            stringBuilder.AppendLine(
                "PredatorHunt.AlertManhunterDescriptionItems".Translate(pawn.Label, text, item.Count()));
        }

        return stringBuilder.ToString();
    }

    public override AlertReport GetReport()
    {
        return !PredatorHuntAlertMod.Settings.enableManhunterAlert ? false : AlertReport.CulpritsAre(Manhunters);
    }
}