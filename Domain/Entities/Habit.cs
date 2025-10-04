using System;
using System.Collections.Generic;
using System.Linq;

namespace HabitTracker.Domain.Entities
{
    public class Habit
    {
        public int Id { get; }
        public string Name { get; private set; }
        private List<string> _tags;
        public IReadOnlyList<string> Tags => _tags.AsReadOnly();
        public int Goal { get; private set; }

        public Habit(int id, string name, string tags, int goal)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Please enter a name!", nameof(name));
            if (string.IsNullOrWhiteSpace(tags))
                throw new ArgumentException("Please enter at least one tag for the habit", nameof(tags));
            if (goal <= 0)
                throw new ArgumentOutOfRangeException(nameof(goal), "Goal must be greater than 0");

            Id = id;
            Name = name.Trim();
            Goal = goal;

            _tags = tags
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public void Update(string? name = null, string? tags = null, int? goal = null)
        {
            if (name != null)
            {
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.", nameof(name));
                Name = name.Trim();
            }

            if (tags != null)
            {
                _tags = tags
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => t.Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();
            }

            if (goal.HasValue)
            {
                if (goal.Value <= 0) throw new ArgumentOutOfRangeException(nameof(goal), "Goal must be greater than 0");
                Goal = goal.Value;
            }
        }
    }
}

