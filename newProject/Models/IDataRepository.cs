namespace newProject.Models
{
    public interface IDataRepository
    {
        Content FindContent(long id);
        void RateContentUP(long id);
       
        void RateContentDown(long id);
        long FindSmallestID();
        Content NextContent(long currentId);
        Content PreviousContent(long currentId);
        List<Content> Top();

    }
}
