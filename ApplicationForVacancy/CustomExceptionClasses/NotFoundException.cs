using System;

namespace ApplicationForVacancy.CustomExceptionClasses
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message): base(message)
        {
                
        }
    }
}
