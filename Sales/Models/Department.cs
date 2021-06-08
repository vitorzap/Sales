using System;
namespace Sales.Models
{
    public class Department: BaseEntity
    {
        public string Name { get; set; }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }
    }
}
