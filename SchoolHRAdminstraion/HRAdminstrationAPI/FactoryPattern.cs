using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAdminstrationAPI
{
    // where T : class, K,new() specifies that T must be a class, it must
    // implement or extend K and it must have a public constructor with no
    // parameters to be instaniated. We are limiting the type T can be

    public static class FactoryPattern<K,T> where T : class, K,new()
    {
        public static K GetInstance()
        {
            K objK;
            objK = new T();
            return objK;
        }
    }
}
