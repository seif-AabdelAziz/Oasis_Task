using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ToDo.DAL;

public class ToDoContext : IdentityDbContext
{

    public ToDoContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<ToDo> ToDos => Set<ToDo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        string json = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\Repo\\Oasis Task\\ToDo\\ToDo.DAL\\Data\\ToDos.json");
        var data = JsonConvert.DeserializeObject<List<ToDo>>(json);
        modelBuilder.Entity<ToDo>().HasData(data);
    }


}
