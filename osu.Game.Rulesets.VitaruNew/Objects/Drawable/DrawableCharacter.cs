using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.VitaruNew.Judgements;
using System;

namespace osu.Game.Rulesets.VitaruNew.Objects.Drawable
{
    class DrawableCharacter : DrawableHitObject<Character, VitaruJudgement>
    {
        public DrawableCharacter(Character hitObject) : base(hitObject)
        {
        }

        protected override VitaruJudgement CreateJudgement()
        {
            return new VitaruJudgement();
        }

        protected override void UpdateState(ArmedState state)
        {
            throw new NotImplementedException();
        }
    }
}
