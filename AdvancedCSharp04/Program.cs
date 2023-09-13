

using static AdvancedCSharp04.DIP.BestDependecyInversion;
using static AdvancedCSharp04.ISP.BadInterfaceSeggragation;
using static AdvancedCSharp04.ISP.BestInterfaceSeggragation;
using static AdvancedCSharp04.LSP.BadLiskov;
using static AdvancedCSharp04.LSP.BestLiskov;
using static AdvancedCSharp04.OCP.BestOpenClose;
using static AdvancedCSharp04.SRP.BestSingleResponsility;

public class Program
{
  public static void Main(string[] args)
  {
    // SRPSample();
    // ISPSample();
    // OCPSample();
    // LSPSample();
  }

  public static void DIPSample()
  {
    var loggers = new List<ILogger>();
    loggers.Add(new BestFileLogger());
    BestUserRepository br = new BestUserRepository(loggers);
    br.Create();

    // sadece file log işlemi
    var loggers2 = new List<ILogger>();
    loggers2.Add(new BestFileLogger());
    loggers2.Add(new BestDatabaseLogger());
    loggers2.Add(new JSONLogger());
    BestUserRepository br2 = new BestUserRepository(loggers);
    br2.Create();

  }

  public static void LSPSample()
  {
    BadCircle bc = new BadCircle();
    bc.Radius = 4;
    //bc.Height = 1;
    //bc.Width = 1;
    bc.GetPerimeter();

    // Liskov doğru bir şekilde uygulama için aşağı örnek senedrayo için sorulacak sorularımız.

    // Kare Bir şekil mi ? Hayır kalıtım ile alakası yok
    // Her şeklin Alanı hesaplanır mı ? Evet 
    // Her şeklin çevresi varmı ? Evet 
    // Her şeklin yarı çapı var mı ? Hayır (Bu özellik Base bir özellik olmaz)
    // Her şeklin hiptenüsü var mı ? 
    // Her şeklin kenar var mı ? Hayır Daire Kenar yok.

    BadSquare bs = new BadSquare(); // extends BestShapeBase
    bs.Height = 5;
    bs.Width = 5;
    bs.GetPerimeter();

    // Best Example

    BestCircle bcc = new BestCircle();
    bcc.Radius = 5;
    bcc.GetArea();

    BestRect br = new BestRect();
    br.Width = 5;
    br.Height = 10;
    br.GetArea();

  }

  public static void OCPSample()
  {
    start:

    Console.WriteLine("Hangi ödeme yöntemini kullanmak istiyorsunuz, Nakit için C, Kredi Kartı için K, Sanal Kart için W, ve Coin için B");
    ConsoleKeyInfo c = Console.ReadKey();

    IPayment payment = null;

    // Arayüz işlemine göre bu kod blogunda değişiklik olur.
    // aşağıdaki kod blogu kullandığınız platformda arayüze göre değişkenlik gösterir.

    switch (c.Key)
    {
      case ConsoleKey.C:
        payment = new CachePayment();
        break;
      case ConsoleKey.K:
        payment = new CreditPayment();
        break;
      case ConsoleKey.W:
        payment = new VirtualWalletPayment();
        break;
      case ConsoleKey.B:
        payment = new CoinPayment();
        break;
      default:
        break;
    }


    if(payment != null)
    {
      // instance alınmış servisi PaymentDIService içerisinde enjecte ettim.
      // Dependency Injection bir hizmetin, başka hizmet sınıfı içerisine contructor, method veya propery olarak enjekte edilmesi sağlayan bir tasarım deseni. Sınıf bağımlılıklarını yönettiğimiz bir tasarım deseni. Sınıf bağımlılıkları Arayüz veya Abstract class ile yönetilirse uygulama esnek farklı yapılar ile çalışan bilen bir uygulama haline.
      var paymentDI = new PaymentDIService(payment);
      paymentDI.Pay(new Money(currency: "TL", amount: 100)); // Polimorfik bir şekilde ödeme işleminin kullanıcı tarafından seçilen değere göre tanımlanmasını sağlayacaktır.
    }
    else
    {
      Console.WriteLine("Lütfen bir ödeme tipi seçiniz");
    }


    goto start;

  }

  public static void ISPSample()
  {
    // Bad Example
    var hasher = new PasswordHasher();
    string text = hasher.Encrypt("deneme");

    //hasher.Decrypt(text); Decrpt edemez Hash algoritması olduğu için dummy method oluştu.


    // Best Example

    var hasher2 = new MyPasswordHasher();
    string text2 = hasher2.Encrypt("deneme");
   

  }

  public static void SRPSample()
  {
    var request = new OrderSubmitDto();
    request.Address = "İstanbul, Üsküdar, Bahçeli Sok Cumhuriyet Cad. No:4 Daire 3";
    request.CustomerName = "Mustafa";
    request.CartItems = new Dictionary<string, int>();
    request.CartItems.Add("Polo Yaka Kazak", 3);
    request.CartItems.Add("Deniz Şortu", 1);

    var orderAppService = new OrderApplicationService();
    orderAppService.SubmitOrder(request); // Sipariş süreci başladı.

  }
}
