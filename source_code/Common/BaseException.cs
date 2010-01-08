using System;
using System.Text;

namespace Common
{
    /// <summary>
    /// Base eexception.
    /// @author: ManVHT
    /// @date: 2010-01-06
    /// </summary>
    public class BaseException : Exception
    {
        protected Exception _reason;
        protected string _message;

        public BaseException()
        {            
        }

        public BaseException(Exception reason)
        {
            _reason = reason;
        }

        public BaseException(Exception reason, string message)
        {
            _reason = reason;
            _message = message;
        }

        public override string Message
        {
            get
            {
                if (!String.IsNullOrEmpty(_message))
                    return _message;
                return base.Message;
            }
        }
    }
}
