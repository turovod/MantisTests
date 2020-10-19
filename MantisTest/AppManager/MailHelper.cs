using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpaqueMail;

// to receive mail, the POP3 protocol is used
// this requires a library OpaqueMail (.NET email library with full support for IMAP, POP3, and SMTP)

namespace MantisTest
{
    public class MailHelper : HelperBase
    {
        public MailHelper(AppManager manager) : base(manager) { }

        public string GetLastMail(AccountData account)
        {
            //Pop3Client pop3 = new Pop3Client("localhost", 110, account.Name, account.Password, false);

            //pop3.Connect();
            //pop3.Authenticate(); // We send the username and password

            // The mailbox is new and has no mails

            for (int i = 0; i < 20; i++)
            {
                // The pop3 protocol is cached. So that every iteration is not cached, we create a new connection.
                Pop3Client pop3 = new Pop3Client("localhost", 110, account.Name, account.Password, false);

                pop3.Connect();
                pop3.Authenticate(); // We send the username and password

                if (pop3.GetMessageCount() > 0)
                {
                    // We receive a mail by index.
                    // Index starts from 1, numbering from the last mail
                    MailMessage message = pop3.GetMessage(1);

                    string body = message.Body;

                    pop3.DeleteMessage(1);
                    pop3.LogOut(); // Logoute be sure that as it confirms the deletion

                    return body;
                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                }
            }

            return null;
        }
    }
}
