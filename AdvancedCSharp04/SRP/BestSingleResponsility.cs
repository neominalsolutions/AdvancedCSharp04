using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.SRP
{
  // Bir sınıfın değişmesi için sınıfa tek bir sorumlulk verilmelidir.
  public class BestSingleResponsility
  {
    // Entity
    public class Order
    {
      public int OrderId { get; set; } // Fiş No

      public int CustomerId { get; set; } // Hangi Müşteri

      public string Address { get; set; } // Hangi Adrese
      public List<OrderItem> Items { get; set; } // Hangi ürünleri
    }

    // Entity
    public class OrderItem
    {
      public int OrderId { get; set; } // Fiş No
      public int Quantity { get; set; } // Kaç adet
      public string ProductId { get; set; } // Hangi Product
    }

    // OrderSubmit işleminde gelen isteği karşıladığımız Request Object
    public class OrderSubmitDto
    {
      [Required(ErrorMessage = "Müşteri zorunludur")]
      public string CustomerName { get; set; } // Şu müşteri

      [Required(ErrorMessage = "Adres zorunludur")]
      public string Address { get; set; } // Bu adrese sipariş verdim

      [Required(ErrorMessage = "Sepete ürün giriniz")]
      public IDictionary<string,int> CartItems { get; set; } // Şu ürünlerden aldı
    }
    // Gelen uygulama isteklerini karşılayan sınıf
    public class OrderApplicationService // OrderController
    {
      // diğer alt servislere bağlanan submitOrder methodu çağırıldığında alt işlemleri yöneten bir sınıf haline geldi.
      // Yazılımda bölge alttaki kompleks işlemleri çağırıp ilgili işlemi encapsulate eden sınıflara facade sınıf deriz. Facade Design Pattern karşılık gelir.
      private readonly OrderRepository oR = new OrderRepository();

      // 1. Sipariş oluştuğunda 
      // 2. Sipariş iade edildiğinde
      // 3. Siparişler listelenirken
      // 4. Siparişler arandığında

      private readonly EmailService es = new EmailService();

      // 1. Sipariş sonrası Siparişi mail atma
      // 2. Ürünlerin kampanyaları ile ilgili müşterilere mail gönderme

      private readonly BillingService bs = new BillingService();

      // 1. Sipariş oluştuğunda fatura oluşturmam lazım
      // 2. İade durumunda Faturanın iptalini sağlamam lazım

      private readonly ShippingService sp = new ShippingService();
      // Kargo sınıfını neden ayırtık
      // 1. Sipariş oluşurken kargoya vermem lazım
      // 2. Sipariş iptal durumunda kargo iptali yapmam lazım
      // 3. Sipariş geri iade durumunda yeni bir iade kargosu başlatmam lazım
      public void SubmitOrder(OrderSubmitDto dto)
      {
        // dto Validasyon bir sorun yoksa

        if(dto.CartItems.Count() == 0)
        {
          throw new Exception("Sepette ürün yok");
        }

        // dto to entity mapping
        var order = new Order();
        order.Address = dto.Address;
        order.CustomerId = 1;

        foreach (var cartItem in dto.CartItems)
        {
          var orderItem = new OrderItem();
          orderItem.OrderId = order.OrderId;
          orderItem.ProductId = cartItem.Key; // ProductName
          orderItem.Quantity = cartItem.Value; // Quantity
          order.Items.Add(orderItem);
        }

        oR.Create(order); // Kayıt yapıldı
        es.SendEmail("info@arhitect.com", dto.CustomerName, "Siparişiniz oluştu");
        bs.GenerateBill(order); // fatura oluştur
        sp.StartShipping(order); // kargoya ver

      }


      public void GivingBackOrder(Order dto)
      {

      }

    }

    // Siparişin kargoya verilmesinden sorumlu sınıf
    public class ShippingService
    {
      public void StartShipping(Order order) { }
    }

    // faturanın oluşmasın sorumlu sınıf
    public class BillingService
    {
      public void GenerateBill(Order order) { }
    }

    public class OrderRepository
    {
      public void Create(Order order) { }
    }

    public class EmailService
    {
      public void SendEmail(string from, string to, string message) { }
    }



  }
}
