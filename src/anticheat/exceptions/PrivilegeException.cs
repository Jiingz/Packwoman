using System.Runtime.Serialization;

namespace packwoman.exceptions
{
    /// <summary>
    /// Exception which is being raised, when the user doesn't have the required priviliges to execute a certain Task.
    /// </summary>
    [Serializable]
    public class PrivilegeException : Exception
    {

        public PrivilegeException(string message) : base(message) { }

        // Ensure Exception is Serializable
        protected PrivilegeException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
