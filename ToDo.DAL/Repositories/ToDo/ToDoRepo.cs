using Microsoft.EntityFrameworkCore;

namespace ToDo.DAL;

public class ToDoRepo : IToDoRepo
{
    private readonly ToDoContext context;

    public ToDoRepo(ToDoContext _context)
    {
        context = _context;
    }


    public List<ToDo> GetAll()
    {
        return context.Set<ToDo>().AsNoTracking().ToList();
    }

    public ToDo? GetById(int id)
    {
        return context.Set<ToDo>().Find(id);
    }
    public void Add(ToDo toDo)
    {
        context.Set<ToDo>().Add(toDo);
    }

    public void Delete(ToDo toDo)
    {
        context.Set<ToDo>().Remove(toDo);
    }
}
