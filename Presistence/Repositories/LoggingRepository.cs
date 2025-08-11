using Microsoft.Extensions.Logging;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly ILogger<LoggingRepository> _logger;

        public LoggingRepository(ILogger<LoggingRepository> logger)
        {
            _logger = logger;
        }

        public void LogDatabaseOperation(string operation, string entity, object? id = null)
        {
            if (id != null)
            {
                _logger.LogInformation("Database {Operation} on {Entity} with ID: {Id}", operation, entity, id);
            }
            else
            {
                _logger.LogInformation("Database {Operation} on {Entity}", operation, entity);
            }
        }

        public void LogDatabaseError(string operation, string entity, Exception ex, object? id = null)
        {
            if (id != null)
            {
                _logger.LogError(ex, "Database {Operation} failed on {Entity} with ID: {Id}", operation, entity, id);
            }
            else
            {
                _logger.LogError(ex, "Database {Operation} failed on {Entity}", operation, entity);
            }
        }

        public async Task<T> LogDatabaseOperationAsync<T>(string operation, string entity, Func<Task<T>> dbOperation, object? id = null)
        {
            try
            {
                LogDatabaseOperation(operation, entity, id);
                var startTime = DateTime.UtcNow;

                var result = await dbOperation();

                var duration = DateTime.UtcNow - startTime;
                _logger.LogInformation("Database {Operation} completed on {Entity} in {Duration}ms", 
                    operation, entity, duration.TotalMilliseconds);

                return result;
            }
            catch (Exception ex)
            {
                LogDatabaseError(operation, entity, ex, id);
                throw;
            }
        }
    }
}
