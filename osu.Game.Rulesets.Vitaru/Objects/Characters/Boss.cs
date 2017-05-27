// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;

namespace osu.Game.Rulesets.Vitaru.Objects.Characters
{
    public class Boss : Character
    {
        public Vector2 BossPosition = new Vector2(0, -160);

        public Boss(VitaruHitRenderer renderer) : base(renderer)
        {
        }

        public override HitObjectType Type => HitObjectType.Boss;

        public double EndTime { get; set; }
    }
}