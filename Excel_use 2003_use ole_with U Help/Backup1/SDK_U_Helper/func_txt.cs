using System;
using System.Collections.Generic;
using System.Text;

 
   public class func_txt
    {
        #region log
        //�s�X�O�ƥ�         
        // System.Diagnostics.Process.Start(@"E:\123.txt"); 

        public static void log(string Msg)
        {
            log("C:\\\\Log", Msg);
        }
        ///<summary>
        ///log
        ///     </summary>
        ///<param name="StartupPath">�x�s���ؿ���m</param>
        ///<param name="ErrorMsg">�T��</param>    
        public static void log(string StartupPath, string msg)
        {
            string FileName = DateTime.Now.ToString("yyyyMMdd");
            string sPath = null;

            sPath = StartupPath;

            System.IO.DirectoryInfo oDir = new System.IO.DirectoryInfo(sPath);
            if (!oDir.Exists)
            {
                oDir.Create();
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + "\\\\" + FileName + ".log", true, System.Text.Encoding.GetEncoding("utf-8"));

            sw.WriteLine(DateTime.Now.ToString() + " --" + msg);
            sw.Close();
        }
        #endregion
        #region "write and show"
       private void button1_Click(object sender, EventArgs e)
       {
           //�g�J�O�ƥ�
           string msg = "�A�n" + Environment.NewLine;
           msg += "�R�A����μL�ڻ�" + Environment.NewLine;
           string filePath = @"E:\123.txt";
           log(filePath, msg);
       }
       public static void LogAndShow(string filePath, string msg)
       {
           //System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + "\\\\" + FileName + ".log", true, System.Text.Encoding.GetEncoding("utf-8"));
           System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("utf-8"));

           sw.WriteLine(msg);
           sw.Close();

           //�s�X�O�ƥ�         
           System.Diagnostics.Process.Start(filePath);
       }
        #endregion 
    }
 