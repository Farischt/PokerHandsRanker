using System.Collections.Generic;

namespace PokerHandsRanker.Interfaces
{
    public interface IHandRankerService
    {
        int RankHands(List<List<string>> hands);
        IRank RankHand(IList<string> hand);
    }
}