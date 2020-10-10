using System;
using System.Collections.Generic;
using System.IO;
using System.Net.FtpClient;

// connect the library System.Net.FtpClient
// documentation https://netftp.codeplex.com/

namespace MantisTest
{
    public class FtpHalper : HelperBase
    {
        private FtpClient client;

        public FtpHalper(AppManager appManager) : base(appManager) 
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }


        // Save current config file
        public void BeckupFile(string path)
        {
            string backupPath = path + ".bak";

            // if config_inc.php.bak is exist - do nothing
            if (client.FileExists(path))
            {
                return;
            }

            client.Rename(backupPath, path);
        }

        // Recovery defold config file
        public void RestoreBeckupFile(string path)
        {
            string backupPath = path + ".bak";

            // if file config_inc.php.bak does not exist then we cannot restore
            if (!client.FileExists(backupPath))
            {
                return;
            }
            else if (client.FileExists(path)) // if file config_inc.php exist, need to delete it
            {
                client.DeleteFile(path);
            }

            client.Rename(backupPath, path);
        }

        // Upload custom config file
        public void Upload(string path, Stream localFile )
        {
            // if file config_inc.php exist, need to delete it
            if (client.FileExists(path)) 
            {
                client.DeleteFile(path);
            }

            using (Stream ftpStream = client.OpenWrite(path)) 
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, buffer.Length);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
