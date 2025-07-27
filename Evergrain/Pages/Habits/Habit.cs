namespace Evergrain.Pages.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HabitNo { get; set; } = 0;
        public string HabitName { get; set; } 
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        



    }
}
