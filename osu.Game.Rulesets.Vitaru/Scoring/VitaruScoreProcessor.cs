﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Extensions;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Vitaru.Judgements;
using osu.Game.Rulesets.Vitaru.Objects;
using osu.Game.Rulesets.Vitaru.Objects.Drawables;
using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Vitaru.Scoring
{
    internal class VitaruScoreProcessor : ScoreProcessor<VitaruHitObject, VitaruJudgement>
    {
        private readonly VitaruHitRenderer hitRenderer;

        public VitaruScoreProcessor(VitaruHitRenderer hitRenderer)
            : base(hitRenderer)
        {
            this.hitRenderer = hitRenderer;
        }

        protected override void Reset()
        {
            base.Reset();

            Health.Value = 1;
            Accuracy.Value = 1;

            Health.Value = hitRenderer?.PlayerHealth ?? 0;
            Accuracy.Value = hitRenderer?.PlayerEnergy ?? 0;

            scoreResultCounts.Clear();
            comboResultCounts.Clear();
        }

        private readonly Dictionary<VitaruScoreResult, int> scoreResultCounts = new Dictionary<VitaruScoreResult, int>();
        private readonly Dictionary<ComboResult, int> comboResultCounts = new Dictionary<ComboResult, int>();

        public override void PopulateScore(Score score)
        {
            base.PopulateScore(score);

            score.Statistics[@"300"] = scoreResultCounts.GetOrDefault(VitaruScoreResult.Kill30);
            score.Statistics[@"100"] = scoreResultCounts.GetOrDefault(VitaruScoreResult.Kill20);
            score.Statistics[@"50"] = scoreResultCounts.GetOrDefault(VitaruScoreResult.Kill10);
            score.Statistics[@"x"] = scoreResultCounts.GetOrDefault(VitaruScoreResult.Miss);
        }

        protected override void OnNewJudgement(VitaruJudgement judgement)
        {
            if (judgement != null)
            {
                if (judgement.Result != HitResult.None)
                {
                    scoreResultCounts[judgement.Score] = scoreResultCounts.GetOrDefault(judgement.Score) + 1;
                    comboResultCounts[judgement.Combo] = comboResultCounts.GetOrDefault(judgement.Combo) + 1;
                }

                switch (judgement.Result)
                {
                    case HitResult.Hit:
                        Health.Value += 0.1f;
                        break;
                    case HitResult.Miss:
                        Health.Value -= 1f;
                        break;
                }
            }
        }
    }
}