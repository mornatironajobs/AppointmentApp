using Microsoft.EntityFrameworkCore;
using SchedulingApp.Shared.Data;
using SchedulingApp.Shared.Models;

namespace SchedulingApp.Shared.PageModels
{
    public record ListItem(string Value, string Text);

    public class ClientListModel
    {
        // This stores the IDs/values that the user selects
        public string[] SelectedItemIds { get; set; } = [];

        // This holds the list of data to display in the list box
        public List<ClientModel> InformationList { get; private set; } = [];

        public async Task LoadAsync(IDbContextFactory<AppDbContext> dbFactory)
        {
            await using var db = await dbFactory.CreateDbContextAsync();
            InformationList = await db.Clients.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }

        public void Submit()
        {
            if (SelectedItemIds.Any())
            {
                // Process your selected data here
            }
        }
    }
}



