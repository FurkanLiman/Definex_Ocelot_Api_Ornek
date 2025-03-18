namespace Article.Api.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        List<Models.Article> GetAll();

        Models.Article? GetById(int id);

        int Delete(int id);

        Models.Article Add(Models.Article article);

        Models.Article Update(Models.Article article);
    }
}
