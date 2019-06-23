using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Configuration;
using Custom_Window_Chrome_Demo.src;
using Custom_Window_Chrome_Demo.src.entity;
using Custom_Window_Chrome_Demo.src.service;

namespace Custom_Window_Chrome_Demo
{

    public partial class MainWindow : ThemedWindow
    {
        DispatcherTimer timer = new DispatcherTimer();
        Thread t = null;
        private static int examTime;

        private Exam exam;
        private Login login;
        private ClosedQuestion currentClosedQuestion;
        private int currentClosedQuestionNumber = 1;

        public MainWindow()
        {
            InitializeComponent();
            studentId.Focus();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            string src = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string sourceFile = System.IO.Path.Combine(src, "Custom Window Chrome Demo.exe.config");
            System.IO.File.Delete(sourceFile);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            examTime--;
            if (examTime % 15 == 0)
            {
                InternetConnection.Disconnect();
            }
            TimerMethod();
        } 

        private void TimerMethod()
        {
            int hours, minutes, seconds;
            String hoursText, minutesText, secundsText;

            hours = examTime / 3600;
            hoursText = hours.ToString();
            if (hours < 10) hoursText = "0" + hoursText;

            minutes = (examTime - hours * 3600) / 60;
            minutesText = minutes.ToString();
            if (minutes < 10) minutesText = "0" + minutesText;

            seconds = examTime - hours * 3600 - minutes * 60;
            secundsText = seconds.ToString();
            if (seconds < 10) secundsText = "0" + secundsText;

            if (examTime > 0)
            {
                timer_label.Text = hoursText + ":" + minutesText + ":" + secundsText;
                if (examTime <= 60)
                {
                    timer_label.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
            else
            {
                FinishExam();
            }
        }
        
        private void _Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox checkBox = (System.Windows.Controls.CheckBox)sender;
            checkBox.Foreground = new SolidColorBrush(Colors.White);
            SetCheckedAnswer(checkBox);
        }

        private void _Unchecked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox checkBox = (System.Windows.Controls.CheckBox)sender;
            checkBox.Foreground = new SolidColorBrush(Colors.Black);
            SetCheckedAnswer(checkBox);
        }

