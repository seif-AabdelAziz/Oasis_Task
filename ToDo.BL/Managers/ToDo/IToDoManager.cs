namespace ToDo.BL;

public interface IToDoManager
{
    List<ToDoReadDto> GetAll();
    ToDoReadDto? GetById(int id);
    int Add(ToDoAddDto toDoAdd);
    int Edit(ToDoReadDto toDoEdit);
    int Delete(int id);
}
