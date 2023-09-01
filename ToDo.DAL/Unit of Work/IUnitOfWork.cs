namespace ToDo.DAL;

public interface IUnitOfWork
{
    public IToDoRepo ToDoRepo { get; }
    int Save();
}
