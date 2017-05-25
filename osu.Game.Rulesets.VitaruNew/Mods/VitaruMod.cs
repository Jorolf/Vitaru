using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.Vitaru.Mods
{
    public class VitaruModNoFail : ModNoFail
    {
    }

    public class VitaruModEasy : ModEasy
    {
    }

    public class VitaruModHidden : ModHidden
    {
        public override string Description => @"Play with bullets dissapearing once they leave enemies immediate area.";
        public override double ScoreMultiplier => 1.18;
    }

    public class VitaruModHardRock : ModHardRock
    {
        public override double ScoreMultiplier => 1.08;
        public override bool Ranked => true;
    }

    public class VitaruModSuddenDeath : ModSuddenDeath
    {
        public override string Description => "Don't get hit.";
        public override bool Ranked => true;
    }

    public class VitaruModDoubleTime : ModDoubleTime
    {
        public override double ScoreMultiplier => 1.36;
    }

    public class VitaruModHalfTime : ModHalfTime
    {
        public override double ScoreMultiplier => 0.5;
    }

    public class VitaruModNightcore : ModNightcore
    {
        public override double ScoreMultiplier => 1.36;
    }

    public class VitaruModFlashlight : ModFlashlight
    {
        public override string Description => @"Play with bullets only appearing when they are close.";
        public override double ScoreMultiplier => 1.18;
    }

    public class VitaruModRelax : ModRelax
    {
        public override bool Ranked => false;
    }
}
