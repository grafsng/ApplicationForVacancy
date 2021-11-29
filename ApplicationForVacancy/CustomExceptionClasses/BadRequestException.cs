using System;

namespace ApplicationForVacancy.CustomExceptionClasses
{
    public class BadRequestException: Exception
    {
        public BadRequestException(string message): base(message)
        {
            
        }
    }
}
