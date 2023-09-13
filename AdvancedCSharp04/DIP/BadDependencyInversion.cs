using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.DIP
{
  // Bir başka bir sınıftan bir hizmet talep ettiğinde, bu hizmet talep ettiği sınıfa ait kodlar, hizmet talep edilen sınıf içerisinde direkt olarak kullanılıyorsa. O zaman bu iki sınıf arasında sıkı sıkıya bağlılık vardır. Biz bu sıkı sıkıya olan bağımlılığa (tightCoupled) diyoruz. Bunu aşabilmek için 2 sınıf arasına bir arayüz koyulur ve bu iki sınıf ortak bir arayüz üzerinden birbileri ile bağımsız bir şekilde haberleşir. DIP prensibi uygulanadığında bağımlıklar contructor vasıtası ile aktarılır. Bu yaklaşım en popüler yaklaşımdır. Bu sebeple Depency Injectioon ile birlikte kullanılmaktadır. DIP + DI zayıf bağılık ve dependency yönetim sağlarız. 
  public class BadDependencyInversion
  {
    // Örnek Senaryo UserRepository sınıfımız var ve kayıt sonraki db log atmak isityoruz. Yanlız log işlemleri file, db, ve external olmak üzere 3 farklı durumu temsil edebiliyor. Bu sebeple 3 farklı duruma özgü bir tanımlama yapmalıyız.

    public class FileLogger
    {
      public void Log(string logLevel, string message)
      {

      }
    }

    public class DbLogger
    {
      public void Log(string logLevel, string message)
      {

      }
    }

    // Evdeki Elektrik Tesisatı
    public class BadUserRepository
    {
      // üst seviye class BadUserRepository, alt seviye FileLogger direkt kendi içinde çağırmamalıdır. 
      // Bunun yerine alt ve üst sınıf bir inteface vasıtası ile konuşmalıdır.
      // Kablomuz (35 yerde referansı var)
      private readonly FileLogger fileLogger = new FileLogger();
      private readonly DbLogger dbLogger = new DbLogger();

      public void Create()
      {
        // db işlemleri
        fileLogger.Log("Info", "User Created");
        dbLogger.Log("Info", "User Created");
      }

    }


  }
}
