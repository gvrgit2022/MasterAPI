using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterAPI.Application.Common.Exceptions
{
    public class EntityNotFoundException:Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
    }
}
