﻿namespace UserProject.API.Exceptions
{
    public class InternalErrorException : Exception
    {
        public InternalErrorException(string error) : base(error) { }

    }
}
