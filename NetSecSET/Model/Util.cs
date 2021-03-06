﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace NetSecSET.Model
{
    class Util
    {
        public static string m_TAG = "Util";
        public static string m_OIFileName = "OI.txt";
        public static string m_PIFileName = "PI.txt";
        public static string m_CertFileName = "Certificate.txt";

        public static Certificate loadCertificate(string fileName)
        {
            Certificate cert = null;

            if (File.Exists(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(Certificate));
                TextReader tr = new StreamReader(@fileName);
                cert = (Certificate)s.Deserialize(tr);
                Log(m_TAG, "loading Certificate");
                tr.Close();
            }

            return cert;
        }

        public static void saveCertificate(string fileName, Certificate cert)
        {
            XmlSerializer s = new XmlSerializer(typeof(Certificate));
            TextWriter tw = new StreamWriter(@fileName);
            s.Serialize(tw, cert);
            Log(m_TAG, "saving Ceritifcate");
            tw.Close();
        }

        public static OrderInfo loadOI(string fileName)
        {
            OrderInfo OI = null;

            if (File.Exists(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(OrderInfo));
                TextReader tr = new StreamReader(@fileName);
                OI = (OrderInfo)s.Deserialize(tr);
                Log(m_TAG, "loading Order Information");
                tr.Close();
            }

            return OI;
        }

        public static void saveOI(string fileName, OrderInfo OI)
        {
            XmlSerializer s = new XmlSerializer(typeof(OrderInfo));
            TextWriter tw = new StreamWriter(@fileName);
            s.Serialize(tw, OI);
            Log(m_TAG, "saving Order Information");
            tw.Close();
        }

        public static PaymentInfo loadPI(string fileName)
        {
            PaymentInfo PI = null;

            if (File.Exists(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(PaymentInfo));
                TextReader tr = new StreamReader(@fileName);
                PI = (PaymentInfo)s.Deserialize(tr);
                Log(m_TAG, "loading Payment Information");
                tr.Close();
            }

            return PI;
        }

        public static void savePI(string fileName, PaymentInfo PI)
        {
            XmlSerializer s = new XmlSerializer(typeof(PaymentInfo));
            TextWriter tw = new StreamWriter(@fileName);
            s.Serialize(tw, PI);
            Log(m_TAG, "saving Payment Information");
            tw.Close();
        }

        public static void Log(string tag, string msg)
        {
            TextWriter w = File.AppendText("log.txt");
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine(" Tag:{0}", tag);
            w.WriteLine("  :");
            w.WriteLine("  :{0}", msg);
            w.WriteLine("-------------------------------");
        }
    }
}
