namespace newProject.Models
{
    public interface IDataRepository
    {
        Content FindContent(long id);
        Content FindRandomContent();
        void CreateContent(Content newContent);
        void UpdateContent(Content changedContent, Content originalContent = null);
        void RateContentUP(long id);
        void DeleteContent(long id);
        void RateContentDown(long id);
    }
}
