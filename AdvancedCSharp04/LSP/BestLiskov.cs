using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.LSP
{

  public class BestLiskov
  {
    public abstract class BestShapeBase
    {
      public abstract double GetPerimeter();
      public abstract double GetArea();

    }

    public class BestSquare : BestShapeBase
    {
      public int Corner { get; set; }

      public override double GetArea()
      {
        return Math.Pow(Corner, 2);
      }

      public override double GetPerimeter()
      {
        return 4 * Corner;
      }
    }

    public class BestRect : BestShapeBase
    {
      public double Width { get; set; }
      public double Height { get; set; }

      public override double GetArea()
      {
        return this.Width * this.Height;
      }

      public override double GetPerimeter()
      {
        return 2 * (this.Width + this.Height);
      }
    }

    public class BestCircle : BestShapeBase
    {
      public int Radius { get; set; }
      public override double GetArea()
      {
        return Math.PI * Math.Pow(Radius, 2);
      }

      public override double GetPerimeter()
      {
        return 2 * Math.PI * Radius;
      }
    }


  }
}
