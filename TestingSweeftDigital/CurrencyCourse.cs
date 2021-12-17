using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSweeftDigital
{
    class CurrencyCourse
    {
        public static string[] GetCurrencyTags() 
        {
            return new string[] { "gel", "usd", "eur", "gbp"}; 
        }


        public static double GetCurrencyRateInGel(string currency)
        {
            if (currency.ToLower() == "")
                throw new ArgumentException("Invalid Argument! currency parametre cannit be empty");
            if (currency.ToLower() == "gel")
                throw new ArgumentException("Invalid Argument! Cannot get exchange rate from GEL to GEL");

            try
            {
                string rssUrl = string.Concat("http://www.nbg.ge/rss.php", currency.ToLower() + ".html");

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(rssUrl);

                System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("","http://purl.org/rss/1.0/");
                nsmgr.AddNamespace("", "http://www.cbwiki.net/wiki/index.php/Specification_1.1");

                System.Xml.XmlNodeList nodeList = doc.SelectNodes("//item", nsmgr);

                foreach (System.Xml.XmlNode node in nodeList)
                {
                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.CurrencyDecimalSeparator = ".";

                    try
                    {
                        float exchangeRate = float.Parse(
                                node.SelectSingleNode("//cb:statistics//cb:exchangeRate//cb:value", nsmgr).InnerText,
                                NumberStyles.Any,
                                ci);
                        return exchangeRate;
                    }
                    catch { }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static double ExchangeRate(string from, string to)
        {
            double amount = 1;
            if (from == null || to == null)
                return 0;

            if (from.ToLower() == "gel" && to.ToLower() == "gel")
                return amount;

            try
            {
                double toRate = GetCurrencyRateInGel(to);
                double fromRate = GetCurrencyRateInGel(from);

                if (from.ToLower() == "gel")
                    { return (amount * toRate); }

                else if (to.ToLower() == "gel")
                {
                    return amount / fromRate;
                }
                else
                {
                    return (amount * toRate) / fromRate;
                }
            }
            catch { return 0; }
        }
    }
}
