using set.models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set.models.Game
{
  public class PracticeTableDto
  {
    public PracticeTableDto(List<CardDto> cards, List<int[]> possibleSets)
    {
      Cards = cards;
      PossibleSets = possibleSets;
    }

    public List<CardDto> Cards { get; set; }

    public List<int[]> PossibleSets { get; set; }
  }
}
