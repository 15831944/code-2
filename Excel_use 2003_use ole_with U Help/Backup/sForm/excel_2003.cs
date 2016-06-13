using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Data.OleDb;
using System.IO; 
namespace Panbor_ImportWebSO
{
    public partial class excel_2003 : Form
    {
        private bool allChk = false;//�ثe�ȵL�ϥ�.2011.11.15
 

        System.Data.DataTable oDT;
      
        //for init set 

        int RetVal = 0;
        int ErrCode = 0;
        string ErrMsg = null;


        public excel_2003()
        {
            InitializeComponent();
           
        }
 
        #region event  
        private void Search()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "all|*.*|xls Excel �ɮ�|*.xls|xlsx 2007 Excel �ɮ�|*.xlsx";
            openFileDialog1.Title = "Select a Excel File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextFilePath.Text = openFileDialog1.FileName;
            }
        }
   

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //���JEXCEL,�ˬd���W��,�ˬditem�s�b�_.�ˬd�q��O�_�s�b.
            BtnSearch.Enabled = false;
            try
            {
                Search();
                if (TextFilePath.Text == string.Empty)
                {
                    BtnSearch.Enabled = true;
                    return;
                }
 
 


                oDT = loadGridFromExcel(TextFilePath.Text, "");
                GV.DataSource = oDT;
                GV.AllowUserToAddRows = false;
                GV.ReadOnly = true;

                CloseDGVSort(ref GV); 

 

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("�~����ƪ��O�w�����榡"))
                {
                    //appl.MessageBox("�бN�ɮץt�s��2003�榡!!", MessageType.Error);
                }
                else if (ex.Message.Contains("�L�ȴ��ѵ��@�Φh�ӥ��n�Ѽ�"))
                {
                    //appl.MessageBox("�ɮת����榡���~�A���ˬd�ɮ׻P��~�٦�O�_�۲�!!", MessageType.Error);
                }
                else
                {
                    //appl.MessageBox("�פJ����!!" + ex.ToString(), MessageType.Error);

                }
            }
            BtnSearch.Enabled = true;
        }
        private void CloseDGVSort(ref  DataGridView _GV)
        {
            for (int i = 0; i < GV.Columns.Count; i++)
            {
                _GV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
 
 
      
        private void ImportWebSO_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion


      �@      public System.Data.DataTable loadGridFromExcel(string astrFileName, string orderCmd)
         {
             System.Data.DataTable ret;
             func_excel_read f = new func_excel_read();

             // "D:\cadmen\�A�ȳ�\�Ȥᴣ�Ѫ����\panbor\_test\�j�R�a_test.xls"
             string strSheetName = f.GetExcelWorkSheets(astrFileName)[0].ToString().Trim();
              string cmd = "Select  * from [{0}$] {1}"; 
             cmd = string.Format(cmd, strSheetName, orderCmd);
             ret = f.GetExcelData(astrFileName, cmd);// order by �q��s��");

             return ret;
         }
 


   
 


 




    }
      public class func_excel_read
 {
    //�ϥλ���
    
   
        //public DataTable GetExcelData(string astrFileName)
        //{
        //    string strSheetName = GetExcelWorkSheets(astrFileName)[0].ToString();
        //    return GetExcelData(astrFileName, strSheetName);
        //}
        //GetExcelData���Ψ�.
        public  ArrayList GetExcelWorkSheets(string strFilePath)
        {
            ArrayList alTables = new ArrayList();

            OleDbConnection odn = new OleDbConnection(GetExcelConnection(strFilePath));
            odn.Open();

            DataTable dt = new DataTable();

            dt = odn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                throw new Exception("can't read");
            }

            foreach (DataRow dr in dt.Rows)
            {
                string tempName = dr["Table_Name"].ToString();

                int iDolarIndex = tempName.IndexOf("$");

                if (iDolarIndex > 0)
                {
                    tempName = tempName.Substring(0, iDolarIndex);
                }


                if (string.IsNullOrEmpty(tempName[0].ToString()))
                {
                    if (string.IsNullOrEmpty(tempName[tempName.Length - 1].ToString()))
                    {
                        tempName = tempName.Substring(1, tempName.Length - 2);
                    }
                    else
                    {
                        tempName = tempName.Substring(1, tempName.Length - 1);

                    }
                }
                if (!alTables.Contains(tempName))
                {
                    alTables.Add(tempName);
                }
            }

            odn.Close();

            if (alTables.Count == 0)
            {
                return null;
            }

            return alTables;
        }
        //public   DataTable GetExcelData(string FilePath, string WorkSheetName)
        //{
        //    if (WorkSheetName =="")
        //        WorkSheetName = GetExcelWorkSheets(FilePath)[0].ToString();
        //    DataTable dtExcel = new DataTable();
        //    OleDbConnection con = new OleDbConnection(GetExcelConnection(FilePath));
        //    OleDbDataAdapter adapter = new OleDbDataAdapter("Select *  from [" + WorkSheetName + "$]", con);
        //    con.Open();
        //    adapter.FillSchema(dtExcel, SchemaType.Mapped);
        //    adapter.Fill(dtExcel);
        //    con.Close();
        //    dtExcel.TableName = WorkSheetName;

        //    return dtExcel;
        //}


          public DataTable GetExcelData(string FilePath, string cmd)
          {
              DataTable dtExcel = new DataTable();
              OleDbConnection con = new OleDbConnection(GetExcelConnection(FilePath));
              OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, con);
              con.Open();
              adapter.FillSchema(dtExcel, SchemaType.Mapped);
              adapter.Fill(dtExcel);
              con.Close();
              dtExcel.TableName = "";

              return dtExcel;
          }
        public string GetExcelConnection(string strFilePath)
        {
            if (!File.Exists(strFilePath))
            {
                throw new Exception("no file�I");
            }
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended properties=\"Excel 8.0;Imex=1;HDR=Yes;\"";
            //Return "Provider=Microsoft.Jet.OLEDB.12.0;Data Source=" & strFilePath & ";Extended properties=""Excel 12.0;Imex=1;HDR=No;"""

            //@"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //@"Data Source=" + strFilePath + ";" +
            //@"Extended Properties=" + Convert.ToChar(34).ToString() +
            //@"Excel 8.0;" + "Imex=1;HDR=Yes;" + Convert.ToChar(34).ToString();        
        }
    }

}