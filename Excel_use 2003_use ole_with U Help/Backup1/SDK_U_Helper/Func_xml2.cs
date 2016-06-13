using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

 //ref
//http://www.dotblogs.com.tw/yc421206/archive/2010/08/10/17108.aspx
//XmlDocument

//��:XML�S���ɮ�lock.�i��h�H�s���P�ק�,�y��dirty select and dirty write.
//�`�N
//�p�G�S��save,�|�y���ɮרS������
//1.�h�H�Τ@��AP��,�Y��]�w,�|�ۤ��л\.
//2.��׸�,�n�`�N,�p�G�b�g,�bŪ,�N����AŪ,�A�g.
//�b�Τ��e,�n�`�N�H�W���D


    public class TXML
    {
        private string _FilePath = string.Empty;

        FileStream xmlFile;
        public XmlDocument XD = new XmlDocument();

        public string FilePath
        {
            get
            {
                if (_FilePath == null)
                    return string.Empty;
                else
                    return _FilePath;
            }
            set
            {
                if (_FilePath != value)
                    _FilePath = value;
            }
        }


        /// string context = "<info><db/></info>";
            ///path = System.IO.Path.Combine(path, "option.xml");            
            ///try {oXML = new TXML(path,context);     }catch(Exception ex){messbox.show(ex.message;)}
        public TXML(string path,string context)
        {           
            //set path
            //chk file exist
            //load file and lock file
            _FilePath = path;

            AddFile(context); //�p�G�ɮפ��s�b,�s�W�ɮ�

            //read xml way 1
            //��:�L�klock file
            //XD.Load(_FilePath);


            //read xml way 2
            //�ѨM�L�klock file,�y��dirty select���D
              xmlFile = new FileStream(_FilePath , FileMode.Open,FileAccess.Read, FileShare.Read);//�Q�Υ��F��lock file���ĪG
            XD.Load(xmlFile);
            //Save();
            XD.Save(_FilePath  );//�p�G���HŪ�F,�N�|�����~�T��.�ҥHnew���ɫJ�ntry catch

            
        }

      
     
        //private void addxmlfile()
        //{
        //    XmlDocument XD = new XmlDocument();
        //    XmlElement root = XD.CreateElement("info");
        //    XmlElement nm = XD.CreateElement("db");

        //    root.AppendChild(nm);
        //    XD.AppendChild(root);

        //    XD.Save(_FilePath);
        //}
        private  void AddFile(string xml)
    {
          try
          {
              XD.Load(_FilePath);
          }
            catch (Exception ex )
          {
              XD.LoadXml(xml);
              XD.Save(_FilePath );
            }
    }

        ///oXML.getKeyValue("db", "srcServer"); 
        public  string  getKeyValue(string father,string id)//GetXMLNodeInnerText
        { 
            string ret="";

            father = "//" + father;
            id = "//" + id;

     

            XmlNode node = XD.SelectSingleNode(id);
            if (node != null)
                ret = node.InnerText;

            return ret;
        }
 
        /// SetXMLNodeInnerText("db","srcserver", "love u crazy crazy2");       
        public void setKeyValue(string father, string id, string value)//SetXMLNodeInnerText
        {
            father = "//" + father;
            id = "//" + id;

            XmlElement elmt;
            XmlNode node; 


 

            node = XD.SelectSingleNode(id);
            if (node == null)
            {
                node = XD.SelectSingleNode(father);//get father

                elmt = XD.CreateElement(id.Trim('/'));//add 
                elmt.InnerText = value;

                node.AppendChild(elmt);//link father.
                
            }
            else if     ( node.InnerText != value)
            { 
                node.InnerText = value;
            }
           
        }
        
        public void Save()
        {
            try
            {
                XD.Save(_FilePath);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                func.log(ex.ToString() + Environment.NewLine);
              
            }
        }

        //public bool IsOpen()
        //{
        //    bool ret = false;
        //    try
        //    {
        //        XD.Save(_FilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        ret = true;
        //    }
        //    return ret;
        //}
    }
 
