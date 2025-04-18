namespace TaskFlow.Application.UseCases.Tasks.DeleteTask;

public interface IDeleteTask
{
    public Task <bool> Execute(int id);
}