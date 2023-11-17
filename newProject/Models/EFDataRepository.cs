using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;

namespace newProject.Models
{
    public class EFDataRepository:IDataRepository
    {
        private EFDatabaseContext _dbContext;
        public EFDataRepository(EFDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Content FindContent(long id)
        {
            return _dbContext.Contents.Find(id);
        }
      
        public void RateContentUP(long id)
        {
            var content = _dbContext.Contents.Find(id);

            if (content != null)
            {
                content.Rate++;
                _dbContext.SaveChanges();
            }
        }
        public void RateContentDown(long id)
        {
            var content = _dbContext.Contents.Find(id);

            if (content != null)
            {
                content.Rate--;
                _dbContext.SaveChanges();
            }
        }
       public long FindSmallestID()
       {
            var smallerID = _dbContext.Contents.Min(content =>content.Id);
            return smallerID;
       }

        public Content NextContent(long currentId)
        {
            if (currentId != _dbContext.Contents.Max(c => c.Id))
            {

                return _dbContext.Contents.FirstOrDefault(c => c.Id > currentId);
            }
            return null;
        }

        public Content PreviousContent(long currentId)
        {
            if (currentId != _dbContext.Contents.Min(c => c.Id))
            {
                return _dbContext.Contents.OrderBy(c => c.Id).LastOrDefault(c => c.Id < currentId);
            }
            return null;
        }
        public List<Content> Top()
        {
            var topContent = _dbContext.Contents
                .OrderByDescending(c => c.Rate)
                .Take(3)
                .ToList();

            return topContent;
        }



    }
}
