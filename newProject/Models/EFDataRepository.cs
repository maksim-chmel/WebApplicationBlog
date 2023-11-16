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
        public Content FindRandomContent()
        {
            // Отримати кількість всіх записів
            int count = _dbContext.Contents.Count();

            // Згенерувати випадковий індекс
            Random random = new Random();
            int randomIndex = random.Next(count);

            // Вибрати запис з випадковим індексом
            return _dbContext.Contents.Skip(randomIndex).FirstOrDefault();
        }
        public void CreateContent(Content content)
        {
            content.Id = 0;
            _dbContext.Contents.Add(content);
            _dbContext.SaveChanges(); 
        }
        public void UpdateContent(Content firstcontent,Content secondcontent)
        {
            if (firstcontent != null)
            {
                firstcontent = _dbContext.Contents.Find(firstcontent.Id);  
                
            }
            _dbContext.Contents.Attach(secondcontent);
            firstcontent.Id = secondcontent.Id;
            firstcontent.Info = secondcontent.Info;
            _dbContext.SaveChanges();
        }
        public void DeleteContent(long id) 
        {
            _dbContext.Remove(new Content { Id = id}); 
            _dbContext.SaveChanges();
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


    }
}
