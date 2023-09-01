using ToDo.DAL;

namespace ToDo;

public class ToDo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = null!;
    public Completed Completed { get; set; }
}
