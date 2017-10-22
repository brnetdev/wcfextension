using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        void Add(Person person);

        [OperationContract]
        void Delete(int personId);

        [OperationContract]
        Person Get(int personId);

        [OperationContract]
        List<Person> GetAll();

        [OperationContract]
        void Update(Person person);
    }
}
