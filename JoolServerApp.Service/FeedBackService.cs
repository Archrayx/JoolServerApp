using JoolServerApp.Data;
using JoolServerApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JoolServerApp.Service
{
    public class FeedBackService : IFeedBackService
    {
        private IRepository<tblFeedBack>  feedBackRepository;
      
        public FeedBackService(IRepository<tblFeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }
        public void DeleteFeedback(long id)
        {
            tblFeedBack feedBack = feedBackRepository.Get(id); 
            feedBackRepository.Remove(feedBack);
            feedBackRepository.SaveChanges();
        }

        public IEnumerable<tblFeedBack> GetAllFeedBacks()
        {
            return feedBackRepository.GetAll();
        }

        public tblFeedBack GetFeedBack(long id)
        {
            return feedBackRepository.Get(id);
        }

        public void insertFeedback(tblFeedBack feedback)
        {
            feedBackRepository.Insert(feedback);
        }

        public void UpdateFeedback(tblFeedBack feedback)
        {
            feedBackRepository.Update(feedback);
        }
    }
}