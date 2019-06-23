using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.service
{
    /// <summary>
    /// Klasa InternetConnection - klasa w ktorej zawieraja sie metoda do obslugi polaczenia z internetem
    /// </summary>
    class InternetConnection
    {
       /// <summary>
       /// Rozlaczenie polaczenia z Internetem
       /// </summary>
        public static void Disconnect()
        {
            /*try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "ipconfig /release");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
            catch (Exception objException)
            {
            }
            */
        }
        /// <summary>
        /// Nawiazanie polaczenia z Internetem
        /// </summary>
        public static void Connect()
        {
            /*try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "ipconfig /renew");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
            catch (Exception objException)
            {
            }
            */
        }

    }
}