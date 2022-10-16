/*
    PS3 webMAN current User Game Playing Get From HTML and a RichTextBox 70% Accuracy
    by D.s.j. 
    Discord = d.s.j.#0598
    YouTube = destru0036
    Version 2.0
    using System.Collections;

*/
using ftp;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ps3_webman.Core.Ps3
{

    public class Ps3Sys
    {
        private File_Transfer_Protocol cliftp = new File_Transfer_Protocol();
        readonly private System.Windows.Forms.RichTextBox htmlrichtext = new RichTextBox();
        readonly private System.Windows.Forms.TextBox char_box = new TextBox();
        public ps3_webman.Core.Server.WebMAN_Server Server;
        internal bool Connected = false;
        internal bool UnupdatedValues = false;
        internal bool _Running = false;
        internal string ConIp = "0.0.0.0";
        static string YourOldIp = "";
        static string YourOldHTML = "";
        public string ServerData
        {
            get { return Server.ServerHtmlData; }
        }
        public string ServerName
        {
            get { return Server.Name; }
        }
        public TimeSpan WebServerElapsed
        {
            get { return Server.ServerElapsed; }
        }

        internal File_Transfer_Protocol Ps3Ftp { get => cliftp; private set => cliftp = value; }

        public bool CanReachServer = false;
        #region Events
        internal event EventHandler ConnectedSucessfully;

        internal event EventHandler OnXmb;
        internal event EventHandler OnGame;
        internal event EventHandler OnGettingTemp;
        internal event EventHandler OnGettingGameName;
        internal event EventHandler OnGettingFirmVersion;
        internal event EventHandler OnGettingWmVersion;
        internal event EventHandler OnGettingGameCoverUrl;
        internal event EventHandler OnGettingMemory;
        internal event EventHandler OnGettingHardDisk;
        internal event EventHandler OnGettingUserId;
        internal event EventHandler OnGettingGameRegion;
        internal event EventHandler OnGettingProcessPid;
        internal event EventHandler OnGettingUserDir;
        internal event EventHandler OnGettingFanVel;
        internal event EventHandler OnGettingGameCover;
        internal event EventHandler OnGettingPlayingTime;
        internal event EventHandler OnGettingStartupTime;
        internal event EventHandler OnGettingSysLife;

        #endregion

        public bool ServerIsInGame = false;
        public string LocalUserName = null;
        public Bitmap LocalUserAvatar = null;
        public string CurrentGame = null;
        public string CurrentGameRegion = null;
        public Bitmap CurrentGameIcon = null;
        public string FanValue = null;
        public string CpuRsxTemp = null;
        public string MemoryKb = null;
        public string Harddisk = null;
        public string Firmware = null;
        public string webMAN_Version = null;
        public string Power = null;
        public string strGamePid = null;
        public ulong ulongGamePid = 0;
        public TimeSpan ElapsedGame = TimeSpan.Zero;
        public TimeSpan ElapsedPs3 = TimeSpan.Zero;
        public string UserDirectory = null;
        public string UserId = null;
        public int UserIdI = 0;

        public Timer Refreshor = new Timer();
        public Ps3Sys(string ps3_ip, string serverName)
        {
            BeginInit(ps3_ip, serverName);
            ConIp = ps3_ip;
            Refreshor.Interval = 16000;
            Refreshor.Tick += Refreshor_Tick;

        }
        /// <summary>
        /// Siempre retornará FALSE si es que no se pudo conectar, el servicio ya esta desconectado o se produjo un error.
        /// </summary>
        /// <returns></returns>
        public bool DisconnectServer()
        {
            if (Connected is true && Server.IsConnected is true)
            {
                Refreshor.Stop(); Refreshor.Enabled = false;
                _Running = false;
                UnupdatedValues = true;
                Server.Disconnect();
                return Server.IsConnected && Connected;
            }
            else
            {
                Console.WriteLine("[!] Cannot disconnect, server already discon'" +
                "or error ocurred");
                return false;
            }

        }
        private void Refreshor_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
        private void BeginInit(string ps3_ip, string serverNM)
        {
            Server = new ps3_webman.Core.Server.WebMAN_Server(serverNM, ps3_ip);
            if (Server.IsConnected is true)
            {
                Refreshor.Start();
                Refresh();
                Connected = true;
                _Running = true;
                ReportEvent(ConnectedSucessfully);
                if (Server.ServerHtmlData != string.Empty) { LocalUserName = GetLocalUserName(Server.ServerHtmlData); }
            }
        }
        bool debug = false;
        public bool Refresh()
        {
            bool canReach = CanReachServer || Server.IsConnected;
            if (ConIp != "0.0.0.0" && Server.IsConnected == true && canReach == true)
            {
                try
                {
                    ServerIsInGame = ServerInGame();
                    var html = Server.ServerHtmlData;
                    {
                        if (ServerIsInGame is true)
                        {
                            CurrentGame = GetInGameName(html);
                            CurrentGameRegion = GetGameRegion(html);
                            CurrentGameIcon = GetCurrentGamePic(html, ConIp);
                            FanValue = GetCurrentFanSpeed(html, false);
                            CpuRsxTemp = GetCPU_RSX_TMP(html);

                            MemoryKb = GetCurrentMemory(html);
                            Power = GetPower(html);
                            Harddisk = GetHDD(html);
                            TimeSpan.TryParse(GetPlayingElapsedTime(html), out ElapsedGame);
                            CurrentGame = GetInGameName(html);
                            strGamePid = GetPidProcess(html);
                            ulong.TryParse(GetPidProcess(html), out ulongGamePid);
                            //LocalUserName = GetLocalUserName(html);
                            /* var strt = GetStartupElapsedTime(html)
                                .Replace("d", "").Replace("h", "").Replace("m", "").Replace("s", "");
                             try { ElapsedPs3 = TimeSpan.Parse(strt.Remove(0, 1)); } catch { }*/
                            Firmware = GetFirmware(html);
                            webMAN_Version = GetWMVersion(html);
                            UserDirectory = CurrUserDirectory(html);
                            UserId = CurrUserID(html);

                            var avatarBmp = GetLocalUserAvatar(html);
                            LocalUserAvatar = avatarBmp;

                            try { UserIdI = int.Parse(CurrUserID(html)); } catch { }
                            if (debug is true)
                            {
                                Console.WriteLine(CurrentGame + "\r" + webMAN_Version);
                                Console.WriteLine(CpuRsxTemp + "\r" + FanValue);
                                Console.WriteLine(MemoryKb + "\r" + Harddisk);
                                Console.WriteLine(ElapsedPs3.ToString() + "\r" + Firmware);
                                Console.WriteLine(UserDirectory);
                                Console.WriteLine(UserId);
                                Console.WriteLine(UserIdI);
                                Console.WriteLine(LocalUserName);
                                // Console.WriteLine(strt);
                                Console.WriteLine("|--------- ----------|");
                            }
                            if (LocalUserName == string.Empty)
                            {
                                LocalUserName = GetLocalUserName(html);
                            }
                        }
                        else if (ServerIsInGame is false)
                        {
                            CurrentGameRegion = "VSH00000";
                            CurrentGame = "Xross Media Bar";

                        }

                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("We have disconnected this instance from the server since there was an error updating it, it could be because the console has just been turned off or disconnected from the internet.\rError message: " +
                        ex.Message, "Server error. ", buttons: MessageBoxButtons.OK);
                    Refreshor.Stop();
                    return false;
                }

            }
            else if (Server.IsConnected == false)
            {
                Connected = false;
                return false;
            }
            else if (canReach == false)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        private void ReportEvent(EventHandler handler)
        {
            handler?.Invoke(this, EventArgs.Empty);
        }
        /*
        private void ReportEvent(EventHandler handler, Action speccialAction)
        {
            if (handler != null)
            {
                speccialAction();
                handler(this, EventArgs.Empty);
            }
        }
        private void ReportEvent(EventHandler handler, Action speccialAction, object sender, EventArgs e)
        {
            if (handler != null)
            {
                speccialAction();
                handler(sender, e);
            }
        }
        */
        internal static string ExtractText(string html, int method = 0)
        {
            int valuei = 0;
            if (method is 0)
            {
                if (html == null)
                {
                    throw new ArgumentNullException("html");
                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var chunks = new List<string>();
                var dn = doc.DocumentNode.DescendantNodesAndSelf();
                foreach (var item in dn)
                {
                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "")
                        {
                            chunks.Add(item.InnerText.Trim());
                        }
                    }
                }
                return String.Join(" ", chunks);
            }
            else
            {
                if (html == null)
                {
                    throw new ArgumentNullException("html");
                }

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var chunks = new List<string>();
                var dn = doc.DocumentNode.DescendantNodesAndSelf();
                foreach (var item in dn)
                {

                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "")
                        {
                            chunks.Add(valuei + " - " + item.InnerText.Trim());
                        }
                    }
                    valuei++;
                }
                if (method is 2)
                {
                    return String.Join("\r", chunks);
                }

            }
            return "";
        }
        public string[] ExtractTextToArray(string html)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var chunks = new List<string>();
            var dn = doc.DocumentNode.DescendantNodesAndSelf();
            foreach (var item in dn)
            {
                if (item.NodeType == HtmlNodeType.Text)
                {
                    if (item.InnerText.Trim() != "")
                    {
                        chunks.Add(item.InnerText.Trim());
                    }
                }
            }

            return chunks.ToArray();
        }
        public bool ServerInGame()
        {
            if (Server.ServerHtmlData.Length == 3431)
            {
                ReportEvent(OnGame);
                return true;
            }
            else if (Server.ServerHtmlData.Length != 3332 || Server.ServerHtmlData.Length == 3431)
            {
                ReportEvent(OnGame);
                return true;
            }
            else if (Server.ServerHtmlData.Length != 3431 || Server.ServerHtmlData.Length < 3431)
            {
                ReportEvent(OnXmb);
                return false;
            }
            else
            {
                ReportEvent(OnXmb);
                return false;
            }


        }
        public string InternalRefreshHTML(string consoleIP)
        {
            return Server.ServerHtmlData;
        }
        public string GetCurrentGameString(int method = 0, string ip = "Leave blank to use old session ip", string OptionalHTML = "oldhtml")
        {
            string optionalHTML = "";
            OptionalHTML = YourOldHTML;
            ReportEvent(OnGettingGameName);
            if (OptionalHTML == "oldhtml" || OptionalHTML == string.Empty == false)
            { throw new Exception("Please provide a HTML code or save one."); }

            if (OptionalHTML != "oldhtml")
            { YourOldHTML = OptionalHTML; optionalHTML = YourOldHTML; }

            ///
            /// GCGS Methods
            /// 
            /// 0 = Homemade method, need IP, a bit slowly, but accuraccy 70%
            /// 1 = Substring method, fast, but 50% accuraccy 
            /// 2 = same as 1 but returns only game region
            /// 3 = substrings mode, 90% accuraccy
            /// 4 = substrings mode, but region only
            ///
            string result = "";
            try
            {
                if (method == 0)
                {
                    if (ip == "Leave blank to use old session ip" || ip == "")
                        ip = YourOldIp;
                    #region homemade method
                    this.char_box.Font = new System.Drawing.Font("Consolas", 12F);
                    this.char_box.Location = new System.Drawing.Point(12, 412);
                    this.char_box.Name = "char_box";
                    this.char_box.Size = new System.Drawing.Size(22, 26);
                    this.char_box.TabIndex = 3;
                    this.char_box.Text = "\"";

                    htmlrichtext.Location = new System.Drawing.Point(40, 401);
                    this.htmlrichtext.Name = "htmlrichtext";
                    this.htmlrichtext.Size = new System.Drawing.Size(639, 37);
                    this.htmlrichtext.TabIndex = 2;
                    this.htmlrichtext.Text = "";
                    this.htmlrichtext.Visible = false;

                    #endregion

                    #region Text Mechanism
                    WebClient web = new WebClient();
                    string userip = ip;
                    string userUrl = $"http://{ip}/cpursx.ps3";
                    System.IO.Stream stream = web.OpenRead(userUrl);

                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        String text = reader.ReadToEnd();
                        htmlrichtext.Text = text;
                        text.Split('<');

                    }
                    web.Dispose();


                    {
                        #region Delete main html arguments
                        var str = htmlrichtext.Text;
                        var charsToRemove = new string[] { "<a", "<", "https", "http", "google", "DOCTYPE", "HTML", "img", "a/>", ">", "<div", "Â",  //"height=", "html", "href", "top", @"/dev_hdd0/xmlhost/game_plugin/common.js", @"</script></font></body></html>", @"/a", "&nbsp;",  "/dev_bdvd", "src=", "/dev_hdd0/tmp/wm_icons/icon_wm_ps3.png", "&#9650;/a/divbscript src=", "/script/font/body/", "&#9650;", "#top"
            };
                        foreach (var c in charsToRemove)
                        {
                            str = str.Replace(c, string.Empty);
                            htmlrichtext.Text = str;
                        }
                        #endregion

                        #region Delete all others lines of code and get only the game name string

                        htmlrichtext.SelectionColor = Color.Red;
                        htmlrichtext.SelectionStart = 0;
                        htmlrichtext.SelectionLength = 1325;
                        htmlrichtext.SelectedText = "";

                        htmlrichtext.SelectionColor = Color.Yellow;
                        htmlrichtext.SelectionStart = 124;
                        htmlrichtext.SelectionLength = 1740;
                        htmlrichtext.SelectedText = "";

                        htmlrichtext.SelectionColor = Color.Green;
                        htmlrichtext.SelectionStart = 0;
                        htmlrichtext.SelectionLength = 57;
                        htmlrichtext.SelectedText = "";
                        #endregion

                        #region Delete Rest of Html Arguments
                        var str2 = htmlrichtext.Text;
                        var charsToRemove2 = new string[] { "/a", "&nbsp;", "q=", "BLES", "NPUB", "BLUS","NPEB","/","dev_hdd0", "BLE", "game", "scriptfontbodyhtml"
        };

                        foreach (var c in charsToRemove2)
                        {

                            str2 = str2.Replace(c, string.Empty);
                            htmlrichtext.Text = str2;
                        }


                        #endregion

                    }
                    string gamename = htmlrichtext.Text;
                    string chtb = char_box.Text;
                    char chartb = char.Parse(chtb);
                    string chnew2 = "\n";
                    char chartnew = char.Parse(chnew2);

                    gamename.Replace(chartb, char.Parse("\r"));

                    htmlrichtext.Text = gamename.Replace(chartb, char.Parse("\r"));
                    DeleteLine(1);



                    if (htmlrichtext.Text.Contains("GB libres"))
                    {
                        htmlrichtext.Text = "On XMB";
                    }
                    #endregion

                    result = htmlrichtext.Text;

                    htmlrichtext.Dispose();
                    web.Dispose();
                    YourOldIp = ip;
                }
                if (method == 1 || method == 2)
                {
                    string gameregion = "";
                    string key = optionalHTML.Replace(optionalHTML.Substring(0, 1388), "");
                    key = key.Replace(key.Substring(0, 43), "");
                    gameregion = key.Substring(0, 9);
                    string v1 = $"/{gameregion}-ver.xml\" target=\"_blank\">{gameregion}</a> <a";
                    key = key.Replace(v1, "");
                    key = key.Replace(key.Substring(73, 33), "{SEPARATOR_SIGN!}");

                    int GN_Index = key.IndexOf("{SEPARATOR_SIGN!}");
                    key = key.Replace("href=\"http://google.com/search?q=", " - ");
                    key = key.Replace(key.Substring(GN_Index, key.Length - GN_Index), "");
                    key = key.Replace("\">{SEPARATOR_SIGN!} &nbsp; <a hr", "");
                    if (method == 2)
                    {
                        key = key.Substring(0, 9);
                    }

                    result = key;
                }
                if (method == 3 || method == 4)
                {
                    string data = optionalHTML;
                    int keyIndex = optionalHTML.IndexOf("https://a0.ww.np.dl.playstation.net/tpl/np/");
                    int gameKeyIndex = optionalHTML.IndexOf("<a href=\"http://google.com/search?q=");
                    var separator = "\">";
                    var length = data.IndexOf(separator);
                    string GameName = data.Substring(gameKeyIndex + 36, length);


                    string gregion = data.Substring(keyIndex + 43, 9);
                    result = GameName;

                    if (method == 4)
                    { result = gregion; }

                }
            }
            catch
            {
                result = "HTML invalid formatting.";
            }
            return result;
        }
        public string GetInGameName(string wm_html_cpursx)
        {
            string result = "";
            try
            {
                string html = wm_html_cpursx;
                string codetext = html.Replace("&nbsp;", "[DSJ_INDEX_DETECTOR]");
                int fkeyIndex = codetext.IndexOf("[DSJ_INDEX_DETECTOR]") - 5;
                string trashvalue = "http://google.com/search?q=";
                int trashCountIndex = codetext.IndexOf(trashvalue) + 27;
                codetext = codetext.Remove(0, trashCountIndex);
                codetext = codetext.Remove(fkeyIndex);
                string trashvalue2 = "</a> [DSJ_INDEX_DETECTOR]";
                int tsv2_Index = codetext.IndexOf(trashvalue2);
                ReportEvent(OnGettingGameName);
                codetext = codetext.Remove(tsv2_Index);
                string lastseparator = "\">";
                codetext = codetext.Remove(codetext.IndexOf(lastseparator));
                codetext = codetext.Replace("Â", "");
                result = codetext;
                //MessageBox.Show(codetext);
                ReportEvent(OnGame);
            }
            catch
            {
                result = "XMB (VSH)";
                ReportEvent(OnXmb);
            }

            return result;
        }
        public string GetGameRegion(string wm_html_cpursx)
        {
            ReportEvent(OnGettingGameRegion);
            string key = ".xml\" target=\"_blank\">";
            if (wm_html_cpursx.IndexOf(key) != -1)
            {
                var html = wm_html_cpursx;
                int resultIndex = html.IndexOf(key);
                return html.Remove(resultIndex, key.Length).Substring(resultIndex, 9);
            }
            else
            {
                return "vsh.self";
            }
        }
        public string GetPlayingElapsedTime(string wm_html_cpursx)
        {
            ReportEvent(OnGettingPlayingTime);
            var key = "<hr><label title=\"Play\">";
            {
                if (wm_html_cpursx.IndexOf(key) != -1)
                {
                    var html = wm_html_cpursx;
                    int keyIndex = wm_html_cpursx.IndexOf(key);
                    var result = html.Substring(keyIndex + 43, 8);
                    return result;
                }
                else
                {
                    return "UNKNOWN";
                }
            }
        }

        public string GetPidProcess(string wm_ps3_html_cpursx)
        {
            ReportEvent(OnGettingProcessPid);
            string key = "gameplugin.ps3mapi?proc=";
            var html = wm_ps3_html_cpursx;
            int keyIndex = html.IndexOf(key);
            {
                if (keyIndex != -1)
                {

                    return html.Substring(keyIndex + key.Length, 8);
                }
                else
                {
                    return "vsh00000";
                }
            }
        }
        public string GetWMVersion(string wm_ps3_html)
        {
            string Result = "";
            try
            {
                string trashtext = wm_ps3_html.Substring(0, 3165);
                string newhtml = wm_ps3_html.Replace(trashtext, "");
                ReportEvent(OnGettingWmVersion);
                Result = newhtml.Substring(0, 19);
                ///Result.Replace()
            }
            catch
            {
                Result = "Exception produced. Try later";
            }

            return Result;
        }
        private string DeleteLine(int a_line)
        {
            int start_index = htmlrichtext.GetFirstCharIndexFromLine(a_line);
            int count = htmlrichtext.Lines[a_line].Length;

            if (a_line < htmlrichtext.Lines.Length - 1)
            {
                count += htmlrichtext.GetFirstCharIndexFromLine(a_line + 1) -
                    ((start_index + count - 1) + 1);
            }

            htmlrichtext.Text = htmlrichtext.Text.Remove(start_index, count);
            return htmlrichtext.Text;
        }
        public string GetCPU_RSX_TMP(string wm_ps3_html)
        {
            string result = "";
            string HTML = wm_ps3_html;
            try
            {
                int keyIndex_1 = HTML.IndexOf("CPU:");
                int keyIndex_2 = HTML.IndexOf("RSX:");
                ReportEvent(OnGettingTemp);
                string i_cpu = HTML.Substring(keyIndex_1, 10);
                string i_rsx = HTML.Substring(keyIndex_2, 10);
                string str = i_cpu + " " + i_rsx;
                str = str.Replace("Â", "");
                result = str;
                return result;
            }
            catch
            {
                result = "Unhandled Error while converting strings. (055348673)";
                return result;
            }


        }
        public string GetPower(string wm_ps3_html)
        {
            var key = "\'/dev_hdd0/tmp/wm_icons/power.png\' style='position:relative;top:8px;\'>";
            var html = wm_ps3_html;
            int IndexOfKey = html.IndexOf(key);
            ReportEvent(OnGettingSysLife);
            if (IndexOfKey != -1)
            {
                return html.Substring(IndexOfKey + 1 + key.Length, 45);
            }
            else
            {
                return "Unknown (0x10)";
            }
        }
        public Bitmap GetLocalUserAvatar(string wm_ps3_html)
        {
            try
            {
                string uriprefix = $"http://{Server.IpAddress}";
                string link = uriprefix + CurrUserDirectory(wm_ps3_html) + "/friendim/avatar/me.png";
                System.Net.WebRequest request =
                System.Net.WebRequest.Create(link);
                return new Bitmap(request.GetResponse().GetResponseStream());
            }
            catch (Exception ex)
            {
                Console.WriteLine("INTERNAL EXCEPTION: " + ex.Message + " strace: " + ex.StackTrace);

                return SystemIcons.Error.ToBitmap();
            }
        }
        public string GetCurrGameImageURL(string wm_ps3_html, bool LetUserCheck)
        {
            int keyIndex = wm_ps3_html.IndexOf("<img src=\"/dev_hdd0/game/");
            string keyString = wm_ps3_html.Substring(keyIndex, 44);
            keyString = keyString.Replace("<img src=\"", "");
            ReportEvent(OnGettingGameCoverUrl);
            if (LetUserCheck == true)
            {
                MessageBox.Show(keyString);
            }
            return keyString;
        }
        public string GetCurrentMemory(string wm_ps3_html_cpursx)
        {
            if (GetInGameName(wm_ps3_html_cpursx) is "XMB (VSH)" == false)
            {
                var HTML = wm_ps3_html_cpursx;
                int keyIndex = HTML.IndexOf("class=\"s\" href=\"/games.ps3\">");
                string value = HTML.Substring(keyIndex + 28, 13);
                ReportEvent(OnGettingMemory);
                /// MessageBox.Show(value);
                if (value is "s=\"http:")
                {
                    return "0kb Xmb";
                }
                return value;
            }
            else
            {
                return "1.541kb";
            }

        }
        public string GetHDD(string wm_ps3_html_cpursx)
        {
            var HTML = wm_ps3_html_cpursx;
            string key = "/a><br><a href=\"/dev_hdd0\">";
            int keyIndex = HTML.IndexOf(key);
            string value = HTML.Substring(keyIndex + 27, 12);
            ReportEvent(OnGettingHardDisk);
            return value;
        }
        public string CurrUserID(string wm_ps3_html_cpursx)
        {
            var HTML = wm_ps3_html_cpursx;
            try
            {
                string key = "br><a href=\"/dev_hdd0/home/";
                int FIndex = HTML.IndexOf(key);
                string FValue = HTML.Substring(FIndex + 27, 8);
                ReportEvent(OnGettingUserId);
                return FValue;
            }
            catch
            {
                return "000000000";
            }

        }
        public string CurrUserDirectory(string wm_ps3_html_cpursx)
        {
            string result = "";
            try
            {
                var HTML = wm_ps3_html_cpursx;
                string key = "br><a href=\"/dev_hdd0/home/";
                int FIndex = HTML.IndexOf(key);
                string FValue = HTML.Substring(FIndex + 12, 23);
                result = FValue;
                if (result == "html><html xmlns=\"http:")
                {
                    result = "XMB ERROR";
                }
                ReportEvent(OnGettingUserDir);
                return result;
                //
            }

            catch
            {
                result = "Error while processing strings.";
                return result;
            }


        }
        public string GetLocalUserName(string wm_ps3_html_cpursx)
        {
            WebClient wc = new WebClient();

            var usrDir = CurrUserDirectory(wm_ps3_html_cpursx);
            {
                if (usrDir == "XMB ERROR" || usrDir == "Error while processing strings.")
                {
                    wc.Dispose();
                    wc = null;
                    return "";
                }
                else
                {
                    string filePrefix = $@"http://{Server.IpAddress}{usrDir}/localusername";
                    Console.WriteLine("FILE PREFIX: " + filePrefix);
                    byte[] result = wc.DownloadData(filePrefix);
                    wc.Dispose();
                    return System.Text.Encoding.UTF8.GetString(result);
                }
            }
        }
        public string GetCurrentFanSpeed(string wm_ps3_html_cpursx, bool letcheck)
        {
            try
            {
                ReportEvent(OnGettingFanVel);
                var HTML = wm_ps3_html_cpursx;
                string keyToSearch = "href=\"/cpursx.ps3?mode\"";
                int FPhraseIndex = HTML.IndexOf(keyToSearch);
                string Fvalue = HTML.Substring(FPhraseIndex + 24, 21);
                if (letcheck == true)
                    MessageBox.Show(Fvalue);

                return Fvalue;
            }
            catch
            {
                return "";
            }


        }
        public Bitmap GetCurrentGamePic(string wm_ps3_html, string consoleIp, bool letcheck = false)
        {
            try
            {
                string uriprefix = $"http://{consoleIp}";
                string link = uriprefix + GetCurrGameImageURL(wm_ps3_html, false);
                if (letcheck == true)
                    MessageBox.Show("URL: " + link);
                System.Net.WebRequest request =
                System.Net.WebRequest.Create(link);
                ReportEvent(OnGettingGameCover);

                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();

                Bitmap bmp = new Bitmap(responseStream);
                return bmp;
            }
            catch
            {
                return SystemIcons.Error.ToBitmap();
            }

        }
        public string GetFirmware(string wm_ps3_html_cpursx)
        {
            try
            {
                string HTML = wm_ps3_html_cpursx;
                int keyIndex = HTML.IndexOf("<a class=\"s\" href=\"/setup.ps3\">");
                string valueFormat = HTML.Substring(keyIndex + 31, 19);
                ReportEvent(OnGettingFirmVersion);
                return valueFormat;

            }
            catch
            {
                return "";
            }

        }
        public bool crs()
        {
            var outBool = Server.RefreshServerData("CRS Boolean");
            CanReachServer = outBool;
            return outBool;
        }
    }
}
namespace ps3_webman.Core.Server
{

