using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.ISP
{
  public class BestInterfaceSeggragation
  {

    /// <summary>
    /// Şifreleme için kullanılır
    /// </summary>
    public interface IEncryptor
    {
      string Encrypt(string plainText);
    }

    /// <summary>
    /// Şifre çözmek için kullanılır
    /// </summary>
    public interface IDecryptor
    {
      string Decrypt(string chipperText);
    }

    public class MyPasswordHasher : IEncryptor
    {
      public string Encrypt(string plainText)
      {
        return "3243242dsf-32432432";
      }
    }

    // bir sınıf birden fazla interface implemente eder. bu yüzden esnek bir yapı oluştu.
    public class MyAES : IEncryptor, IDecryptor
    {
      public string Decrypt(string chipperText)
      {
        return "hello";
      }

      public string Encrypt(string plainText)
      {
        return "6x0b-32432-3242";
      }
    }
  }
}
