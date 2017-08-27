using System;
using System.Collections.Generic;
using System.Text;

namespace Menou.Services.Core.Model
{
    public class MenouError
    {
        private string _id;
        private DateTime _createdDate = DateTime.Now;
        private string _server;
        private string _applicationUrl;
        private string _customMessage;
        private string _stackTrace;
        private string _message;
        private string _source;
        private Dictionary<string, string> _data;

        public string Id { get => _id; set => _id = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public string Server
        {
            get => _server;
            set => _server = value;
        }
        public string ApplicationUrl
        {
            get
            {
                if (_applicationUrl == null)
                {
                    _applicationUrl = string.Empty;
                }
                return _applicationUrl;
            }
            set => _applicationUrl = value;
        }
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
            set => _customMessage = value;
        }
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
            set => _stackTrace = value;
        }
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
            set => _message = value;
        }
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
            set => _source = value;
        }
        public Dictionary<string, string> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new Dictionary<string, string>();
                }
                return _data;
            }
            set => _data = value;
        }
    }
}
