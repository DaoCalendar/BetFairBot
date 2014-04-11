using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mail;
using System.Net.Mail;
using System.Net;
namespace BFBot
    {
    public class BfBot
        {
        public static bool Active = false; 
        public static Account s_account;
        public static bool Quiting = false;
        private static BfbMessage s_bfbMessage = new BfbMessage();

        //public static BFForcaster.MovementPatterns movementPatterns = new BFForcaster.MovementPatterns();
        //private static DateTime dt = DateTime.Now;
        //private static System.IO.StreamWriter m_writer = System.IO.File.AppendText(@"C:\Temp\BFBotDumpTestDebug.txt");
        

        
        private static readonly System.IO.StreamWriter s_Writer = System.IO.File.AppendText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " - " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + " BFBotDumpTestDebug.txt");
        private static readonly System.IO.StreamWriter s_WriterDetails = System.IO.File.AppendText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " - " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + " BFBRunnerDetails.txt");

        public enum MarketItemState
            {
            Analysing = 1,
            Backed = 2,
            Equalised = 3,
            Closed = 4
            }

        public enum MarketState
            {
            Unknown = 0,
            Backed = 1,
            Equalised = 2,
            Analysing = 3,
            Closed = 4
            }

        public static double Transfered { get; set; }

        public static double Balance { get; set; }

        public static bool EmailNotification { get; set; }

        public static double MaxStake { get; set; }

        public static int SecondsToClose { get; set; }

        public static double TransferLimit { get; set; }

        public static void SendMailMessage(string action, string message)
            {
                //try
                //{
                //    SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
                //    mailClient.EnableSsl = true;
                //    NetworkCredential cred = new NetworkCredential("bftbot1@gmail.com", "zagato1!");
                //    mailClient.Credentials = cred;
                //    mailClient.Send("bftbot1@gmail.com", "steveleejones@googlemail.com", action, message);
                //}
                //catch (Exception ex)
                //{
                //    BFBot.DumpToFile("**** Error in BFBot->SendMailMessage ****");
                //    BFBot.DumpToFile(ex.Message + "InnerException=[" + ex.InnerException.Message + "]");
                //}
            }

        public static void DumpToFile(string value)
            {
            s_Writer.WriteLine(value);
            s_Writer.Flush();
            //if (value.Contains("Error"))
            //{
            //    SendMailMessage("Error", value);
            //}
            }
        public static void DumpDetails(string value)
        {
            s_WriterDetails.Write(value);
            s_WriterDetails.Flush();
        }

        public static void AddMessage(string line)
            {
            s_bfbMessage.AddLine(line);
            }

        public static void SendBfbMessage()
            {
            if (s_bfbMessage.Message == "")
                return;
            DumpToFile(s_bfbMessage.Message);
            //SendMailMessage(DateTime.Now.ToString(), m_bfbMessage);
            s_bfbMessage.Clear();
            }

        //public static BF_Trader_Dumy_Server.DummyDay GetDay()
        //    {
        //    BF_Trader_Dumy_Server.DummyDay dummyDay = new BF_Trader_Dumy_Server.DummyDay(DateTime.Now);
        //    return dummyDay;
        //    }

        public static Account GetAccount
            {
            get { return s_account ?? (s_account = new Account()); }
            }
        }
    }
