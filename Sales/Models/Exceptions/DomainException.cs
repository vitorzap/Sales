using System;
namespace Sales.Models.Exceptions
{
    public class DomainException: ApplicationException
    {
        public DomainException(string message): base(message)
        {
        }
    }
}