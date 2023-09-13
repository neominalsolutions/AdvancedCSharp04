using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.SRP
{
  public class BadSingleResposibity
  {

    // Bir sınıfın veya methodunun değişmesi tek bir sebebin olması gerekir.
    // Bir sınıf birden fazla sorumluluğa sahip olmamlıdır.
    // Entities, Dtos, Validations, Event

    // E-Ticaret sitesin sipariş alma işlemi
    // Parçala böl yönet.

    public class CartDto
    {
      public string Customer { get; set; }
      public string Address { get; set; }
      public IDictionary<string, int> CartItems { get; set; }

    }

    // OrderDto ve OrderEntity gibi
    public class Order
    {
      public int OrderId { get; set; }
      public string CustomerName { get; set; }
      public string Address { get; set; }

      public List<OrderDetail> OrderDetails { get; set; }

    }

    public class OrderDetail
    {
      public int OrderId { get; set; }
      public int ProductId { get; set; }
      public int Quantity { get; set; }

    }

    public class OrderService
    {

      public void SubmitOrder(Order order)
      {
        // Order tablosuna kayıt at (OrderRepository)
        // Sipariş Numarası oluştur, (OrderNumberGenerator)
        // Siparişi Mail At (EmailService)
        // Faturayı oluştur. (BillingService)
        // Kargoya verme (ShipingService)

        // herşeyin algoritmasını SubmitOrder içerisinde yazdık.
      }

    }






  }
}
