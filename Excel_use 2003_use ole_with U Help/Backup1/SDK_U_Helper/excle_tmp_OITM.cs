using System;
using System.Collections.Generic;
using System.Text;


namespace SAP_TADC
{
    //�n���[try catch�n�O
    //�n���[debug�n�O
    //����a��i��X���O
    //�n���n��Kdebug�O

    class PART1
    {
        //fld name of table
        public const string lineno = "LineId";
        public const string compoitem = "U_compoitem";
        public const string coponame = "U_coponame";
        public const string copochname = "U_copochname";
        public const string configtype = "U_configtype";
        public const string remark = "U_remark";


        public void OutExcel(string file, SAPbouiCOM.DBDataSource oDS)
        {
            //get data
            //System.Data.DataTable dt = GetDT(oDS);
            CreateFile(file);
            Insert(file, dt);
        }
            
        private void CreateFile(string filePath)
        {
            string CommandText = "�渹 char(255),�t��N�X char(255),[�t��^��W��] char(255),[�t�󤤤�W��] char(255),[���O] char(255),�Ƶ� char(255)";

            CommandText = "CREATE TABLE Sheet1 ( " + CommandText + ")";
      new func_excel_write_ole().DoQery(filePath, CommandText);
        }
        private void Insert(string filePath, System.Data.DataTable dt)
        {
            string vals = "";
            string f1 = "'{0}'";

            string CommandText = "";

            string flds = "�渹,�t��N�X,[�t��^��W��] ,[�t�󤤤�W��] ,[���O] ,�Ƶ�";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                vals = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j != 0)
                        vals += ",";
                    vals += string.Format(f1, dt.Rows[i][j].ToString());
                    //System.Diagnostics.Debug.WriteLine(vals );
                   
                }
                CommandText = "INSERT INTO Sheet1 (" + flds + ") VALUES (" + vals + ")";
                System.Diagnostics.Debug.WriteLine(CommandText );
                new func_excel_write_ole().DoQery(filePath, CommandText);
            }
        }
    }
}

//public void SetMatrixFromXLS(ref SAPbouiCOM.Matrix oMatrix, string s)
//{
//    string sheet = new func_excel_read_ole().getFirstSheetName(s);
//    System.Data.DataTable dt = new func_excel_read_ole().CreateDataSource(s, sheet);
//    for (int i = 0; i < dt.Rows.Count; i++)
//    {
//      System.Diagnostics.  Debug.WriteLine(dt.Rows[i][0].ToString());
//        oMatrix.AddRow(1, oMatrix.RowCount);
//        ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific(0, i + 1)).Value = dt.Rows[i][0].ToString();
//        ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific(1, i + 1)).Value = dt.Rows[i][1].ToString();
//        ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific(2, i + 1)).Value = dt.Rows[i][2].ToString();
//        ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific(3, i + 1)).Value = dt.Rows[i][3].ToString();
//        ((SAPbouiCOM.ComboBox)oMatrix.GetCellSpecific(4, i + 1)).Select(dt.Rows[i][4].ToString(), SAPbouiCOM.BoSearchKey.psk_ByValue);
//        ((SAPbouiCOM.EditText)oMatrix.GetCellSpecific(5, i + 1)).Value = dt.Rows[i][5].ToString();
//    }
//}       



//private System.Data.DataTable GetDT(SAPbouiCOM.DBDataSource srcDS)
//{
//    //add col
//    System.Data.DataTable dt = new System.Data.DataTable();
//    dt.Columns.Add();
//    dt.Columns.Add();
//    dt.Columns.Add();

//    dt.Columns.Add();
//    dt.Columns.Add();
//    dt.Columns.Add();

//    //dt.Columns.Add("�渹");
//    //dt.Columns.Add("�t��N�X");
//    //dt.Columns.Add("�t��W��(�^��^");
//    //dt.Columns.Add("�t��W��(����^");
//    //dt.Columns.Add("���O(1.���n/2.�ﶵ)");
//    //dt.Columns.Add("�Ƶ�");

//    //add row
//    for (int i =0 ; i < srcDS.Size; i++)
//    {
//        System.Data.DataRow row = dt.NewRow();
//        //add cell
//        row[0] = srcDS.GetValue(PART1.lineno, i).Trim();
//        row[1] = srcDS.GetValue(PART1.compoitem, i).Trim();
//        row[2] = srcDS.GetValue(PART1.copochname, i).Trim();
//        row[3] = srcDS.GetValue(PART1.coponame, i).Trim();
//        row[4] = srcDS.GetValue(PART1.configtype, i).Trim();
//        row[5] = srcDS.GetValue(PART1.remark, i).Trim();

//        string tmp ="{0},{1},{2},{3},{4},{5}";
//        tmp = string.Format(tmp,row[0],row[1],row[2],row[3],row[4],row[5]);
//        System.Diagnostics.Debug.WriteLine (tmp);
//        dt.Rows.Add(row);
//    }
//    return dt;

//}
//SAPbouiCOM.DBDataSource oDS = Form.DataSources.DBDataSources.Item("@PART1"); 
//       PART1 sub = new PART1();
//sub.OutExcel(oDS);