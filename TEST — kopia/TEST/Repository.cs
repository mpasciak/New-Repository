using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Custom_Window_Chrome_Demo.src
{
    class Repository
    {
        private static string server = ConfigurationManager.AppSettings["Server"];
        private static string database = ConfigurationManager.AppSettings["Database"];
        private static string uid = ConfigurationManager.AppSettings["User"];
        private static string pwd = ConfigurationManager.AppSettings["Password"];

        private static MySqlConnection polaczenie;

        private static void Open()
        {
            polaczenie = new MySqlConnection("SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + pwd + ";");
            polaczenie.ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                                          "PASSWORD=" + pwd + ";";
            if (polaczenie.State == ConnectionState.Closed) polaczenie.Open();
        }


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

        private static DataRow fetchObject(DataTable dataTable)
        {
            return (dataTable != null && dataTable.Rows.Count > 0) ? dataTable.Rows[0] : null;
        }

        private static DataRowCollection fetchList(DataTable dataTable)
        {
            return (dataTable != null && dataTable.Rows.Count > 0) ? dataTable.Rows : null;
        }

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
