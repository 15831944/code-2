using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Panbor_ImportWebSO
{
    public partial class ImportWebSO : Form
    {
        private bool allChk = false;//�ثe�ȵL�ϥ�.2011.11.15
 

        System.Data.DataTable oDT;
      
        //for init set 

        int RetVal = 0;
        int ErrCode = 0;
        string ErrMsg = null;
 

        public ImportWebSO( )
        {
            InitializeComponent();
          
            cbBPName.SelectedIndex = 0;
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
        public System.Data.DataTable loadGridFromExcel(string sFileName, string orderCmd)
        {
            System.Data.DataTable ret;
            func_excel_read_ole f = new func_excel_read_ole();
            string sheetName = f.getFirstSheetName(sFileName);
            ret = f.CreateDataSource(sFileName, sheetName);

            return ret;
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


      �@
 


   
 


 




    }
}