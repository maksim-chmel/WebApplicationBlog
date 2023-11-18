namespace newProject.Models
{
    public class FeedbackRepository:IFeedbackRepository
    {
        private EFDatabaseContext _dbContext;
        public FeedbackRepository(EFDatabaseContext eFDatabaseContext) 
        {
            _dbContext = eFDatabaseContext; 
        }

      public void AddFeedback(Feedback feedback)
      {
         _dbContext.Feedbacks.Add(feedback);
         _dbContext.SaveChanges();
      }

    }
}
