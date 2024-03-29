﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity

{
    /// <summary>
    /// Klasa Exam - odpowiada za przechowywanie danych egzaminu w trakcie dzialania programu
    /// </summary>
    public class Exam
    {
        private Int16 id;
        private String name;
        private Int16 time;
        private Int16 closedQuantity;
        private List<ClosedQuestion> closedQuestionList;

        /// <summary>
        /// Konstruktor klasy closedquestionanswer odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosc przekazana przez parametry wypisane ponizej
        /// Tworzy nowa liste odpwoedzialna za liste pytan do naszego egzaminu
        /// </summary>
        /// <param name="id" > - Parametr id, przechowuje wartosc bedaca identyfikatorem egzaminu/testu </param>
        /// <param name="name"> - Parametr name, przechowuje wartosc bedaca nazwa egzaminu</param>
        /// <param name="time"> - Parametr time, przechowuje wartosc bedaca iloscia czasu do zakonczia egzaminu</param>
        /// <param name="closedQuantity"> - Parametr closedQuantity, przechowuje wartosc bedaca iloscia pytan ktore wystapia na egzaminie </param>


        public Exam(Int16 id, String name, Int16 time, Int16 closedQuantity)
        {
            
            this.id = id;
            this.name = name;
            this.time = time;
            this.closedQuantity = closedQuantity;
            this.closedQuestionList = new List<ClosedQuestion>();
        }
        /// <summary>
        /// geter - zwraca id egzaminu
        /// </summary>
        public Int16 Id
        {
            get { return id; }
        }
        /// <summary>
        /// geter - zwraca nazwe egzaminu
        /// </summary>
        public String Name
        {
            get { return name; }
        }
        /// <summary>
        /// geter zwraca licznik czasu
        /// </summary>
        public Int16 Time
        {
            get { return time; }
        }
        /// <summary>
        ///  geter - zwraca ilosc pytan
        /// </summary>
        public Int16 ClosedQuestion
        {
            get { return closedQuantity; }
        }
        /// <summary>
        /// geter/seter - pobiera pytania i w utworzona liste pytan
        /// wstawia jakas wartosc czyli nasze pytania
        /// </summary>
        public List<ClosedQuestion> ClosedQuestionList
        {
            get { return closedQuestionList;}
            set { closedQuestionList = value; }
        }

    }
}
