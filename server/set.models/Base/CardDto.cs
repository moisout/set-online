using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set.models.Base
{
  public class CardDto
  {
    public int Id { get; set; }

    public Color Color { get; set; }

    public Symbol Symbol { get; set; }

    public Shading Shading { get; set; }

    public int Number { get; set; }
  }
}
