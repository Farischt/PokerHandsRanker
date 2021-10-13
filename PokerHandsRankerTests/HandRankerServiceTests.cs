using NFluent;
using NSubstitute;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;
using System.Collections.Generic;

namespace PokerHandsRankerTests
{
    public class HandRankerServiceTests
    {
        private IHandRankerService _handRankerService;
        private IRankService _rankService;

        [SetUp]
        public void SetUp()
        {
            _rankService = Substitute.For<IRankService>();
            _handRankerService = new HandRankerService(_rankService);
        }

        [Test]
        public void Should_Call_IRankService_When_Ranking_Hands()
        {
            // TODO
            var hand1 = new List<string>();
            var hand2 = new List<string>();
            _handRankerService.RankHands(hand1, hand2);
            _rankService.Received().GetRankFromHand(hand1);
        }

        [Test]
        public void Should_Have_Player1_Win_If_His_Hand_Is_Better()
        {
            // TODO
            var hand1 = new List<string>() { "TD", "3C", "9C", "TC", "9D" };
            var hand2 = new List<string>() { "AS", "AD", "5C", "JS", "3H" };
            Assert.That(_handRankerService.RankHands(hand1, hand2), Is.EqualTo(1));
        }


        [Test]
        public void Should_Have_Player2_Win_If_His_Hand_Is_Better()
        {
            // TODO
            IList<string> hand2 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            IList<string> hand1 = new List<string> { "AS", "AD", "5C", "JS", "3H" };
            Assert.That(_handRankerService.RankHands(hand1, hand2), Is.EqualTo(2));
        }


        [Test]
        public void Should_Have_A_Tie_If_Hands_Are_Equal()
        {
            // TODO
            IList<string> hand1 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            IList<string> hand2 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            Assert.That(_handRankerService.RankHands(hand1, hand2), Is.EqualTo(0));
        }
    }
}
