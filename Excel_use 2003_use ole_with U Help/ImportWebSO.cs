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
        private bool allChk = false;
        private AP_Appliction appl;

        System.Data.DataTable oDT;

        //init set
        public string CardCode = "";
        public string SOColName = "";
        public string ItemNameColName = "";

        public ImportWebSO(AP_Appliction _appl)
        {
            InitializeComponent();
            appl = _appl;
        }
        #region chk
        //chk 
        private bool chkSetting()
        {
            bool ret = true;
            if ((PropertySetting.BigBuyer_CardCode == string.Empty) | (PropertySetting.Monday_CardCode == string.Empty))
                ret = false;

            return ret;
        }
        private bool Chk()
        {
            bool ret = false;
            //chkfld
            ret = chkFld();
            if (ret == false)
            {
                this.appl.MessageBox(@"��ƦC���~�A�Ьd�\�O���� : C:\Log\", MessageType.Warning);
                return ret;
            }
            //chk no this item
            ret = chkItemName();
            if (ret == false) return ret;

            //chk existed so
            if (chkExistedSO())
            { ret = false; return ret; }

            return ret;
        }

        private bool chkExistedSO()
        {
            bool ret = false;
            string soid = "";
            for (int i = 0; i <= this.GV .Rows.Count - 1; i++)
            {
                soid = GV.Rows[i].Cells [SOColName].ToString();
                if (this.existedSO(soid))
                {
                    GV.Rows[i].Cells[i].Value = "�ӭq��w�s�b";
                    appl.SetSystemLog("��" +i +"��"+soid + "�ӭq��w�s�b",MessageType.Warning );
                    ret = true;
                }
            }
            return ret;
        }
        private bool chkItemName()
        {
            bool ret = true;
            string soname = "";
            for (int i = 0; i <= this.GV.Rows.Count - 1; i++)
            {
                soname = GV.Rows[i].Cells [ItemNameColName].Value .ToString();
                if (isExistItemName(soname) == false)
                {
                    appl.SetSystemLog ("�L���ӫ~�W�� : " + soname,MessageType.Warning );
                    GV.Rows[i].Cells[1].Value= "�L���ӫ~�W��";
                    ret = false;
                }
            }
            return ret;
        }
        private bool chkFld()
        {
            bool ret = false;
            if (CardCode == PropertySetting.BigBuyer_CardCode)
            { ret = chkFld_BigBuyer(); }
            else if (CardCode == PropertySetting.Monday_CardCode)
            { ret = chkFld_Monday(); }

            return ret;
        }

        private bool chkFld_BigBuyer()
        {
            bool ret = true;

            if (oDT.Columns.Contains("���f�H") == false) { ret = false; appl.SetSystemLog ("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "���f�H"); }
            if (oDT.Columns.Contains("�p���q��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�p���q��"); }
            if (oDT.Columns.Contains("(��)�p���q��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "���p���q��"); }
            if (oDT.Columns.Contains("��ʹq��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "��ʹq��"); }
            if (oDT.Columns.Contains("�a�}") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�a�}"); }
            if (oDT.Columns.Contains("�q�ʤH") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�q�ʤH"); }
            if (oDT.Columns.Contains("�q�ʤH�q��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�q�ʤH�q��"); }
            if (oDT.Columns.Contains("�q�ʤH��ʹq��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�q�ʤH��ʹq��"); }
            if (oDT.Columns.Contains("����ɶ�") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "����ɶ�"); }
            if (oDT.Columns.Contains("�q��s��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�q��s��"); }
            if (oDT.Columns.Contains("�X�f����") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�X�f����"); }
            if (oDT.Columns.Contains("�ӫ~�W��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�ӫ~�W��"); }
            if (oDT.Columns.Contains("�ӫ~�ƶq") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�ӫ~�ƶq"); }
            if (oDT.Columns.Contains("�ѳf����(���|)") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�ѳf�������|"); }
            if (oDT.Columns.Contains("�q��ӫ~�Ƶ�") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�q��ӫ~�Ƶ�"); }

            return ret;
        }
        private bool chkFld_Monday()
        {
            bool ret = true;
            if (oDT.Columns.Contains("����H�m�W") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "����H�m�W"); }
            if (oDT.Columns.Contains("����H�q��(��)") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "����H�q�ܤ�"); }
            if (oDT.Columns.Contains("����H���") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "����H���"); }
            if (oDT.Columns.Contains("����H�a�}") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "����H�a�}"); }
            if (oDT.Columns.Contains("�q��s��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�q��s��"); }
            if (oDT.Columns.Contains("�ӫ~�W��") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�ӫ~�W��"); }
            if (oDT.Columns.Contains("�ƶq") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�ƶq"); }
            if (oDT.Columns.Contains("�ʪ����Ƶ�") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + "�ʪ����Ƶ�"); }

            //if (oDT.Columns.Contains("") == false) { ret = false; DealError("�нT�{��ƨӷ� : �ʤָ�ƦC - " + ""); }

            return ret;
        }

        private bool isExistItemName(string ItemName)
        {
            bool ret = true;
            if (string.IsNullOrEmpty(this.getItemCode(CardCode, ItemName)))
            {
                ret = false;
            }
            return ret;
        }
        #endregion
        #region event
        private void GV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                if (allChk)
                    for (int i = 0; i < GV.Rows.Count; i++)
                    {
                        GV.Rows[i].Cells[0].Value = false;
                    }
                else
                    for (int i = 0; i < GV.Rows.Count; i++)
                    {
                        GV.Rows[i].Cells[0].Value = true;
                    }
        }
        private void Search()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xls Excel �ɮ�|*.xls|xlsx 2007 Excel �ɮ�|*.xlsx";
            openFileDialog1.Title = "Select a Excel File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextFilePath.Text = openFileDialog1.FileName;
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            BtnSearch.Enabled = false;
            try
            {
                Search();

                appl.StatusBar("�}�l���JEXCEL�ɮ�...", MessageType.None);

                //���JDGV
                string strOrderCmd = " order by " + SOColName;//getOrderCmd();
                func ff = new func();

                 oDT =  loadGridFromExcel(s, strOrderCmd);
                GV.DataSource = oDT;

                appl.StatusBar("EXCEL���J����!!", MessageType.Success);

                if (Chk())
                { BtnOK.Enabled = true; }
                else
                { BtnOK.Enabled = false; }
                appl.StatusBar("�ˬd����!!", MessageType.None);

            }
            catch(Exception ex)
            {
                appl.SetSystemLog(ex.ToString());
            }
            BtnSearch.Enabled=true ;
        }
        #endregion
        #region deal



        private System.Data.DataTable getCurrDT(System.Data.DataTable _oDT)
        {

            System.Data.DataTable ret = _oDT.Copy();
            //string SONO = ret.Rows[0]["�q��s��"].ToString();
            string SONO = ret.Rows[0][SOColName].ToString();

            int i = 1;
            while (i < ret.Rows.Count)
            {
                if (SONO != ret.Rows[i][SOColName].ToString())
                {
                    ret.Rows[i].Delete();
                    ret.AcceptChanges();
                }
                else
                {
                    i = i + 1;
                }
            }

            return ret;
        }

        private void delSRCDT(ref System.Data.DataTable oDT)
        {
            //string SONO = oDT.Rows[0]["�q��s��"].ToString();
            string SONO = oDT.Rows[0][SOColName].ToString();


            int i = 0;
            while (i < oDT.Rows.Count)
            {
                if (SONO == oDT.Rows[i][SOColName].ToString())
                {
                    oDT.Rows[i].Delete();
                    oDT.AcceptChanges();
                }
                else
                {
                    i = i + 1;
                }
            }

        }

        private string getItemCode(string cardcode, string custitemname)
        {
            string ret = "";
            string cmd = "      select ItemCode  from OSCN where CardCode=N'{0}' and U_CustItemName =N'{1}' ";
            cmd = string.Format(cmd, cardcode, custitemname);

            ret = func.DoQuery(cmd, oCompany);
            return ret;
        }
        private bool existedSO(string NumAtCard)
        {
            string cmd = "  select case when COUNT(*) >0 then 1 else 0 end as existed from ORDR where  NumAtCard=N'{0}'  and CardCode=N'{1}'";
            cmd = string.Format(cmd, NumAtCard, CardCode);

            return appl.oSQLServer.ExecuteScalar  == "1";
        }

        #endregion

    }
}