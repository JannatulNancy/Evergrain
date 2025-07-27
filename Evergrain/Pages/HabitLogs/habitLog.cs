using Evergrain.Pages.Models;

namespace Evergrain.Pages.HabitLogs
{
    public class habitLog
    {
        public Guid Id { get; set; }
        
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public Habit Habit { get; set; }


    }
}
