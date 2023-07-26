using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdminstrationAPI
{
    //unlike java interfaces in c# can include method signitures, properties, indexers and events

    public interface IEmployee
    {
        //Since this is an interface we don't need access modifiers
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

        decimal Salary { get; set; }
    }
}
