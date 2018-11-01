using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface IMark
    {
        [OperationContract]
        void AddMark(int mark, Student student, Subject sub);

        [OperationContract]
        List<Mark> GetMark();


        [OperationContract]
        List<Mark> GetMarkByStudent(Student st, Subject sub);
    }
}
