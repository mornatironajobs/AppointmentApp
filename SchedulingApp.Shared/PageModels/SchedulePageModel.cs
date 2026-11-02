
namespace SchedulingApp.Shared.PageModels
{
    public class SchedulePageModel 
    {
        // Razor will auto-bind into all sub-properties of AppointmentRequest!
        public ClientListModel ClientListModel { get; set; } = new ClientListModel();

        public CalendarModel CalendarModel { get; set; } = new CalendarModel();
    }
}
