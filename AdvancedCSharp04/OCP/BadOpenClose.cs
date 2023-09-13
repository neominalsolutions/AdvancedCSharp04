using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.OCP
{
  // Bir sınıf gelişime açık değişme kapalı olmalıdır.
  // Uygulama yeni gelen bir istekde sınıfın içindeki kodlara müdahale edip kaynak kodu değiştirme yerine, yeni sınıflar açarak uygulamanın yeni isteklere adepte olması sağlanmalıdır. 
  public class BadOpenClose
  {

    public class PaymentService
    {
      private string paymentType; // Cash, Credit, Virtual Card

      public PaymentService(string paymentType)
      {
        this.paymentType = paymentType;
      }

      public void Pay(decimal amount, string currency)
      {
        // Coin ile ödeme alma
        // İstanbul Kart ödeme

        // Amaç: Ödeme yapmak ama bunu farklı şekillerde yapmak
        // OOP, polymorphism'e göre bir işi farklı şekilde yapılabilmelidir.

        if(this.paymentType == "Cash")
        {
          Console.WriteLine($"Nakit ödeme yapıldı. Ödeme tutarı {amount} {currency}");
        }
        else if(this.paymentType == "Credit")
        {
          Console.WriteLine($"Kredi kartı ödeme yapıldı. Ödeme tutarı {amount} {currency}");
        }
        else if(this.paymentType == "Virtual Wallet")
        {
          Console.WriteLine($"Sanal Cüzdandan ödeme yapıldı. Ödeme tutarı {amount} {currency}");
        }
        else if(this.paymentType == "Coin")
        {
          Console.WriteLine($"Coin ile ödeme yapıldı. Ödeme tutarı {amount} {currency}");
        }

      }

    }
  }
}
