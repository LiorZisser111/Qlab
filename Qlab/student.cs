using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlab
{
    public class student
    {
        private int grade;
        private string name;

        public student(string name, int grade)
        {
            this.name = name;
            this.grade = grade;
        }

        public int GetGrade()
        {
            return this.grade;
        }

        public override string ToString()
        {
            return this.name+": "+this.grade;
        }
    }
}
