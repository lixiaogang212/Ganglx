using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ClassLibrary1
{
    [ServiceContract]
    public interface IClassLibrary1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<String> GetRemiding();

    }
}
