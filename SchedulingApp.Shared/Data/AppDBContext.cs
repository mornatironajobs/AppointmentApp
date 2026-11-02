using Microsoft.EntityFrameworkCore;
using SchedulingApp.Shared.Models;

namespace SchedulingApp.Shared.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<ClientModel> Clients => Set<ClientModel>();


}
