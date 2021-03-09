using set.models.Base;
using set.service.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set.service.Common
{
  public class SetValidatorService : ISetValidatorService
  {
    public List<int[]> GetValidFromList(List<CardDto> cardList)
    {
      List<int[]> ValidSetList = new();

      cardList.ForEach(card1 =>
      {
        cardList.ForEach(card2 =>
        {
          cardList.ForEach(card3 =>
          {
            if (card1.Id != card2.Id && card1.Id != card3.Id && card2.Id != card3.Id && IsSet(card1, card2, card3))
            {
              int[] validSet = new int[3] { card1.Id, card2.Id, card3.Id };
              bool existsInValidSetList = ValidSetList.Any(el =>
              {
                return !el.Except(validSet).Any();
              });
              if (!existsInValidSetList)
              {
                ValidSetList.Add(validSet);
              }
            }
          });
        });
      });

      return ValidSetList;
    }

    public bool IsSet(CardDto card1, CardDto card2, CardDto card3)
    {
      bool colorCondition = FulfillsCondition(card1.Color, card2.Color, card3.Color);

      bool symbolCondition = FulfillsCondition(card1.Symbol, card2.Symbol, card3.Symbol);

      bool shadingCondition = FulfillsCondition(card1.Shading, card2.Shading, card3.Shading);

      bool numberCondition = FulfillsCondition(card1.Number.ToString(), card2.Number.ToString(), card3.Number.ToString());

      if (colorCondition && symbolCondition && shadingCondition && numberCondition)
      {
        return true;
      }
      return false;
    }

    private bool FulfillsCondition(string property1, string property2, string property3)
    {
      bool condition = false;
      if (((property1 == property2) && (property1 == property3)))
      {
        condition = true;
      }
      else if ((property1 != property2) && (property1 != property3) && (property2 != property3))
      {
        condition = true;
      }
      return condition;
    }
  }
}
