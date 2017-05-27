using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.Vitaru.Judgements;
using osu.Game.Rulesets.Vitaru.Objects;
using osu.Game.Rulesets.Vitaru.Objects.Drawables;
using osu.Game.Rulesets.Vitaru.Objects.Characters;
using osu.Game.Rulesets.Vitaru.Beatmaps;
using osu.Game.Rulesets.Vitaru.UI;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Beatmaps;
using OpenTK;
using osu.Game.Rulesets.Vitaru.Scoring;
using osu.Framework.Input;
using OpenTK.Input;

namespace osu.Game.Rulesets.Vitaru
{
    public class VitaruHitRenderer : HitRenderer<VitaruHitObject, VitaruJudgement>
    {
        public VitaruHitRenderer(WorkingBeatmap beatmap, bool isForCurrentRuleset)
            : base(beatmap, isForCurrentRuleset)
        {
        }

        public override ScoreProcessor CreateScoreProcessor() => new VitaruScoreProcessor(this);

        protected override BeatmapConverter<VitaruHitObject> CreateBeatmapConverter() => new VitaruBeatmapConverter(this);

        protected override BeatmapProcessor<VitaruHitObject> CreateBeatmapProcessor() => new VitaruBeatmapProcessor();

        protected override Playfield<VitaruHitObject, VitaruJudgement> CreatePlayfield() => new VitaruPlayfield(this);

        protected override DrawableHitObject<VitaruHitObject, VitaruJudgement> GetVisualRepresentation(VitaruHitObject h)
        {
            var player = h as VitaruPlayer;
            if (player != null)
                return new DrawableVitaruPlayer(player);

            var enemy = h as Enemy;
            if (enemy != null)
                return new DrawableVitaruEnemy(enemy);

            var boss = h as Boss;
            if (boss != null)
                return new DrawableVitaruBoss(boss);
            return null;
        }

        protected override Vector2 GetPlayfieldAspectAdjust() => new Vector2(0.75f);

        public float PlayerHealth = 0.5f;
        public float PlayerEnergy = 1;

        public static Vector2 DefaultPlayerPosition => new Vector2(256, 700);

        public VitaruPlayer Player { get; set; }

        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            if (args.Key == Key.Up || args.Key == Key.Down)
                return true;
            return base.OnKeyDown(state, args);
        }
    }
}
