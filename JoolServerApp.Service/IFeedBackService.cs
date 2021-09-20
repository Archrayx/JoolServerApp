using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Service
{
    public interface IFeedBackService
    {
        IEnumerable<tblFeedBack> GetAllFeedBacks();
        tblFeedBack GetFeedBack(long id);
        void insertFeedback(tblFeedBack feedback);
        void UpdateFeedback(tblFeedBack feedback);
        void DeleteFeedback(long id);
    }
}
