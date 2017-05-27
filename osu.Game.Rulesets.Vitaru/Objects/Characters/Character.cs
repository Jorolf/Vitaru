// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Vitaru.Objects.Characters
{
    public abstract class Character : VitaruHitObject
    {
        public float CharacterHealth { get; set; } = 100;
        public int Team { get; set; } = 0; // 0 = Player, 1 = Ememies + Boss(s) in Singleplayer
        public int ProjectileDamage { get; set; }

        public readonly VitaruHitRenderer HitRenderer;

        public Character(VitaruHitRenderer renderer)
        {
            HitRenderer = renderer;
        }
    }
}
