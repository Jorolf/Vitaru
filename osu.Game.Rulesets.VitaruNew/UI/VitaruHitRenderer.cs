using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.VitaruNew.Objects;
using osu.Game.Rulesets.VitaruNew.Judgements;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using System;
using osu.Game.Rulesets.VitaruNew.Beatmaps;
using osu.Game.Rulesets.VitaruNew.Scoring;

namespace osu.Game.Rulesets.VitaruNew.UI
{
    class VitaruHitRenderer : HitRenderer<Character, VitaruJudgement>
    {
        public VitaruHitRenderer(WorkingBeatmap beatmap, bool isForCurrentRuleset) : base(beatmap, isForCurrentRuleset)
        {
        }

        public override ScoreProcessor CreateScoreProcessor() => new VitaruScoreProcessor();

        protected override BeatmapConverter<Character> CreateBeatmapConverter() => new VitaruBeatmapConverter();

        protected override Playfield<Character, VitaruJudgement> CreatePlayfield()
        {
            throw new NotImplementedException();
        }

        protected override DrawableHitObject<Character, VitaruJudgement> GetVisualRepresentation(Character h)
        {
            throw new NotImplementedException();
        }
    }
}