        private void LoginClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if ((studentId.Text != "") && (password_box.Password != "") && (examId.Text != ""))
            {
                LoginService loginService = new LoginService();

                login = loginService.Login(studentId.Text, password_box.Password);

                if (login != null) {
                    DownloadExamService downloadExamService = new DownloadExamService();

                    exam = downloadExamService.Download(examId.Text, login.Id);

                    if (exam != null)
                    {
                        examTime = exam.Time;

                        start_text.Visibility = System.Windows.Visibility.Visible;
                        name_exam.Text = exam.Name;
                        nr_question.Text = currentClosedQuestionNumber + "/" + exam.ClosedQuestion;
                        fl_name.Text = login.FirstName + " " + login.LastName;
                        TimerMethod();
                        login_grid.Visibility = System.Windows.Visibility.Hidden;
                        login_box.Visibility = System.Windows.Visibility.Collapsed;

                    }
                    else
                    {
                        login_box.Visibility = System.Windows.Visibility.Collapsed;
                        error_exam_id.Visibility = System.Windows.Visibility.Visible;
                    }
   
                }
                else
                {
                    login_box.Visibility = System.Windows.Visibility.Collapsed;
                    error_login.Visibility = System.Windows.Visibility.Visible;
                }

            }
            else
            {
                login_box.Visibility = System.Windows.Visibility.Collapsed;
                error_login.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void BackLoginClick(object sender, RoutedEventArgs e)
        {
            error_login.Visibility = System.Windows.Visibility.Collapsed;
            studentId.Text = "";
            password_box.Password = "";
            examId.Text = "";
            login_box.Visibility = System.Windows.Visibility.Visible;
        }

        private void BackExamClick(object sender, RoutedEventArgs e)
        {
            error_exam_id.Visibility = System.Windows.Visibility.Collapsed;
            studentId.Text = "";
            password_box.Password = "";
            examId.Text = "";
            login_box.Visibility = System.Windows.Visibility.Visible;
        }

        private void NoFinishExamClick(object sender, RoutedEventArgs e)
        {
            exit_grid.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void StartClick(object sender, RoutedEventArgs e)
        {
            start.IsEnabled = false;
            next.IsEnabled = true;
            exit.IsEnabled = true;
            start_text.Visibility = System.Windows.Visibility.Collapsed;
            timer.Start();
            currentClosedQuestion = NextQuestion.NextClosedQuestion(exam.ClosedQuestionList, currentClosedQuestion);
            PrepareClosedQuestion();
            nr_question.Text = currentClosedQuestionNumber + "/" + exam.ClosedQuestion;
            SetCheckedAnswer();
        }

        private void PreviousClick(object sender, RoutedEventArgs e)
        {
            currentClosedQuestionNumber--;
            if (currentClosedQuestionNumber == 1) previous.IsEnabled = false;
            next.IsEnabled = true;
            currentClosedQuestion = PreviousQuestion.PreviousClosedQuestion(exam.ClosedQuestionList, currentClosedQuestion);
            PrepareClosedQuestion();
            nr_question.Text = currentClosedQuestionNumber + "/" + exam.ClosedQuestion;
            SetCheckedAnswer();
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            currentClosedQuestionNumber++;
            if (currentClosedQuestionNumber == exam.ClosedQuestion) next.IsEnabled = false;
            previous.IsEnabled = true;
            currentClosedQuestion = NextQuestion.NextClosedQuestion(exam.ClosedQuestionList, currentClosedQuestion);
            PrepareClosedQuestion();
            nr_question.Text = currentClosedQuestionNumber + "/" + exam.ClosedQuestion;
            SetCheckedAnswer();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            exit_grid.Visibility = System.Windows.Visibility.Visible;
        }

        private void SetCheckedAnswer()
        {
            a.IsChecked = currentClosedQuestion.ClosedQuestionAnswerList[0].IsChecked;
            b.IsChecked = currentClosedQuestion.ClosedQuestionAnswerList[1].IsChecked;
            c.IsChecked = currentClosedQuestion.ClosedQuestionAnswerList[2].IsChecked;
            d.IsChecked = currentClosedQuestion.ClosedQuestionAnswerList[3].IsChecked;
        }

        private void SetCheckedAnswer(System.Windows.Controls.CheckBox checkBox)
        {
            switch (checkBox.Name)
            {
                case "a": currentClosedQuestion.ClosedQuestionAnswerList[0].IsChecked = checkBox.IsChecked ?? false; break;
                case "b": currentClosedQuestion.ClosedQuestionAnswerList[1].IsChecked = checkBox.IsChecked ?? false; break;
                case "c": currentClosedQuestion.ClosedQuestionAnswerList[2].IsChecked = checkBox.IsChecked ?? false; break;
                case "d": currentClosedQuestion.ClosedQuestionAnswerList[3].IsChecked = checkBox.IsChecked ?? false; break;
            }
        }
        
        private void PrepareClosedQuestion()
        {
            question.Text = currentClosedQuestion.Question;
            img.Visibility = System.Windows.Visibility.Collapsed;

            a.Visibility = System.Windows.Visibility.Visible;
            a.Height = 100;
            imgA.Visibility = System.Windows.Visibility.Collapsed;
            odpA.Visibility = System.Windows.Visibility.Visible;
            odpA.Height = 100;
            odpA.Text = currentClosedQuestion.ClosedQuestionAnswerList[0].Answer;

            b.Visibility = System.Windows.Visibility.Visible;
            b.Height = 100;
            imgB.Visibility = System.Windows.Visibility.Collapsed;
            odpB.Visibility = System.Windows.Visibility.Visible;
            odpB.Height = 100;
            odpB.Text = currentClosedQuestion.ClosedQuestionAnswerList[1].Answer;

            c.Visibility = System.Windows.Visibility.Visible;
            c.Height = 100;
            imgC.Visibility = System.Windows.Visibility.Collapsed;
            odpC.Visibility = System.Windows.Visibility.Visible;
            odpC.Height = 100;
            odpC.Text = currentClosedQuestion.ClosedQuestionAnswerList[2].Answer;

            d.Visibility = System.Windows.Visibility.Visible;
            d.Height = 100;
            imgD.Visibility = System.Windows.Visibility.Collapsed;
            odpD.Visibility = System.Windows.Visibility.Visible;
            odpD.Height = 100;
            odpD.Text = currentClosedQuestion.ClosedQuestionAnswerList[3].Answer;
        }
        
        private void FinishExamClick(object sender, RoutedEventArgs e) {
            FinishExam();
        }

        private void FinishExam()
        {
        //    InternetConnection.Connect();
            timer.Stop();
            timer_label.Text = "KONIEC";
            exit_grid.Visibility = System.Windows.Visibility.Visible;
            exit_grid2.Visibility = System.Windows.Visibility.Collapsed;
            Result result = CheckExam.Check(exam, login);
            resultP.Visibility = System.Windows.Visibility.Visible;
            resultP.Content = "Wynik: " + result.Score + "/" + result.MaxScore;
        }
    }
    
}