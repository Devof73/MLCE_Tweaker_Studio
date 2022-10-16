using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ftp
{
    internal class File_Transfer_Protocol : IDisposable
    {
        private bool disposed;
        ~File_Transfer_Protocol()
        {
            this.Dispose(false);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }

        internal byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

        internal void Upload(string url, string filename, string username = "username", string password = "password")
        {
            var ftpWebRequest = WebRequest.Create(url) as FtpWebRequest;
            ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpWebRequest.Credentials = new NetworkCredential(username, password);
            byte[] fileData = FileToByteArray(filename);
            using (var requestStream = ftpWebRequest.GetRequestStream())
            {
                requestStream.Write(fileData, 0, fileData.Length);
            }
            var response = ftpWebRequest.GetResponse() as FtpWebResponse;
            Console.WriteLine(response.StatusDescription);
        }
        internal void Upload(string url, string filename)
        {
            WebClient client = new WebClient();
            client.UploadFile(url, WebRequestMethods.Ftp.UploadFile, filename);
        }
        internal void Upload(string url, string filename, NetworkCredential credentials)
        {
            WebClient client = new WebClient();
            client.Credentials = credentials;
            client.UploadFile(url, WebRequestMethods.Ftp.UploadFile, filename);
        }
        internal void UploadwMsg(string url, string filename, string endMsg = "")
        {
            bool silentDetector = true;
            try
            {
                var ftpWebRequest = WebRequest.Create(url) as FtpWebRequest;
                ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpWebRequest.Credentials = new NetworkCredential("n7a", "n7a");
                byte[] fileData = File.ReadAllBytes(filename);
                using (var requestStream = ftpWebRequest.GetRequestStream())
                {
                    requestStream.Write(fileData, 0, fileData.Length);
                }
                var response = ftpWebRequest.GetResponse() as FtpWebResponse;
                Console.WriteLine(response.StatusDescription);
                silentDetector = true;
            }
            catch
            {
                silentDetector = false;
            }
            if (silentDetector == true && endMsg != string.Empty) { MessageBox.Show(endMsg); }
        }
        internal bool Upload(string url, byte[] fileData, string username = "username", string password = "password")
        {
            try
            {
                var ftpWebRequest = WebRequest.Create(url) as FtpWebRequest;
                ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpWebRequest.Credentials = new NetworkCredential(username, password);
                using (var requestStream = ftpWebRequest.GetRequestStream())
                {
                    requestStream.Write(fileData, 0, fileData.Length);
                }
                var response = ftpWebRequest.GetResponse() as FtpWebResponse;
                Console.WriteLine(response.StatusDescription);
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal bool DownloadFile(string ftpFileName, string outputFileName)
        {
            try
            {
                string ftpfullpath = ftpFileName;
                using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential("UserName", "P@55w0rd");
                    byte[] fileData = request.DownloadData(ftpfullpath);

                    using (FileStream file = File.Create(outputFileName))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        internal void CreateDir(string host, string dirname, string username = "username", string password = "password")
        {
            WebRequest request = WebRequest.Create($"{host}/{dirname}");
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(username, password);
            using (var resp = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine(resp.StatusCode);
            }

        }
        internal void DownloadURI(string filepath, string savepath, string username = "username", string password = "password")
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential(username, password);
            client.DownloadFile(filepath, savepath);
            client.Dispose();
        }
        internal void Rename(string ftp_filename, string newFileName, string username = "username", string password = "password")
        {
            FtpWebRequest ftpRequest = null;
            FtpWebResponse ftpResponse = null;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(ftp_filename);
                ftpRequest.Credentials = new NetworkCredential(username, password);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                ftpRequest.RenameTo = newFileName;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                Console.WriteLine(ftpResponse.StatusDescription);
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch { }
        }
        internal void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
        {
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (var listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (var listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    lines.Add(listReader.ReadLine());
                }
            }

            foreach (string line in lines)
            {
                string[] tokens =
                    line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[8];
                string permissions = tokens[0];

                string localFilePath = Path.Combine(localPath, name);
                string fileUrl = url + name;

                if (permissions[0] == 'd')
                {
                    if (!Directory.Exists(localFilePath))
                    {
                        Directory.CreateDirectory(localFilePath);
                    }

                    DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
                }
                else
                {
                    FtpWebRequest downloadRequest =
                        (FtpWebRequest)WebRequest.Create(fileUrl);
                    downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    downloadRequest.Credentials = credentials;

                    using (FtpWebResponse downloadResponse =
                              (FtpWebResponse)downloadRequest.GetResponse())
                    using (Stream sourceStream = downloadResponse.GetResponseStream())
                    using (Stream targetStream = File.Create(localFilePath))
                    {
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            targetStream.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }
        internal void UploadFtpDirectory(string sourcePath, string url, NetworkCredential credentials)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(sourcePath);
            foreach (string file in files)
            {
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine($"Uploading {file}");
                    client.Credentials = credentials;
                    client.UploadFile(url + Path.GetFileName(file), file);
                }
            }

            IEnumerable<string> directories = Directory.EnumerateDirectories(sourcePath);
            foreach (string directory in directories)
            {
                string name = Path.GetFileName(directory);
                string directoryUrl = url + name;

                try
                {
                    Console.WriteLine($"Creating {name}");
                    FtpWebRequest requestDir =
                      (FtpWebRequest)WebRequest.Create(directoryUrl);
                    requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                    requestDir.Credentials = credentials;
                    requestDir.GetResponse().Close();

                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode ==
                          FtpStatusCode.ActionNotTakenFileUnavailable)
                    {


                    }
                    else
                    {
                        throw;
                    }
                }

                UploadFtpDirectory(directory, directoryUrl + "/", credentials);
            }
        }
        internal bool CheckFileExist(string url, bool UseBinary)
        {

            var request = (FtpWebRequest)WebRequest.Create
            (url);
            request.Credentials = new NetworkCredential("user", "pass");
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.UseBinary = UseBinary;
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                return false;
            }
        }
        internal bool DeleteFileOnFtpServer(string uriString, bool ssl = false, bool binary = false, string ftpUsername = "def", string ftpPassword = "default")
        {
            var serverUri = new Uri(uriString);
            try
            {

                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return false;
                }
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.UseBinary = binary;
                request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequired;

                request.EnableSsl = ssl;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("[!¡] DEL: {0}", response.StatusDescription);
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[!*] ERR: {ex.GetType()} : {ex.Message} ||| {ex.StackTrace}");
                return false;
            }
        }
        public bool DirectoryExists(string dirPath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(dirPath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }
        internal void DeleteFtpDirectory(string url, NetworkCredential credentials)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            request.Credentials = credentials;
            request.GetResponse().Close();
        }


    }
}
