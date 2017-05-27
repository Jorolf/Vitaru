using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.MathUtils;
using osu.Game.Graphics.Backgrounds;

namespace osu.Game.Rulesets.Vitaru.UI
{
    public class VitaruUI : Container
    {
        private const float text_size = 40;
        private readonly VitaruHitRenderer hitRenderer;

        private SpriteText health;
        private SpriteText energy;
        private Box energyBarBox;
        private Box healthBarBox;

        public VitaruUI(VitaruHitRenderer hitRenderer)
        {
            this.hitRenderer = hitRenderer;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            RelativeSizeAxes = Axes.Both;
            Children = new Drawable[]
            {
                energy = new SpriteText
                {
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreLeft,
                    Position = new Vector2(8 , 0),
                    TextSize = text_size,
                    Colour = Color4.SkyBlue,
                },
                health = new SpriteText
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreRight,
                    Position = new Vector2(-8 , 0),
                    TextSize = text_size,
                    Colour = Color4.Green,
                },
                new Container
                {
                    Alpha = 1f,
                    Depth = 1,
                    Anchor = Anchor.CentreRight,
                    Origin = Anchor.CentreRight,
                    Colour = Color4.SkyBlue.Opacity(0.5f),
                    Size = new Vector2(10 , 820),
                    BorderColour = Color4.SkyBlue,
                    BorderThickness = 2,
                    Position = new Vector2(0),
                    Children = new Drawable[]
                    {
                        energyBarBox = new Box
                        {
                            Width = 10,
                            Colour = Color4.White,
                            RelativeSizeAxes = Axes.Y,
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                        },
                        new Triangles
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            ColourLight = Color4.LightSkyBlue,
                            ColourDark = Color4.DeepSkyBlue,
                            TriangleScale = 1,
                        }
                    },
                    EdgeEffect = new EdgeEffect
                    {
                        Type = EdgeEffectType.Shadow,
                        Colour = Color4.SkyBlue,
                        Radius = 2,
                    }
                },
                new Container
                {
                    Alpha = 1f,
                    Depth = 0,
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Size = new Vector2(10 , 820),
                    BorderThickness = 2,
                    Position = new Vector2(0),
                    Children = new Drawable[]
                    {
                        healthBarBox = new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                        },
                        new Triangles
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            ColourLight = Color4.DarkGreen,
                            ColourDark = Color4.LightGreen,
                            TriangleScale = 1,
                        }
                    },
                    EdgeEffect = new EdgeEffect
                    {
                        Type = EdgeEffectType.Shadow,
                        Colour = Color4.Green,
                        Radius = 2,
                    }
                },
                new Container
                {
                    Masking = true,
                    Alpha = 1f,
                    Depth = 0,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Colour = Color4.YellowGreen,
                    Size = new Vector2(548 , 10),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Size = new Vector2(548 , 10),
                            Colour = Color4.White,
                        },
                    },
                },
                new Container
                {
                    Masking = false,
                    Alpha = 1f,
                    Depth = 0,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Colour = Color4.Red,
                    Size = new Vector2(548 , 10),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Size = new Vector2(548 , 10),
                            Colour = Color4.White,
                        },
                    },
                },
            };
        }

        protected override void Update()
        {
            health.Colour = Interpolation.ValueAt(hitRenderer.PlayerHealth, Color4.Red, Color4.Green, 0, 1, EasingTypes.InOutExpo);
            healthBarBox.Colour = health.Colour;
            energyBarBox.ResizeHeightTo(hitRenderer.PlayerEnergy);
            healthBarBox.ResizeHeightTo(hitRenderer.PlayerHealth);
            energy.Text = hitRenderer.PlayerEnergy.ToString("P0") + " Charge";
            health.Text = hitRenderer.PlayerHealth.ToString("P0") + " Health";
        }
    }
}
