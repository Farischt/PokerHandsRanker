using NFluent;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;
using System.Collections.Generic;

namespace PokerHandsRankerTests
{
    public class DeckServiceTests
    {
        private IDeckService _deckService;

        [SetUp]
        public void SetUp()
        {
            _deckService = new DeckService();
        }

        [Test]
        public void Should_Have_Complete_52_Cards_Deck_After_Initialisation()
        {
            var deck = _deckService.InitDeck();
            Check.That(deck.Count).IsEqualTo(52);
            Check.That(deck).ContainsNoDuplicateItem();
        }

        [Test]
        public void Should_Draw_A_Card_From_Deck_And_Place_It_In_Hand()
        {
            // TODO
            var deck = _deckService.InitDeck();
            var deckCount = deck.Count;
            var hand = new List<string>();
            var handCount = hand.Count;
            _deckService.DrawCard(hand, deck);
            Assert.That(hand, Has.Exactly(handCount + 1).Items);
            Assert.That(deck, Has.Exactly(deckCount - 1).Items);
        }
    }
}
