using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web.Mail;
using System.Net.Mail;

namespace BF_Trader_Dumy_Server
    {
    public class Helper
        {
        public enum MarketMovement
            {
            Shortening = 0,
            Lengthening = 1
            }

        public static Random rand = new Random();

        public static decimal Movement()
            {
            decimal v = rand.Next(0, 15);
            if (v == 1.0m)
                return -0.1m;
            if (v == 2.0m)
                return 0.1m;
            if (v == 3.0m)
                return 0.05m;
            if (v == 4.0m)
                return -0.1m;
            if (v == 5.0m)
                return -0.1m;
            if (v == 6.0m)
                return -0.05m;
            if (v == 7.0m)
                return 0.05m;
            if (v == 8.0m)
                return -0.1m;
            if (v == 9.0m)
                return -0.1m;
            if (v == 10.0m)
                return -0.1m;
            //if (v > 0 && v < 5)
            //    return 0.01;
            //if (v > 0 && v >= 5)
            //    return 0.05;
            //if (v < 0 && v > -5)
            //    return -0.01;
            //if (v < 0 && v <= -5)
            //    return -0.05;
            return 0.0m;
            }

        public static decimal Average(List<decimal> list)
            {
            int total = list.Count;
            decimal temp = 0;

            for (int i = 0; i != total; i++)
                {
                temp += list[i];
                }
            return temp / total;
            }

        public static int UpMovement(List<decimal> list)
            {
            int total = list.Count - 1;
            int counter = 0;
            for (int i = 0; i != total; i++)
                {
                if(list[i+1] > list[i])
                    counter++;
                }
            return counter;
            }

        public static int DownMovement(List<decimal> list)
            {
            int total = list.Count - 1;
            int counter = 0;
            for (int i = 0; i != total; i++)
                {
                if(list[i+1] < list[i])
                    counter++;
                }
            return counter;
            }

        //public static void DrawGraph(List<double> list, System.Windows.Forms.PictureBox picBox)
        //    {
        //    float x1, y1;
        //    int pw = picBox.Width;
        //    int ph = picBox.Height;
        //    int w = picBox.Width / 2;
        //    int h = picBox.Height / 2;
        //    Graphics objGraphics = picBox.CreateGraphics();
        //    Pen pen = new Pen(Color.Black);
        //    x1 = y1 = 0.0F;

        //    for (int i = 0; i < list.Count; i++)
        //        {
        //        float y = h;
        //        float x = (float)list[i];
        //        if (x1 != 0.0 && y1 != 0.0)
        //            {
        //            objGraphics.DrawLine(pen, x, y, x1, y1);
        //            System.Drawing.Drawing2D.GraphicsState graph = objGraphics.Save();
        //            objGraphics.Restore(graph);
        //            }
        //        x1 = x;
        //        y1 = y;
        //        }

        //    objGraphics.DrawLine(pen, 0, h, pw, h);
        //    objGraphics.DrawLine(pen, w, 0, w, ph);
        //    }

        public static void SendMail()
            {
            
            //SmtpMail.SmtpServer = "smtp.ntlworld.com";
            //SmtpMail.Send("stevenleejones@ntlworld.com","steve.jones@bentley.com","Test", "Test");
            
            ////System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.ntlworld.com", 110);
            ////smtp.UseDefaultCredentials = false;
            ////smtp.Credentials = new System.Net.NetworkCredential("stevenleejones@ntlworld.com", "db4gtzagat");

            

            ////smtp.Send(message);
            
            //MailMessage MailObj = new MailMessage();
            //MailObj.To.Add("steve.jones@bentley.com");
            ////MailObj.From = "GmailAccount@gmail.com";
            //MailObj.From = new MailAddress("stevenleejones@ntlworld.com", "From");
            ////MailObj.Cc = "cc@cc.com";

            //MailObj.IsBodyHtml = true;

            //MailObj.Priority = MailPriority.Normal;
            ////string sAttach = @"c:\yourpic.jpg";
            ////MailObj.Attachments.Add(new Attachment(sAttach));
            //MailObj.Subject = "Subject";
            //MailObj.Body = "<table><tr><td>Test</td></tr></table>";

            //SmtpClient smtpClient = new SmtpClient("pop.ntlworld.com", 110);
            
            //smtpClient.EnableSsl = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new System.Net.NetworkCredential("stevenleejones@ntlworld.com", "db4gtzagat");
            //try
            //    {
            //    smtpClient.Send(MailObj);
            //    }
            //catch (Exception ex)
            //    {
            //    }
            
           

            }
        }
    }
