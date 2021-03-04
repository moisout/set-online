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
    List<CardDto> Cards { get; set; }

    int[,,] PossibleSets { get; set; }
  }
}
