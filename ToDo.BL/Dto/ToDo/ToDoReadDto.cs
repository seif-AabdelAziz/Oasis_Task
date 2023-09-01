namespace ToDo.BL;

public class ToDoReadDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = null!;
    public string Completed { get; set; } = null!;
}
