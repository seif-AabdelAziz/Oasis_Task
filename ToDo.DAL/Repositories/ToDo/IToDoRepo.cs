namespace ToDo.DAL;

public interface IToDoRepo
{
    List<ToDo> GetAll();
    ToDo? GetById(int id);
    void Add(ToDo toDo);
    void Delete(ToDo toDo);
}
