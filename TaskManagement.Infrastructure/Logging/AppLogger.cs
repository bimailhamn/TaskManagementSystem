using Microsoft.Extensions.Logging;

namespace TaskManagement.Infrastructure.Logging
{
    /// <summary>
    /// Provides an implementation of application-level logging.
    /// </summary>
    /// <typeparam name="T">The type for which logs are being created.</typeparam>

    public interface IAppLogger<T>
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception exception = null);
    }

    public class AppLogger<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppLogger{T}"/> class.
        /// </summary>
        /// <param name="logger">The underlying logger implementation.</param>
        public AppLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception associated with the error (optional).</param>
        public void LogError(string message, Exception exception = null)
        {
            if (exception != null)
            {
                _logger.LogError(exception, message);
            }
            else
            {
                _logger.LogError(message);
            }
        }
    }
}
