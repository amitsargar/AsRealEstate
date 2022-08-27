using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AsRealEstate2.Utilities
{
    public static class Common
    {
        //public static DisplayEnumNameByValue(Type<T> myEnum, int value)
        //{
        //    return Enum.GetName(typeof(myEnum), value);
        //}

        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = "amitsargar2153@gmail.com"; //Sender Email Address  
        static string password = "zapkwrroozblwnvw"; //Sender Password  
        static string emailToAddress = "amitsargar2153@gmail.com"; //Receiver Email Address  
        static string subject = "Hello";
        static string body = "Hello, This is Email sending test using gmail.";
        static void Main(string[] args)
        {
            SendEmail();
        }
        public static void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}