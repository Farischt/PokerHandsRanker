using System;
using System.Collections.Generic;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class HandRankerService : IHandRankerService
    {
        private readonly IRankService _rankService;

        public HandRankerService(IRankService rankService)
        {
            _rankService = rankService;
        }

        //The function below is a WIP
        public int RankHands(List<List<string>> hands)
        {
            var rankHand = new List<IRank>(hands.Count);
            for (var i = 0; i < hands.Count; i++)
            {
                rankHand.Add(RankHand(hands[i]));
            }

            bool? isWinning;
            int pWon = 0;

            for (var i = 1; i < hands.Count; i++)
            {
                isWinning = rankHand[pWon].IsBetterRank(rankHand[i]);
                if (isWinning == false)
                {
                    pWon = i;
                }
            }

            return pWon + 1;
        }

        public IRank RankHand(IList<string> hand)
        {
            return _rankService.GetRankFromHand(hand);
        }
    }
}