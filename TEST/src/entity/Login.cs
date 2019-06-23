using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    /// <summary>
    /// Klasa Login - odpowiada za przechowywanie danych do logowania do naszej aplikacji w trakcie dzialania programu. 
    /// </summary>
    public class Login
    {
        private Int16 id;
        private String firstName;
        private String lastName;
        private String studentId;

        /// <summary>
        /// konstruktor klasy login odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosc przekazana przez parametry wypisane ponizej
        /// </summary>
        /// <param name="id"> - Parametr id, przechowuje wartosc bedaca identyfikatorem uzytkownika </param>
        /// <param name="firstName"> - Parametr firstName, przechowuje wartosc bedaca imieniem uzytkownika </param>
        /// <param name="lastName"> - Parametr firstName, przechowuje wartosc bedaca nazwiskiem uzytkownika </param>
        /// <param name="studentId"> - Parametr studentID, przechowuje wartosc bedaca identykatorem uzytkownika sluzacym do logowania w aplikacji </param>
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
