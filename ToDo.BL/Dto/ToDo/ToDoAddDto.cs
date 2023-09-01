namespace ToDo.BL;

public class ToDoAddDto
{
    public int UserId { get; set; }
    public string Title { get; set; } = null!;
    public string Completed { get; set; } = null!;
}
