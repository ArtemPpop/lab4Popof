using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4Popof
{
    public class Worker : ICloneable, IComparable
    {
        internal static int Count;

        public string? Name { get; set; }
        public int? Position { get; set; }
        public int Id { get; set; }
        public int YearOfEmployment { get; set; }

        public object Clone()
        {
            return new Worker
            {
                Name = Name,
                Position = Position,
                Id = Id,
                YearOfEmployment = YearOfEmployment
            };
        }

        public int CompareTo(object? obj)
        {
            if (obj is Worker worker)
            {
                Worker? monster = obj as Worker;
                return this.Name!.CompareTo(worker!.Name);
            }
            throw new ArgumentException("это не Worker");
        }

        public override string ToString()
        {
            return $"{Name} {Position} {Id} {YearOfEmployment}";
        }
    }
}
