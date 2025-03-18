namespace Writer.Api.Repositories.Interfaces
{
    public interface IWriterRepository
    {
        List<Models.Writer> getAll();
        Models.Writer? Get(int id);
        Models.Writer Insert(Models.Writer writer);
        Models.Writer Update(Models.Writer writer);
        int Delete(int id);
    }
}
