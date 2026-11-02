using SchedulingApp.Shared.Data;

namespace SchedulingApp.Shared.Models;

public class Appointment
{
    public int Id { get; set; }
    public ServiceType ServiceType { get; set; } // Assuming you have an enum for service types
    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public bool IsNoShow { get; set; } = false;

    public string Notes { get; set; } = string.Empty;

    public int? ClientId { get; set; }

    public ClientModel? Client { get; set; }

}