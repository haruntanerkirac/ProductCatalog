﻿using NLog;
using ProductCatalog.Business.Abstract;

namespace ProductCatalog.Business.Concrete
{
    public class LoggerManager : ILoggerService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}
