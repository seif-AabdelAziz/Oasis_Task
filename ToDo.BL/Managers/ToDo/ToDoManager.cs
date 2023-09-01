using ToDo.DAL;

namespace ToDo.BL;

public class ToDoManager : IToDoManager
{
    private readonly IUnitOfWork unitOfWork;

    public ToDoManager(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }



    public List<ToDoReadDto> GetAll()
    {
        List<ToDo> toDosDB = unitOfWork.ToDoRepo.GetAll();

        List<ToDoReadDto> toDos = toDosDB.Select(t => new ToDoReadDto
        {
            Id = t.Id,
            UserId = t.UserId,
            Title = t.Title,
            Completed = t.Completed.ToString(),
        }).ToList();

        return toDos;
    }

    public ToDoReadDto? GetById(int id)
    {
        ToDo? toDoDB = unitOfWork.ToDoRepo.GetById(id);
        if (toDoDB is null)
        {
            return null;
        }

        return new ToDoReadDto
        {
            Id = toDoDB.Id,
            UserId = toDoDB.UserId,
            Title = toDoDB.Title,
            Completed = toDoDB.Completed.ToString(),
        };
    }

    public int Add(ToDoAddDto toDoAdd)
    {
        ToDo newToDo = new ToDo
        {
            UserId = toDoAdd.UserId,
            Title = toDoAdd.Title,
            Completed = (Completed)Enum.Parse(typeof(Completed), toDoAdd.Completed),
        };

        unitOfWork.ToDoRepo.Add(newToDo);
        return unitOfWork.Save();

    }

    public int Edit(ToDoReadDto toDoEdit)
    {
        ToDo? toDoDB = unitOfWork.ToDoRepo.GetById(toDoEdit.Id);
        if (toDoDB is null)
        {
            return 0;
        }

        toDoDB.UserId = toDoEdit.UserId;
        toDoDB.Title = toDoEdit.Title;
        toDoDB.Completed = (Completed)Enum.Parse(typeof(Completed), toDoEdit.Completed);

        return unitOfWork.Save();
    }
    public int Delete(int id)
    {
        ToDo? toDo = unitOfWork.ToDoRepo.GetById(id);
        if (toDo is null)
        {
            return 0;
        }

        unitOfWork.ToDoRepo.Delete(toDo);
        return unitOfWork.Save();
    }

}
