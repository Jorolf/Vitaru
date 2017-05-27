// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Vitaru.Objects.Characters
{
    public class VitaruPlayer : Character
    {
        public double EndTime { get; set; }
        public object Sample { get; internal set; }

        public override HitObjectType Type => HitObjectType.Player;

        public VitaruPlayer(VitaruHitRenderer hitRenderer) : base(hitRenderer)
        {
        }
    }
}