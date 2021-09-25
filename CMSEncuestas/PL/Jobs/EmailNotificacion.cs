using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Jobs
{
    public class EmailNotificacion
    {
        public static void NotificacionPlanAccion()
        {
            ML.SenderEmail modelSender = new ML.SenderEmail()
            {
                From = "",
                MailPriority = System.Net.Mail.MailPriority.High,
                Subject = ""
            };
            BL.SenderEmail senderEmail = new BL.SenderEmail();
            senderEmail.EnviarCorreo(modelSender);
        }
    }
}