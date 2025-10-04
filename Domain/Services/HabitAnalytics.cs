using HabitTracker.Domain.Entities;
using HabitTracker.Domain.Services;
using HabitTracker.Domain.Infrastructure;
using HabitTracker.Application.Services;

namespace HabitTracker.Domain.Services
{
    public class HabitAnalytics
    {
        private readonly IEnumerable<HabitLog> _logs;

        public HabitAnalytics(IEnumerable<HabitLog> logs)
        {
            _logs = logs ?? throw new ArgumentNullException(nameof(logs));
        }

        public int GetTotalCompletions(int habitId)
        {
            return _logs.Count(log => log.HabitId == habitId);
        }

        public decimal GetAverageCompletionTime(int habitId)
        {
            var durations = _logs
                .Where(log => log.HabitId == habitId)
                .Select(log => log.Duration);

            return durations.Any() ? durations.Average() : 0m;
        }

        public DateOnly? GetRecentCompletion(int habitId)
        {
            var date = _logs
                .Where(log => log.HabitId == habitId)
                .OrderByDescending(log => log.Date)
                .Select(log => log.Date)
                .FirstOrDefault();

            return date == default ? (DateOnly?)null : date;
        }
    }
}
