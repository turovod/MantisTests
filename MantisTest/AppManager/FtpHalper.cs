using System;
using System.IO;
using System.Net.FtpClient;

// connect the library System.Net.FtpClient
// documentation https://netftp.codeplex.com/

namespace MantisTest
{
    public class FtpHalper : HelperBase
    {
        private FtpClient client;

        public FtpHalper(AppManager manager) : base(manager)
        {
            client = new FtpClient();
            client.Host = "localhost";
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Connect();
        }

        // Save current config file
        public void BackupFile(String path)
        {
            String backupPath = path + ".bak";

            // if config_inc.php.bak is exist - do nothing
            if (client.FileExists(backupPath))
            {
                return;
            }
            client.Rename(path, backupPath);
        }

        // Recovery defold config file
        public void RestoreBackupFile(String path)
        {
            String backupPath = path + ".bak";

            // if file config_inc.php.bak does not exist then we cannot restore

            if (!client.FileExists(backupPath))
            {
                return;
            }
            if (client.FileExists(path))// if file config_inc.php exist, need to delete it
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath, path);
        }

        // Upload custom config file
        public void Upload(String path, Stream localFile)
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
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
