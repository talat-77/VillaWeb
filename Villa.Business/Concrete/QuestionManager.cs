using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Business.Abstract;
using Villa.DataAccess.Abstract;
using Villa.Entity.Entities;

namespace Villa.Business.Concrete
{
    public class QuestionManager : GenericManager<Question>, IQuestionService
    {
        public QuestionManager(IGenericDal<Question> genericdal) : base(genericdal)
        {
        }
    }
}
