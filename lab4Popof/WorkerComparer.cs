using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab4Popof
{
    internal class WorkerComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is Worker && y is Worker)
            {
                var worker1 = x as Worker;
                var worker2 = y as Worker;
                if (worker1?.YearOfEmployment > worker2?.YearOfEmployment) return 1;
                else if (worker1?.YearOfEmployment < worker2?.YearOfEmployment) return -1;
                return 0;
            }
            throw new Exception("Невозможно сравнить");
        }
    }
}
