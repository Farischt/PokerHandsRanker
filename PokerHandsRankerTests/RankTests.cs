using NFluent;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;
using System.Collections.Generic;

namespace PokerHandsRankerTests
{
    public class RankTests
    {
        private IRankService _rankService;

        [SetUp]
        public void SetUp()
        {
            _rankService = new RankService();
        }

        [Test]
        public void Should_Have_Rank1_Better_Than_Rank2_When_Higher()
        {
            // TODO
            var hand1 = new List<string> { "AC", "KC", "QC", "JC", "TC" };
            var hand2 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            var rank1 = _rankService.GetRankFromHand(hand1);
            var rank2 = _rankService.GetRankFromHand(hand2);
            Assert.Greater(rank1.RankValue, rank2.RankValue);
        }

        [Test]
        public void Should_Have_Rank2_Better_Than_Rank1_When_Lower()
        {
            // TODO
            var hand1 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            var hand2 = new List<string> { "AC", "KC", "QC", "JC", "TC" };
            var rank1 = _rankService.GetRankFromHand(hand1);
            var rank2 = _rankService.GetRankFromHand(hand2);
            Assert.Greater(rank2.RankValue, rank1.RankValue);
        }

        [Test]
        public void Should_Have_Rank1_Better_Than_Rank2_When_Same_Rank_But_Higher_Card()
        {
            // TODO
            var hand1 = new List<string> { "6C", "7C", "8C", "9C", "TC" };
            var hand2 = new List<string> { "2C", "3C", "4C", "5C", "6C" };
            var rank1 = _rankService.GetRankFromHand(hand1);
            var rank2 = _rankService.GetRankFromHand(hand2);
            Assert.IsTrue(rank1.IsBetterRank(rank2));
        }

        [Test]
        public void Should_Have_A_Tie_When_Ranks_Are_The_Same()
        {
            // TODO
            var hand1 = new List<string> { "6C", "7C", "8C", "9C", "TC" };
            var hand2 = new List<string> { "6D", "7D", "8D", "9D", "TD" };
            var rank1 = _rankService.GetRankFromHand(hand1);
            var rank2 = _rankService.GetRankFromHand(hand2);
            Assert.IsNull(rank1.IsBetterRank(rank2));
        }
    }
}
