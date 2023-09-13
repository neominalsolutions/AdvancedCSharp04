using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.LSP
{
  // bir base sınıftan türeyen sınıflar base sınıfların tüm özelliklerini göstermelidir. Base sınıfın özelliği alt sınıflar tarafından kullanılamıyorsa, uygulama içerisinde dummy boş kod blokları oluşur. Buda uygulamanın kırılgan bir yapı sahip olmasına neden olur.
  public class BadLiskov
  {

    // Senaryo: Bizden bir Geometrik şekil kütüphanesi yazmamız istendi. Şuan için iki boyutlu geometrik şekillerin, alan çevre hesaplamarını yapacağız. Ama daha sonrasında 3 boyutlu cisimler alan ve hacim hesabı işlemleri yapabiliriz.

    public abstract class BadShapeBase // instance almayacağımız, Kare, Dikdörtgen, Üçgen, Daire bu şekilde türeteceğiz.
    {
      public double Height { get; set; }
      public double Width { get; set; }
      // abstract sınıflarda abstract içindeki kod blogu algoritması belirli olmayan abstract üyeler tanımlanabilir.
      /// <summary>
      /// Çevre Hesabı yapar
      /// </summary>
      /// <returns></returns>
      public abstract double GetPerimeter(); // çevre hesabı
      /// <summary>
      /// Alan hesabı yapar
      /// </summary>
      /// <returns></returns>
      public abstract double GetArea(); // alan hesapla
     
    }

    // ilk sınıfımız Dikdörtgen

    public class BadRect : BadShapeBase
    {
      public override double GetArea()
      {
        return this.Width * this.Height;
      }

      public override double GetPerimeter()
      {
        return 2 * (this.Width + this.Height);
      }
    }

    public class BadCircle : BadShapeBase
    {
      public int Radius { get; set; }

      // yükseklik ve genişlik circle için dummy propery oldu.

      public override double GetArea()
      {
        return Math.PI * Math.Pow(Radius, 2); // n*r^2
      }

      public override double GetPerimeter()
      {
        return  2* Math.PI * Radius; // 2*n*r
      }
    }

    public class BadSquare : BadShapeBase
    {
      public override double GetArea()
      {
        if(this.Width ==0 || this.Height == 0)
        {
          throw new Exception("Yükseklik veya genişlik 0 olamaz");
        }

        if (this.Width != this.Height)
        {
          throw new Exception("Bu bir kare olamaz");
        }
        else
        {
          return this.Height * this.Width;
          // 4* width
        }

      }

      public override double GetPerimeter()
      {
        if (this.Width != this.Height)
        {
          throw new Exception("Bu bir kare olamaz");
        }
        else
        {
          return 4 * this.Width;
          // 4* width
        }
      }
    }



  }
}
