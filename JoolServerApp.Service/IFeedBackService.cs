using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Data;

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
