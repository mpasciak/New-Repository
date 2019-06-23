using System;
using System.Data;
using Custom_Window_Chrome_Demo.src.entity;

namespace Custom_Window_Chrome_Demo.src.service
{
    /// <summary>
    /// Klasa LoginService - klasa w ktorej zawiera sie metoda do obslugi logowania do aplikacji
    /// </summary>
    class LoginService
    {
        /// <summary>
        /// Metoda za pomoca ktorej dokonujemy zalogowania sie do aplikacji.
        /// Po wyszukaniu loginu po id studenta i hasle tworzony jest nowy obiekt typu login.
        /// Warunkiem poczatkowym jest aby login byl rozny od wartosci null
        /// </summary>
        /// <param name="studentId"> - Parametr studentID, przechowuje wartosc bedaca identykatorem uzytkownika sluzacym do logowania w aplikacji</param>
        /// <param name="password"> - Parametr password, przechowuje wartosc bedaca haslem uzytkownika sluzacym do logowania w aplikacji </param>
        /// <returns></returns>
        public Login Login(String studentId, String password)
        {
            DataRow login = Repository.findLoginByStudentIdAndPassword(studentId, password);

            return login != null ? new Login(Int16.Parse(login["id"].ToString()), login["first_name"].ToString(), login["last_name"].ToString(), login["student_id"].ToString()) : null;
        }

    }
}
