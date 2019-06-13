using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    class Login
    {
        private Int16 id;
        private String firstName;
        private String lastName;
        private String studentId;

        public Login(Int16 id, String firstName, String lastName, String studentId)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentId = studentId;
        }

        public Int16 Id
        {
            get { return id; }
        }

        public String FirstName
        {
            get { return firstName; }
        }

        public String LastName
        {
            get { return lastName; }
        }

    }
}
