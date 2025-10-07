using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using static System.Net.Mime.MediaTypeNames;

namespace Lab5
{
    [Serializable]
    public struct DataBase
    {
        public int accountNumber { get;  }
        public string bankName { get;  }
        public string clientName { get;  }
        public DateTime timeOpen { get;  }
        public byte dividendPercentage { get;  }
        public ClientType clientType { get;  }
        public Currency currency { get;  }
        public int sumMoney { get;  }

        public DataBase(int accountNumber, string bankName, string clientName, DateTime timeOpen, byte dividendPercentage,
            ClientType clientType, Currency currency, int sumMoney)
        {
            this.accountNumber = accountNumber;
            this.bankName = bankName;
            this.clientName = clientName;
            this.timeOpen = timeOpen;
            this.dividendPercentage = dividendPercentage;
            this.clientType = clientType;
            this.currency = currency;
            this.sumMoney = sumMoney;            
        }

        static public bool СheckСorrectBankName(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ\-'\s]+$") && text.Length > 3;
        }

        static public bool СheckСorrectClientName(string text, int length)
        {
            return Regex.IsMatch(text, @"^([a-zA-Z'""\s]+|[а-яА-ЯїЇіІєЄґҐ'""\s]+)$") && text.Length > length;
        }

        static public bool СheckСorrectDividendPercentage(string text, out byte test)
        {
            test = 0;
            return  text.Length > 0 && byte.TryParse(text, out test) && test >= 0 && test <= 100;
        }

        static public bool СheckСorrectSumMoney(string text, out int test)
        {
            test = 0;
            return text.Length > 0 && int.TryParse(text, out test) && test >= 0;
        }



    }

    [Serializable]
    public struct FileStatus {
        public int id { get; set; }
        public int numberСustomers { get; set; }

        public string authorization { get; set; }
    }

    [Serializable]
    public struct SaveData
    {
        public DataBase[] clients { get; set; }
        public FileStatus fileStatus { get; set; }

    }

    internal class @struct
    {
    }
}
