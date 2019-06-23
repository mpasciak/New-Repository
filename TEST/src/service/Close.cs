using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Custom_Window_Chrome_Demo.src.service;

namespace Custom_Window_Chrome_Demo
{
    
    /// <summary>
    /// Klasa czesciowa sluzaca do obslugi przycisku "zamknij"
    /// </summary>
    public partial class Close
    {
        public void CloseButton(object sender, RoutedEventArgs routedEventArgs)
        {
            InternetConnection.Connect();
        }
    }
    
}
