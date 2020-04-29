using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcDatabase.Exceptions
{

        [Serializable()]
        public class NoFoundException : Exception
        {
            public NoFoundException() : base() { }
            public NoFoundException(string message) : base(message) { }
            public NoFoundException(string message, System.Exception inner) : base(message, inner) { }
            protected NoFoundException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

}
