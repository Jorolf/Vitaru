using osu.Framework.Graphics;
using osu.Game.Rulesets.Vitaru.Objects;
using osu.Game.Rulesets.UI;
using OpenTK;
using osu.Game.Rulesets.Vitaru.Judgements;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Vitaru.Objects.Drawables;

namespace osu.Game.Rulesets.Vitaru.UI
{
    public class VitaruPlayfield : Playfield<VitaruHitObject, VitaruJudgement>
    {
        private readonly Container vitaruPlayfield;

        public override bool ProvidingUserCursor => true;

        public static readonly Vector2 BASE_SIZE = new Vector2(512, 820);

        public override Vector2 Size
        {
            get
            {
                var parentSize = Parent.DrawSize;
                var aspectSize = parentSize.X * 0.75f < parentSize.Y ? new Vector2(parentSize.X, parentSize.X * 0.75f) : new Vector2(parentSize.Y * 5f / 8f, parentSize.Y);

                return new Vector2(aspectSize.X / parentSize.X, aspectSize.Y / parentSize.Y) * base.Size;
            }
        }

        public VitaruPlayfield(VitaruHitRenderer hitRenderer) : base(BASE_SIZE.X)
        {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;

            Add(new Drawable[]
            {
                new VitaruUI(hitRenderer)
                {
                    Masking = false,
                    //Magic numbers, srry in advance
                    Position = new Vector2(-20),
                    RelativeSizeAxes = Axes.Both,
                    //Magic numbers, srry in advance
                    Size = new Vector2(1.52f , 1.46f),
                },
                vitaruPlayfield = new Container
                {
                    Masking = false,
                    RelativeSizeAxes = Axes.Both,
                    Depth = 2,
                },
            });
        }

        public override void Add(DrawableHitObject<VitaruHitObject, VitaruJudgement> h)
        {
            h.Depth = (float)h.HitObject.StartTime;

            IDrawableHitObjectWithProxiedApproach c = h as IDrawableHitObjectWithProxiedApproach;
            if (c != null)
                vitaruPlayfield.Add(c.ProxiedLayer.CreateProxy());

            DrawableCharacter character = h as DrawableCharacter;
            if (character != null)
                character.Playfield = this;

            base.Add(h);
        }
    }
}
