using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.CustomException
{
    public class CacheException: Exception
    {
        public CacheException(string message):base(message) 
        {
            
        }
    }
}
