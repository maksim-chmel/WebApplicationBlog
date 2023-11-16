namespace newProject.Models
{
    public interface IDataRepository
    {
        Content FindContent(long id);
        Content FindRandomContent();
        void CreateContent(Content newContent);
        void UpdateContent(Content changedContent, Content originalContent = null);
        void DeleteContent(long id);
    }
}
