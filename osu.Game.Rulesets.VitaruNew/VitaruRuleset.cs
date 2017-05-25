using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using osu.Game.Screens.Play;
using OpenTK.Input;
using osu.Game.Graphics;
using osu.Game.Rulesets.VitaruNew.Scoring;
using osu.Game.Rulesets.Vitaru.Mods;

namespace osu.Game.Rulesets.VitaruNew
{
    class VitaruRuleset : Ruleset
    {
        public override string Description => "vitaru!";

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap) => new VitaruDifficultyCalculator(beatmap);

        public override IEnumerable<KeyCounter> CreateGameplayKeys()
        {
            return new[]
            {
                new KeyCounterKeyboard(Key.Left),
                new KeyCounterKeyboard(Key.Right),
                new KeyCounterKeyboard(Key.Up),
                new KeyCounterKeyboard(Key.Down),
                new KeyCounterKeyboard(Key.LShift),
                new KeyCounterKeyboard(Key.X),
                new KeyCounterKeyboard(Key.Z),
            };
        }

        public override HitRenderer CreateHitRendererWith(WorkingBeatmap beatmap, bool isForCurrentRuleset)
        {
            throw new NotImplementedException();
        }

        public override ScoreProcessor CreateScoreProcessor() => new VitaruScoreProcessor();

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.DifficultyIncrease :
                    return new Mod[]
                    {
                        new VitaruModHardRock(),
                        new VitaruModSuddenDeath(),
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new VitaruModDoubleTime(),
                                new VitaruModNightcore(),
                            }
                        },
                        new VitaruModHidden(),
                        new VitaruModFlashlight(),
                    };
                case ModType.DifficultyReduction:
                    return new Mod[]
                    {
                        new VitaruModEasy(),
                        new VitaruModNoFail(),
                        new VitaruModHalfTime(),
                    };
                case ModType.Special:
                    return new Mod[]
                    {
                        new VitaruModRelax(),
                    };
                default:
                    throw new ArgumentException();
            }
        }

        public override FontAwesome Icon => FontAwesome.fa_arrow_circle_o_down;
    }
}
