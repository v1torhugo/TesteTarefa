using System;

namespace apiToDo.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) : base(message)
        {

        }
    }
}
