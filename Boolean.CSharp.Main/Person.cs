using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Person
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public string Address { get; }

        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

    }
}
