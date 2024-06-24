using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace PredatorHuntAlert;

public class Alert_Predator : Alert
{
    private readonly List<Pawn> predators = [];

    public Alert_Predator()
    {
        defaultLabel = "PredatorHunt.AlertPredatorLabel".Translate();
    }

    private List<Pawn> Predators
    {
        get
        {
            predators.Clear();
            foreach (var item in PawnsFinder.AllMaps_Spawned)
            {
                if (item.RaceProps.predator && (item.Faction == null ||
                                                !item.Faction.IsPlayer && item.Faction.HostileTo(Faction.OfPlayer)))
                {
                    predators.Add(item);
                }
            }

            return predators;
        }
    }

    public override TaggedString GetExplanation()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("PredatorHunt.AlertPredatorDescriptionBase".Translate());
        foreach (var item in from x in Predators
                 group x by x.kindDef)
        {
            stringBuilder.AppendLine(
                "PredatorHunt.AlertPredatorDescriptionItems".Translate(item.First().KindLabel, item.Count()));
        }

        return stringBuilder.ToString();
    }

    public override AlertReport GetReport()
    {
        return !PredatorHuntAlertMod.Settings.enablePredatorAlert ? false : AlertReport.CulpritsAre(Predators);
    }
}