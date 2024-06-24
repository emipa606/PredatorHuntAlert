using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace PredatorHuntAlert;

public class Alert_PredatorHunt : Alert_Critical
{
    public Alert_PredatorHunt()
    {
        defaultLabel = "PredatorHunt.AlertPredatorHuntLabel".Translate();
    }

    private IEnumerable<Pair<Pawn, Pawn>> PredatorAndVictimPairs
    {
        get
        {
            foreach (var item in PawnsFinder.AllMaps_Spawned)
            {
                var victim = Util.GetVictim(item.CurJob);
                if (victim != null)
                {
                    yield return new Pair<Pawn, Pawn>(item, victim);
                }
            }
        }
    }

    public override TaggedString GetExplanation()
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in from pair in PredatorAndVictimPairs
                 group pair by $"{pair.First.KindLabel}/{pair.Second.Label}")
        {
            var pair2 = item.First();
            stringBuilder.AppendLine("PredatorHunt.AlertPredatorHuntDescription".Translate(pair2.Second.LabelShort,
                pair2.First.LabelShort, item.Count()));
        }

        return stringBuilder.ToString();
    }

    public override AlertReport GetReport()
    {
        var alertCulpritSequence = PredatorHuntAlertMod.Settings.alertCulpritSequence;
        if (alertCulpritSequence == PredatorHuntAlertSettings.AlertCulpritSequence.NoAlert)
        {
            return false;
        }

        var list = new List<Pawn>();
        foreach (var predatorAndVictimPair in PredatorAndVictimPairs)
        {
            if (alertCulpritSequence is PredatorHuntAlertSettings.AlertCulpritSequence.PredatorOnly
                or PredatorHuntAlertSettings.AlertCulpritSequence.AlternatePredatorAndVictim)
            {
                list.Add(predatorAndVictimPair.First);
            }

            if (alertCulpritSequence is PredatorHuntAlertSettings.AlertCulpritSequence.VictimOnly
                or PredatorHuntAlertSettings.AlertCulpritSequence.AlternatePredatorAndVictim)
            {
                list.Add(predatorAndVictimPair.Second);
            }
        }

        return list.NullOrEmpty() ? false : AlertReport.CulpritsAre(list);
    }
}