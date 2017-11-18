using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchSeo.Core.Model
{
    public class Error
    {
        private string _message;

        /// <summary>
        /// The error message retrieved from the exception.
        /// </summary>
        public string Message
        {
            get
            {
                if (_message == null)
                {
                    _message = string.Empty;
                }
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        private string _stackTrace;

        /// <summary>
        /// The stack trace retrieved from the exception.
        /// </summary>
        public string StackTrace
        {
            get
            {
                if (_stackTrace == null)
                {
                    _stackTrace = string.Empty;
                }
                return _stackTrace;
            }
            set
            {
                _stackTrace = value;
            }
        }

        private string _customMessage;

        /// <summary>
        /// The custom message provided by the code.
        /// </summary>
        public string CustomMessage
        {
            get
            {
                if (_customMessage == null)
                {
                    _customMessage = string.Empty;
                }
                return _customMessage;
            }
            set
            {
                _customMessage = value;
            }
        }

        private string _source;

        /// <summary>
        /// The source provided by the exception.
        /// </summary>
        public string Source
        {
            get
            {
                if (_source == null)
                {
                    _source = string.Empty;
                }
                return _source;
            }
            set
            {
                _source = value;
            }
        }

    }
}
