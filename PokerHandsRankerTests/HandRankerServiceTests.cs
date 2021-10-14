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
            var hands = new List<List<string>>();
            var hand1 = new List<string>() { "TD", "3C", "9C", "TC", "9D" };
            hands.Add(hand1);
            _handRankerService.RankHands(hands);
            _rankService.Received().GetRankFromHand(hands[0]);
        }

        [Test]
        public void Should_Have_Player1_Win_If_His_Hand_Is_Better()
        {
            // TODO
            var hands = new List<List<string>>();
            var hand1 = new List<string>() { "TD", "3C", "9C", "TC", "9D" };
            var hand2 = new List<string>() { "AS", "AD", "5C", "JS", "3H" };
            hands.Add(hand1);
            hands.Add(hand2);
            Assert.That(_handRankerService.RankHands(hands), Is.EqualTo(1));
        }


        [Test]
        public void Should_Have_Player2_Win_If_His_Hand_Is_Better()
        {
            // TODO
            var hands = new List<List<string>>();
            var hand1 = new List<string> { "AS", "AD", "5C", "JS", "3H" };
            var hand2 = new List<string> { "AC", "KC", "QC", "JC", "TC" };
            hands.Add(hand1);
            hands.Add(hand2);
            Assert.That(_handRankerService.RankHands(hands), Is.EqualTo(2));
        }


        [Test]
        public void Should_Have_A_Tie_If_Hands_Are_Equal()
        {
            // TODO
            var hands = new List<List<string>>();
            var hand1 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            var hand2 = new List<string> { "TD", "3C", "9C", "TC", "9D" };
            hands.Add(hand1);
            hands.Add(hand2);
            Assert.That(_handRankerService.RankHands(hands), Is.EqualTo(1));
        }
    }
}
