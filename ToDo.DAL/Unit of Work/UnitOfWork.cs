namespace ToDo.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ToDoContext context;
    public IToDoRepo ToDoRepo { get; }

    public UnitOfWork(ToDoContext _context, IToDoRepo _toDoRepo)
    {
        context = _context;
        ToDoRepo = _toDoRepo;
    }

    public int Save()
    {
        return context.SaveChanges();
    }
}
