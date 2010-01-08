using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace EPM.Models
{
    public class DbAccessException : BaseException
    {
        public DbAccessException()
            : base()
        {
        }

        public DbAccessException(Exception reason)
            : base(reason)
        {
        }

        public DbAccessException(Exception reason, string message)
            : base(reason, message)
        {
        }
    }
}
