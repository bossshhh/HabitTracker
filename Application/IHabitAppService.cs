using System.Collections.Generic;
using System.Data;
using System.Linq;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.Services
{
    public interface IHabitAppService
    {
        void CreateHabit(Habit habit);
        Habit? GetHabitById(int id);
        IEnumerable<Habit> GetAllHabits();
        Habit UpdateHabit(Habit updatedHabit);
        void DeleteHabit(string name);
    }

    public class HabitAppService : IHabitAppService
    {
        private List<Habit> _habits;
        private HashSet<string> _habitsNames;

        public HabitAppService(List<Habit> habits)
        {
            _habits = habits;
            _habitsNames = new HashSet<string>(habits.Select(h => h.Name));
        }

        public void CreateHabit(Habit habit)
        {
            if (!_habitsNames.Add(habit.Name))
            {
                throw new DuplicateNameException("Duplicate name!");
            }
            _habits.Add(habit);
        }

        public Habit? GetHabitById(int id)
        {
            return _habits.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Habit> GetAllHabits()
        {
            return _habits;
        }

        public Habit UpdateHabit(Habit updatedHabit)
        {
            var habit = GetHabitById(updatedHabit.Id);
            if (habit == null)
                throw new KeyNotFoundException("Habit not found");

            habit.Update(updatedHabit.Name, string.Join(",", updatedHabit.Tags), updatedHabit.Goal);
            return habit;
        }

        public void DeleteHabit(string name)
        {
            var habit = _habits.FirstOrDefault(h => h.Name == name);
            if (habit == null)
                throw new KeyNotFoundException("Habit not found");

            _habits.Remove(habit);
            _habitsNames.Remove(name);
        }
    }
}
