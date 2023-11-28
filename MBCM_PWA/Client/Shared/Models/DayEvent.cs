
namespace MBCM_PWA.Client.Shared.Models
{
    public class DayEvent
    {
        public DateTime StartDate { get; set; } = new DateTime(2000, 1, 1);
        public TimeOnly Time { get; set; }
        public string Note { get; set; }
        public string DateValue { get; set; }
        public string DayName { get; set; }
    }
}
