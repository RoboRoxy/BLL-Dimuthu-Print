using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Exceptions
{
    public class AppErrorException : Exception
    {
        private string _Message;

        public override string Message
        {
            get { return _Message; }
        }

        private string _Caption;

        public string Caption
        {
            get { return _Caption; }
        }

        public AppErrorException(string Caption, string Message)
        {
            _Caption = Caption;
            _Message = Message;
        }
    }
}
