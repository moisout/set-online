using set.models.Base;
using set.models.Game;
using set.service.Common.Interface;
using set.service.Practice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set.service.Practice
{
  public class PracticeService : IPracticeService
  {
    public PracticeService(ICardGeneratorService cardGeneratorService)
    {
      CardGeneratorService = cardGeneratorService;
    }

    private ICardGeneratorService CardGeneratorService;

    public PracticeTableDto GetPracticeTable()
    {
      int cardCount = 12;
      List<CardDto> CardList = CardGeneratorService.GetRandomCardDeck(cardCount);
    }
  }
}
