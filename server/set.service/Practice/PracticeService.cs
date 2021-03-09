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
    private ICardGeneratorService CardGeneratorService;
    private ISetValidatorService SetValidatorService;

    public PracticeService(ICardGeneratorService cardGeneratorService, ISetValidatorService setValidatorService)
    {
      CardGeneratorService = cardGeneratorService;
      SetValidatorService = setValidatorService;
    }

    public PracticeTableDto GetPracticeTable()
    {
      int cardCount = 12;
      List<CardDto> cardList = CardGeneratorService.GetRandomCardDeck(cardCount);
      List<int[]> validSetList = SetValidatorService.GetValidFromList(cardList);

      return new PracticeTableDto(cardList, validSetList);
    }
  }
}
