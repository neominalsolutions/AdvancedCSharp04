using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.ISP
{
  // SRP çok benzeyen bir solid prensibi, SRP class ların tek bir sorumluluk üzerine kurulmasına odaklanırken, ISP ise interfacelerin değişmek için tek bir sorumluluk üstlenmesine odaklanır. Bu sadece interface implemente olan sınıflar kullanılamayacak olan (dummy) method (davranışlar), property (özelliklere) sahip olmaz. Bu sebep ile interfacelere atomik olarak tanımlanmalıdır. 
  public class BadInterfaceSeggragation
  {

    // senaryo => bizden şifreleme işlemlerini yöneteceğimiz bir servis yazmız istendi. Fakat bu servis farklı şifreleme algoritmaları ile çalışabilir. Simetrik, Hash ve Asimetrik şifreleme algoritmaları kullanabilir. 
    // Simetrik , Tek bir Shared Key üzerinden şifrelemeyi temsil eder. Şifreleme ve Şifre çözme yapılabilir
    // Hash, şifreleme yapılır, şifre çözülemez. Aynı metinsel ifade Hashlendiğinde aynı sonucu üretir. Hash kıyasalaması ile değer eşitliği bulunur. En çok kullanıcı şifreleri için kullanılır.
    // Asimetrik, Private ve Public Key den oluşur. Genelde önemlilik derecesi yüksek olan dosyalarda tercih edilir. Bankalardaki kasa işlemine benzer bir algoritma uygular. Private key tek başına şifreyi çözemek için yeterli değildir. Public key ile birlikte şifre çözülür. Şifreyi çözmek için hem private hemde public key ihtiyaç vardır. Asimterik şifreleme algoritmaları uzun süren işlemlerde sonuç verir. Genelde ihtiyaç olmadıkça performans açısından tercih edilmez. JWT gibi keyleri Simetrik ve Asimetik olarak oluşturabiliriz.

    public interface ICrypto
    {
      /// <summary>
      /// şifre çöz
      /// </summary>
      /// <param name="plainText"></param>
      /// <returns></returns>
      string Encrypt(string plainText);

      /// <summary>
      /// şifrele
      /// </summary>
      /// <param name="chipperText"></param>
      /// <returns></returns>
      string Decrypt(string chipperText); // chipperText şifreli dosya
    }

    public class SimetricAES : ICrypto
    {
      public string Decrypt(string chipperText)
      {
        return "hello";
      }

      public string Encrypt(string plainText)
      {
        return "Ax45l00sd";
      }
    }

    public class PasswordHasher : ICrypto
    {
      /// <summary>
      /// Sakın ola bu method çağırma çünü bu method şifre çözemez.
      /// </summary>
      /// <param name="chipperText"></param>
      /// <returns></returns>
      /// <exception cref="NotImplementedException"></exception>
      public string Decrypt(string chipperText)
      {
        throw new NotImplementedException();
      }

      public string Encrypt(string plainText)
      {
        return "w34324324-23432-324532";
      }
    }





  }
}
