using set.models.Base;
using set.service.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace set.service.Common
{
  public class CardGeneratorService: ICardGeneratorService
  {
    List<CardDto> GetRandomCardDeck(int cardCount)
    {
      Random random = new Random();
      List<CardDto> cardDeckList = new List<CardDto>();

      for (int i = 0; i < cardCount; i++)
      {
        int randomNumber = random.Next(0, 80);
        if (!cardDeckList.Any(e => e.Id == randomNumber))
        {
          cardDeckList.Add(CardCollection.Cards[randomNumber]);
        }
      }
      return cardDeckList;
    }
  }
}
