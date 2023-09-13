using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.OCP
{
  public class BestOpenClose
  {
    public record Money
    {
      public decimal Amount { get; init; }
      public string Currency { get; init; }

      public Money(decimal amount, string currency)
      {
        this.Amount = amount;
        this.Currency = currency;
      }
    }

    public interface IPayment
    {
      void Pay(Money money);
    }

    public enum PaymentType
    {
      Cache,
      Credit,
      VirtualWallet
    }

    // Amaç Cache çalışan bir kod bloğu buna dokunmadan yeni bir özellik ile yolumuza devam ederiz. 
    public class CachePayment : IPayment
    {
      public void Pay(Money money)
      {
        Console.WriteLine( $"Nakit ödeme işlemi yapıldı. Ödeme tutarı {money.Amount} {money.Currency} ");
      }
    }

    public class CreditPayment : IPayment
    {
      public void Pay(Money money)
      {
        Console.WriteLine($"Kredi Kartı ile ödeme işlemi yapıldı. Ödeme tutarı {money.Amount} {money.Currency}");
      }
    }

    public class VirtualWalletPayment : IPayment
    {
      public void Pay(Money money)
      {
        Console.WriteLine($"Sanal Kartı ile ödeme işlemi yapıldı. Ödeme tutarı {money.Amount} {money.Currency}");
      }
    }

    public class CoinPayment : IPayment
    {
      public void Pay(Money money)
      {
        Console.WriteLine($"Coin ile ödeme işlemi yapıldı. Ödeme tutarı {money.Amount} {money.Currency}");
      }
    }

    // Dependency Injection ile bağımlık yönetimi

    public class PaymentDIService 
    {
      private readonly IPayment payment;

      public PaymentDIService(IPayment payment) // payment tipinde bir nesne contructor üzerinden alınacak. Payment sınıfları PaymentDIService içerisinde contructor vasıtası ile yüklenencek
      {
        this.payment = payment; // contructor üzerinden alınan instance değerini içerideki payment service almış olduk
      }

      public void Pay(Money money)
      {
        this.payment.Pay(money); // Cache, VirtuaWallet,CreditKart
      }
    }


    public class PaymentService : IPayment
    {
      private PaymentType paymentType;
      private CachePayment cachePayment;
      private CreditPayment creditPayment;
      private VirtualWalletPayment virtualWalletPayment;
      public PaymentService(PaymentType paymentType)
      {
        this.paymentType = paymentType;
        // 3 farklı ödeme olabileceği için çok biçimli çalışabilmek için aşağıdaki servislerin instance aldık.
        this.cachePayment = new CachePayment();
        this.creditPayment = new CreditPayment();
        this.virtualWalletPayment = new VirtualWalletPayment();
      }

      public void Pay(Money money)
      {
        switch (paymentType)
        {
          case PaymentType.Cache:
            this.cachePayment.Pay(money);
            break;
          case PaymentType.Credit:
            this.creditPayment.Pay(money);
            break;
          case PaymentType.VirtualWallet:
            this.virtualWalletPayment.Pay(money);
            break;
          default:
            break;
        }
      }
    }

  }
}
