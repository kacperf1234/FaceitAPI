﻿using System;
using System.Collections.Generic;
using System.Text;
using FaceitAPI.Types;
using Xunit;
using Xunit.Abstractions;
using FaceitAPI.Models;

namespace FaceitAPI.Xunit
{
    public partial class Games_GetGame
    {
        private GameDetails Get(string game = "csgo")
        {
            return new Faceit(new Authorization("316c922d-bfd4-4535-b68d-b8799fe96d47")).GetObject<Games>().GetGame(game);
        }

        [Fact]
        public void NotThrowsExceptions()
        {
            Assert.Null(Record.Exception(() => Get()));
        }

        [Fact]
        public void NotNull()
        {
            Assert.NotNull(Get());
        }

        [Fact]
        public void ValidRootData()
        {
            var r = Get();

            Assert.NotNull(r.Assets);
            Assert.NotNull(r.GameId);
            Assert.NotNull(r.LongLabel);
            Assert.NotNull(r.Order);
            Assert.NotNull(r.ParentGameId);
            Assert.NotNull(r.Platforms);
            Assert.NotNull(r.Regions);
            Assert.NotNull(r.ShortLabel);
        }

        [Fact]
        public void ValidAssets()
        {
            var r = Get().Assets;

            Assert.NotNull(r.Cover);
            Assert.NotNull(r.FeaturedImageL);
            Assert.NotNull(r.FeaturedImageM);
            Assert.NotNull(r.FeaturedImageS);
            Assert.NotNull(r.FlagImageIcon);
            Assert.NotNull(r.FlagImageL);
            Assert.NotNull(r.FlagImageM);
            Assert.NotNull(r.FlagImageS);
            Assert.NotNull(r.LandingPage);
        }
    }

    public partial class Games_GetGame
    {
        internal ITestOutputHelper Out;

        public Games_GetGame(ITestOutputHelper helper)
        {
            Out = helper;
        }
    }
}
