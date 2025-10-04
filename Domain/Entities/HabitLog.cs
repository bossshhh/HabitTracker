using System;

namespace HabitTracker.Domain.Entities
{
    public class HabitLog
    {
        public int Id { get; } 
        public int HabitId { get; } 
        public DateOnly Date { get; } 
        public string? Notes { get; } 
        public decimal Duration { get; }

        public HabitLog(int id, int habitId, DateOnly date, decimal duration = 1m, string? notes = null)
        {
            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), "Duration must be greater than 0");
            }

            Id = id;
            HabitId = habitId;
            Date = date;
            Duration = duration;
            Notes = notes;
        }

        public static HabitLog CreateNew(int habitId, DateOnly date, decimal duration = 1m, string? notes = null)
            => new HabitLog(0, habitId, date, duration, notes);
    }
}
