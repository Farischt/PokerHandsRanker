using System;
using System.Collections.Generic;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class PokerHands : IPokerHands
    {
        private readonly IDeckService _deckService;
        private readonly IHandPrinterService _handPrinterService;
        private readonly IHandRankerService _handRankerService;

        public PokerHands(IHandPrinterService handPrinterService, 
            IDeckService deckService, 
            IHandRankerService handRankerService)
        {
            _handPrinterService = handPrinterService;
            _deckService = deckService;
            _handRankerService = handRankerService;
        }

        public void Rank()
        {
            var gameOver = false;
            while (!gameOver)
            {
                string inputNPlayers;
                int nPlayer = 0;
                do
                {
                    Console.WriteLine("Enter the number of players");
                    try
                    {
                        inputNPlayers = Console.ReadLine();
                        nPlayer = Int32.Parse(inputNPlayers);
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine(exception);
                    }
                }
                while (nPlayer < 2 || nPlayer > 8);

                string inputNDecks;
                int nDecks = 0;
                do
                {
                    Console.WriteLine("Enter the number of decks");
                    try
                    {
                        inputNDecks = Console.ReadLine();
                        nDecks = Int32.Parse(inputNDecks);
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine(exception);
                    }
                }
                while (nDecks < 1 || nDecks > 4);

                var hands = new List<List<string>>();
                var deck = _deckService.InitDeck();

                for (var i = 0; i < nPlayer; i++)
                {
                    hands.Add(new List<string>());
                    for (int j = 0; j < 5; j++)
                    {
                        _deckService.DrawCard(hands[i], deck);
                    }

                }

                var rankHand = new List<IRank>();
                for (var i = 0; i < nPlayer; i++)
                {
                    rankHand.Add(_handRankerService.RankHand(hands[i]));
                }
                
                for (var i = 0; i < nPlayer; i++)
                {
                    _handPrinterService.PrintHand(i + 1, hands[i], rankHand[i]);
                }

                var winner = _handRankerService.RankHands(hands);

                Console.WriteLine(winner != 0 ? $"Player {winner} won this round !" : "It's a tie !");
                Console.WriteLine("Play another hand ? Or press 'q' to quit...");
                if (Console.ReadKey().KeyChar.Equals('q'))
                {
                    gameOver = true;
                }
                Console.Clear();
            }
        }
    }
}