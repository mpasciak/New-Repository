using System;
using System.Data;
using Custom_Window_Chrome_Demo.src.entity;

namespace Custom_Window_Chrome_Demo.src.service
{
    class LoginService
    {
        /// <summary>
        /// metoda za pomoca ktorej dokonujemy zalogowania do aplikacji
        /// jezeli login jest rozny od nulla
        /// po wyszukaniu loginu po id studenta i hasle tworzony jest nowy obiekt typu login
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Login Login(String studentId, String password)
        {
            DataRow login = Repository.findLoginByStudentIdAndPassword(studentId, password);

            return login != null ? new Login(Int16.Parse(login["id"].ToString()), login["first_name"].ToString(), login["last_name"].ToString(), login["student_id"].ToString()) : null;
        }

    }
}
