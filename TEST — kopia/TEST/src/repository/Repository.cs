using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Custom_Window_Chrome_Demo.src
{
    /// <summary>
    /// klasa repository - odpowiada za wszelaki kontakt z baza danych i wymiane danych
    /// </summary>
    class Repository
    {
        /// <summary>
        /// Ponizsze skladniki klasy sa odpowiedzialne za polaczenie do bazy danych.
        /// Nalezy podac adres naszej bazy, jej nazwe, uzytkownika oraz haslo.
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// Configuration manager - funkcja pobierajaca dane z appconfiga
        /// "polaczenie" - zmienna podtrzymujaca polaczenie z baza
        /// </summary>
        private static string server = ConfigurationManager.AppSettings["Server"];
        private static string database = ConfigurationManager.AppSettings["Database"];
        private static string uid = ConfigurationManager.AppSettings["User"];
        private static string pwd = ConfigurationManager.AppSettings["Password"];
   
        private static MySqlConnection polaczenie;

        /// <summary>
        /// otwarcie polaczenia z baza danych, za pomoca wartosci zdefiniowanych w appconfigu
        /// </summary>
        private static void Open()
        {
            polaczenie = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + pwd + ";");
            polaczenie.ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                                          "PASSWORD=" + pwd + ";";
            if (polaczenie.State == ConnectionState.Closed) polaczenie.Open();
        }

        /// <summary>
        /// metoda findloginbystudentidandpassword - metoda, ktora znajduje login po hasle i id studenta w bazie
        /// niezbedna do zalogowania sie w aplikacji
        /// sqlQury - tresc zapytania
        /// open(); - otwarcie polaczenia z baza
        /// DataTable dataTable = new DataTable();  (tworzymy nowy obiekt typu dataTAble, do ktorego trafia dane z zapytania)
        /// using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie)) - laczy sie z baza i wyciaga dane o id studenta i jego hasle
        /// a nastepnie podmieniamy parametry przekazane do funkcji z ich odpowiednikami w zapytaniu.
        /// cmd (shell do SQL'a)
        /// wywolanie funkcji fetchObject
        /// fetch - Retrieves an object of the requested type, given a class identifier and an object ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static DataRow findLoginByStudentIdAndPassword(String studentId, String password)
        {
            String sqlQuery = "SELECT id, first_name, last_name, student_id FROM login WHERE student_id = @studentId and password = @password;";

            Open();

            DataTable dataTable = new DataTable(); 

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie))
            {
                cmd.Parameters.AddWithValue("studentId", studentId);
                cmd.Parameters.AddWithValue("password", password);
                dataTable.Load(cmd.ExecuteReader());
            }

            return fetchObject(dataTable);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static DataRowCollection findQuestionByExamId(int examId, int limit)
        {
            String sqlQuery = String.Format("SELECT id, question, points FROM closedquestion WHERE exam_id = @examId order by rand() LIMIT {0};", limit);

            DataTable dataTable = new DataTable();

            Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie))
            {
                cmd.Parameters.AddWithValue("examId", examId);
                dataTable.Load(cmd.ExecuteReader());
            }

            return fetchList(dataTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static DataRowCollection findAnswerByQuestionId(int questionId)
        {
            String sqlQuery = String.Format("SELECT id, answer FROM closedquestionanswer where closed_question_id = @questionId order by rand();");

            DataTable dataTable = new DataTable();

            Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie))
            {
                cmd.Parameters.AddWithValue("questionId", questionId);
                dataTable.Load(cmd.ExecuteReader());
            }
            
            return fetchList(dataTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns></returns>
        public static DataRowCollection findAnswerWithIsCorrectByQuestionId(int questionID)
        {
            String sqlQuery = String.Format("SELECT id, is_correct FROM closedquestionanswer where closed_question_id = @questionId");

            DataTable dataTable = new DataTable();

            Open();
            
            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie))
            {
                cmd.Parameters.AddWithValue("questionId", questionID);
                dataTable.Load(cmd.ExecuteReader());
            }

            return fetchList(dataTable);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static DataRow findExamByIdAndLoginId(String id, int loginId)
        {
            String sqlQuery = "SELECT name, time, closed_quantity FROM exam INNER JOIN examtologin ON " +
                               "examtologin.exam_id = exam.id INNER JOIN login ON login.id = examtologin.login_id WHERE exam.id = @id and login.id = @loginId";
    

            DataTable dataTable = new DataTable();

            Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("loginId", loginId);
                dataTable.Load(cmd.ExecuteReader());
            }

            return fetchObject(dataTable);
        }

        /// <summary>
        /// jezeli zmienna dataTAble jest rozna od nulla i wielkosc tablicy (wierszy) jest wieksza od 0 to zwracamy 1 element tablicy, gdyz oczekujemy 
        /// ze wynikiem jest tylko jeden wiersz 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private static DataRow fetchObject(DataTable dataTable)
        {
            return (dataTable != null && dataTable.Rows.Count > 0) ? dataTable.Rows[0] : null;
        }
        /// <summary>
        /// jezeli zmienna dataTable jest rozna od nulla i wielkosc tablicy (wierszy) jest wieksza od 0 to zwracamy wszystkie elementy tablicy (wierszE)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private static DataRowCollection fetchList(DataTable dataTable)
        {
            return (dataTable != null && dataTable.Rows.Count > 0) ? dataTable.Rows : null;
        }

        /// <summary>
        /// metoda SaveResult, obsluguje ona zapis (insert) danych po zakonczonym egzaminie do bazy danych.
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="loginId"></param>
        /// <param name="score"></param>
        /// <param name="maxScore"></param>
        /// <param name="createdAt"></param>

        public static void SaveResult(int examId, int loginId, int score, int maxScore, DateTime createdAt)
        {
            String sqlQuery = "INSERT INTO result(exam_id, login_id, score, max_score)" +
                " VALUES (@examId, @loginId, @score, @maxScore)";

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, polaczenie))
            {
                cmd.Parameters.AddWithValue("examId", examId);
                cmd.Parameters.AddWithValue("loginId", loginId);
                cmd.Parameters.AddWithValue("score", score);
                cmd.Parameters.AddWithValue("maxScore", maxScore);
                cmd.Parameters.AddWithValue("createdAt", createdAt);

                cmd.ExecuteReader();
            }
        }

    }
}
