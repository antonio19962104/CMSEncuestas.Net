using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SenderEmail
    {
        public bool EnviarCorreo(ML.SenderEmail senderEmail)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(senderEmail.To));
                message.Subject = senderEmail.Subject;
                message.Body = senderEmail.Message;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.Priority = senderEmail.MailPriority;
                using (var smtp = new SmtpClient())
                {
                    try
                    {
                        smtp.Send(message);
                        AddEstatusEmail(senderEmail);
                    }
                    catch (SmtpException SmtpEx)
                    {
                        AddEstatusEmail(senderEmail, SmtpEx);
                        BL.Nlog.logErrorModuloSenderEmail(SmtpEx, new StackTrace());
                        return false;
                    }
                    finally
                    {
                        smtp.Dispose();
                    }
                }
            }
            catch (Exception aE)
            {
                AddEstatusEmail(senderEmail, aE);
                BL.Nlog.logErrorModuloSenderEmail(aE, new StackTrace());
                return false;
            }
            return true;
        }
        public static void AddEstatusEmail(ML.SenderEmail senderEmail)
        {
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    // EstatusEmail success
                    
                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSenderEmail(aE, new StackTrace());
            }
        }
        public static void AddEstatusEmail(ML.SenderEmail senderEmail, SmtpException smtpException)
        {
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    // EstatusEmail error

                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSenderEmail(aE, new StackTrace());
            }
        }
        public static void AddEstatusEmail(ML.SenderEmail senderEmail, Exception exception)
        {
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    // EstatusEmail error

                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSenderEmail(aE, new StackTrace());
            }
        }
    }
}
