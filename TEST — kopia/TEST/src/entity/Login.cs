using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    class Login
    {
        /// <summary>
        /// Klasa Login - odpowiada za przechowywanie danych do logowania do naszej aplikacji
        /// w trakcie dzialania programu. Sklada sie z identyfikatora loginu,
        /// imienia, nazwiska, i identyfikatora studenta.
        /// </summary>
        private Int16 id;
        private String firstName;
        private String lastName;
        private String studentId;

        /// <summary>
        /// konstruktor klasy login odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosc przekazana przez parametry wypisane ponizej
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="studentId"></param>
        public Login(Int16 id, String firstName, String lastName, String studentId)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentId = studentId;
        }

        /// <summary>
        /// geter - zwraca id loginu
        /// </summary>
        public Int16 Id
        {
            get { return id; }
        }
        /// <summary>
        /// geter - zwraca imie uzytkownika
        /// </summary>
        public String FirstName
        {
            get { return firstName; }
        }
        /// <summary>
        /// geter - zwraca nazwisko uzytkownika
        /// </summary>
        public String LastName
        {
            get { return lastName; }
        }

    }
}
