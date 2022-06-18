using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterAPI.Application.Common.Exceptions
{
    public class EntityDeleteNotAllowedException:Exception
    {
        public EntityDeleteNotAllowedException(string message) : base(message) { }
    }
}
