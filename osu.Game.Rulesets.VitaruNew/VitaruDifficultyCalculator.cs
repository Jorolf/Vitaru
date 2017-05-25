using osu.Game.Beatmaps;
using osu.Game.Rulesets.VitaruNew.Objects;
using System;
using System.Collections.Generic;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.VitaruNew.Beatmaps;

namespace osu.Game.Rulesets.VitaruNew
{
    class VitaruDifficultyCalculator : DifficultyCalculator<Character>
    {
        private readonly Beatmap beatmap;

        public VitaruDifficultyCalculator(Beatmap beatmap) : base(beatmap)
        {
            this.beatmap = beatmap;
        }

        protected override double CalculateInternal(Dictionary<string, string> categoryDifficulty) => beatmap.BeatmapInfo.Difficulty.OverallDifficulty;

        protected override BeatmapConverter<Character> CreateBeatmapConverter() => new VitaruBeatmapConverter();
    }
}
