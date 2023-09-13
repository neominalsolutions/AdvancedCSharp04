using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp04.DIP
{
  public class BestDependecyInversion
  {
    public enum LogLevel
    {
      TRACE,
      FATAL,
      ERROR,
      DEBUG,
      WARN,
      INFO
    }

    public interface ILogger
    {
      void Log(LogLevel logLevel, string message);
    }

    public class BestFileLogger : ILogger
    {
      public void Log(LogLevel logLevel, string message)
      {
        throw new NotImplementedException();
      }
    }

    public class BestDatabaseLogger : ILogger
    {
      public void Log(LogLevel logLevel, string message)
      {
        throw new NotImplementedException();
      }
    }

    public class JSONLogger:ILogger
    {
      public void Log(LogLevel logLevel, string message)
      {
        throw new NotImplementedException();
      }
    }

    public interface IBestUserRepository
    {

    }

    public class BestManagerUserRepository: IBestUserRepository
    {

    }

    public class BestUserRepository: IBestUserRepository
    {
      // FileLogger ile DatabaseLogger ILogger interface üzerinden bağlandık.
      private readonly IList<ILogger> loggers; // Dependency Inversion

      // privatre readonly IUserRepository;
      // private readOnly IPhotoService;

      public BestUserRepository(IList<ILogger> loggers) // Dependency Injectioın
      {
        this.loggers = loggers;
      }

      public void Create()
      {
        // veri tabanı ilemleri
        log();
      }

      public void Delete()
      {
        log();
      }

      private void log()
      {
        loggers.ToList().ForEach(lg => lg.Log(LogLevel.INFO, "User Created"));
      }
    }

  }
}
