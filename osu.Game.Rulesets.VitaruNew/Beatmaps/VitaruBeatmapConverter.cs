using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.VitaruNew.Objects;
using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.VitaruNew.Beatmaps
{
    class VitaruBeatmapConverter : BeatmapConverter<Character>
    {
        protected override IEnumerable<Type> ValidConversionTypes => new[] { typeof(HitObject) };

        protected override IEnumerable<Character> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            throw new NotImplementedException();
        }
    }
}
