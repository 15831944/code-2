using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
public class des
{
    //�����O8��
    private static string skey = "33cadmen";
    ///    <summary>
    /// �r��[�K
    /// </summary>
    public static string Encrypt(string pToEncrypt)
    {
        if (pToEncrypt == string.Empty)
            return string.Empty;

        System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
        byte[] inputByteArray = null;
        inputByteArray = System.Text.Encoding.Default.GetBytes(pToEncrypt);
        //'�إߥ[�K��H���K�_�M�����q
        //'���ϥ�ASCIIEncoding.ASCII��k��GetBytes��k
        //'�ϱo��J�K�X������J�^��奻
        des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
        des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
        //'�g�G�i��Ʋը�[�K�y
        //'(�⤺�s�y�������e�����g�J)
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
        //'�g�G�i��Ʋը�[�K�y
        //'(�⤺�s�y�������e�����g�J)
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        //'�إ߿�X�r�Ŧ�
        System.Text.StringBuilder ret = new System.Text.StringBuilder();
        byte b = 0;
        foreach (byte b_loopVariable in ms.ToArray())
        {
            b = b_loopVariable;
            ret.AppendFormat("{0:X2}", b);
        }
        return ret.ToString();
    }


    ///    <summary>
    /// �r��ѱK
    /// </summary>
    public static string Decrypt(string pToDecrypt)
    {
        if (pToDecrypt == string.Empty)
            return string.Empty;

        try
        {
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
            //'��r�Ŧ��Jbyte�Ʋ�
            int len = 0;
            len = pToDecrypt.Length / 2 - 1;
            byte[] inputByteArray = new byte[len + 1];
            int x = 0;
            int i = 0;
            for (x = 0; x <= len; x++)
            {
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16);
                inputByteArray[x] = Convert.ToByte(i);
            }
            //'�إߥ[�K��H���K�_�M�����q�A���ȭ��n�A����ק�
            des.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
            des.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(skey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
