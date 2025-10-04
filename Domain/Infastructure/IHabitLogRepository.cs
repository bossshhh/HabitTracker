using System.Collections.Generic;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Domain.Infrastructure
{
    public interface IHabitLogRepository
    {
        void Create(HabitLog habitLog);
        HabitLog? GetById(int id);
        IEnumerable<HabitLog> GetAll();
        IEnumerable<HabitLog> GetLogsByHabitId(int habitId);
        void Update(HabitLog habitLog);
        void Delete(int id);
    }
}