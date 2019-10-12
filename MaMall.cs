using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace MAMall
{
    class MaMall
    {
        public struct Product
        {
            public string name;
            public string id;
            public string desc;
            public string unitPrice;
            public string discount;
            public string discType;
        }
        public struct ProductInvoice
        {
            public string name;
            public string id;
            public string unitPrice;
            public string discount;
        }
        public struct Invoice
        {
            public string id;
            public string order_date;
            public string time;
            public Dictionary< MaMall.ProductInvoice, int> productdict ;
            public string userID;
        }

        public static string execlppy(params string[] array)
        {
            string python = @"C:\Users\pc.cc\AppData\Local\Programs\Python\Python35\python.exe";
            string myPythonApp = @"python\" + array[0] + ".py";
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.CreateNoWindow = true;//true

            myProcessStartInfo.Arguments = myPythonApp;
            for (int i = 1; i < array.Length; i++)
                myProcessStartInfo.Arguments += " " + array[i];

            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();

            StreamReader myStreamReader = myProcess.StandardOutput;
            string output = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myProcess.WaitForExit();
            myProcess.Close();

            return output;

        }//from .py file
        public static string execlpexe(params string[] array)
        {

            string myProcessArguments = "";
            for (int i = 1; i < array.Length; i++)
                myProcessArguments += " " + array[i];


            var myProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"python\"+array[0]+@"\"+array[0]+".exe",
                    Arguments = myProcessArguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };


            myProcess.Start();



            StreamReader myStreamReader = myProcess.StandardOutput;
            string output = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myProcess.WaitForExit();
            myProcess.Close();



            return output;

        }//from .exe file after converting from .py

        
    }
}
