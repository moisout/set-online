using set.models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set.service.Common.Interface
{
  public interface ISetValidatorService
  {
    int[,,] GetValidFromDeck(List<CardDto> cardList);
  }
}