    public class WebMAN_Server
    {
        public event EventHandler EVH_CONNECTED;
        public event EventHandler EVH_DISCONNECTED;
        public event EventHandler EVH_DATA_CHANGED;
        public WebMAN_Server(string serverName, string ipAddress)
        {
            STR_SERV_IP_ADDRESS = ipAddress;
            STR_SERV_NAME = "http://" + ipAddress + "/cpursx.ps3/" + serverName;
            TMR_TICK = new Timer();
            TMR_TICK.Tick += TMR_TICK_Tick;
            TMR_TICK.Interval = 16000;
            Connect();

        }

        private void TMR_TICK_Tick(object sender, EventArgs e)
        {
            if (BOOL_SERV_CONNECTED == false)
            {
                TMR_TICK.Stop();
            }
            else if (BOOL_SERV_CONNECTED == true)
            {
                RefreshServerData("TickRefresh");
                if (ACT_CONNECTED_TICK_ACTION != null)
                {
                    ACT_CONNECTED_TICK_ACTION();
                }
            }

            ServerElapsed.Add(new TimeSpan(0, 0, 16));
        }
        private static WebClient WEB_SERV_CLI = new WebClient();
        private static bool BOOL_SERV_CONNECTED = false;
        private static TimeSpan TMSP_SERV_ELAPSED;
        private static string STR_SERV_DATA = null;
        private static string STR_SERV_IP_ADDRESS = null;
        private static string STR_SERV_NAME = null;
        private static Timer TMR_TICK = null;
        private static int INT_SERV_TFETCHES = 0;
        private static Action ACT_CONNECTED_TICK_ACTION = null;
        public Action ConnectedTickAction
        {
            get { return ACT_CONNECTED_TICK_ACTION; }
            set { ACT_CONNECTED_TICK_ACTION = value; }
        }
        public bool IsConnected
        {
            get { return BOOL_SERV_CONNECTED; }
            private set { BOOL_SERV_CONNECTED = value; }
        }
        public string Name
        {
            get { return STR_SERV_NAME; }
        }
        public string IpAddress
        {
            get { return STR_SERV_IP_ADDRESS; }
            private set { STR_SERV_IP_ADDRESS = value; }
        }
        public TimeSpan ServerElapsed
        {
            get { return TMSP_SERV_ELAPSED; }
            private set { TMSP_SERV_ELAPSED = value; }
        }
        public string ServerHtmlData
        {
            get { return STR_SERV_DATA; }
            private set { STR_SERV_DATA = value; }
        }
        public int ServerTotalFetches
        {
            get { return INT_SERV_TFETCHES; }
            private set { INT_SERV_TFETCHES = value; }
        }
        private void ReportEvent(EventHandler eventHandler, object sender)
        {
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }
        internal void Connect()
        {
            var userUrl = $"http://{STR_SERV_IP_ADDRESS}/cpursx.ps3";
            try
            {
                IsConnected = true;
                BOOL_SERV_CONNECTED = true;
                ReportEvent(EVH_CONNECTED, WEB_SERV_CLI);
                TMR_TICK.Start();
                //RefreshServerData("void Connect");

                ServerTotalFetches++;
            }
            catch
            {
                MessageBox.Show("Cannot Connect!");
                IsConnected = false;
                return;
            }
        }
        internal void Disconnect()
        {
            TMR_TICK.Stop();
            ReportEvent(EVH_DISCONNECTED, this);
            TMSP_SERV_ELAPSED = new TimeSpan(0, 0, 0, 0);
            STR_SERV_DATA = null;
            BOOL_SERV_CONNECTED = false;
            WEB_SERV_CLI = new WebClient();
        }
        internal bool RefreshServerData(string senderString)
        {
            if (IsConnected == true)
            {
                try
                {

                    string userUrl = $"http://{STR_SERV_IP_ADDRESS}/cpursx.ps3";
                    System.IO.Stream stream = WEB_SERV_CLI.OpenRead(userUrl);
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        ReportEvent(EVH_DATA_CHANGED, reader);
                        STR_SERV_DATA = reader.ReadToEnd();
                        Console.WriteLine(STR_SERV_DATA + "\r[!] (Sender: " + senderString + ") Data sucessfully updated for server: " + STR_SERV_NAME + "\r");
                        return true;
                    }
                }
                catch (Exception ex) { Console.WriteLine("\a[!] Ex: " + ex.Message + "\rType: " + ex.GetType() + " At: " + ex.TargetSite); return false; }


            }
            else
            {
                return false;
            }

        }

    }
}




