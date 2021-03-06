﻿using OpenTK;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Vitaru.Objects;
using System.Collections.Generic;
using osu.Game.Rulesets.Objects.Types;
using System;
using osu.Game.Rulesets.Vitaru.UI;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Vitaru.Objects.Characters;
using osu.Game.Rulesets.Vitaru.Objects.Drawables;

namespace osu.Game.Rulesets.Vitaru.Beatmaps
{
    internal class VitaruBeatmapConverter : BeatmapConverter<VitaruHitObject>
    {
        private bool playerLoaded = false;
        private readonly VitaruHitRenderer hitRenderer;

        protected override IEnumerable<Type> ValidConversionTypes => new[] { typeof(IHasPosition) };

        public VitaruBeatmapConverter(VitaruHitRenderer hitRenderer)
        {
            this.hitRenderer = hitRenderer;
        }

        protected override IEnumerable<VitaruHitObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            var curveData = original as IHasCurve;
            var endTimeData = original as IHasEndTime;
            var positionData = original as IHasPosition;
            var comboData = original as IHasCombo;

            if (!playerLoaded)
            {
                playerLoaded = true;
                DrawableCharacter.AssetsLoaded = false;
                VitaruPlayer player;
                yield return player = new VitaruPlayer(hitRenderer)
                {
                    Position = VitaruHitRenderer.DefaultPlayerPosition,
                    StartTime = 0f,
                };
                if (hitRenderer != null) hitRenderer.Player = player;
            }

            if (curveData != null)
            {
                yield return new Enemy(hitRenderer)
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    ControlPoints = curveData.ControlPoints,
                    CurveType = curveData.CurveType,
                    Distance = curveData.Distance,
                    RepeatSamples = curveData.RepeatSamples,
                    RepeatCount = curveData.RepeatCount,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false,
                    IsSlider = true,
                };
            }
            else if (endTimeData != null)
            {
                yield return new Enemy(hitRenderer)
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    //EndTime = endTimeData.EndTime,
                    //IsSpinner = true,

                    Position = positionData?.Position ?? VitaruPlayfield.BASE_SIZE / 2,
                };
            }
            else
            {
                yield return new Enemy(hitRenderer)
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false,
                };
            }
        }
        private void enemySlider()
        {

        }
        private void enemySpinner()
        {

        }
        private void enemyHitcircle()
        {

        }
    }
}
