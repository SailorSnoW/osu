// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Online.API.Requests.Responses;
using osu.Game.Scoring;

namespace osu.Game.Rulesets.Mods
{
    public static class ModExtensions
    {
        public static Score CreateScoreFromReplayData(this ICreateReplayData mod, IBeatmap beatmap, IReadOnlyList<Mod> mods)
        {
            var replayData = mod.CreateReplayData(beatmap, mods);

            return new Score
            {
                Replay = replayData.Replay,
                ScoreInfo =
                {
                    User = new APIUser
                    {
                        // TODO: Some fields weren't copied from replayData.User (namely IsBot and Id). Should ModCreatedUser inherit from APIUser so we could pass it verbatim to avoid future mistakes ?
                        Id = replayData.User.OnlineID,
                        Username = replayData.User.Username,
                        IsBot = replayData.User.IsBot,
                    }
                }
            };
        }
    }
}
