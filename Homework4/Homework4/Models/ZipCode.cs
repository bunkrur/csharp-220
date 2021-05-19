using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Homework4
{
    class ZipCode : IDataErrorInfo, INotifyPropertyChanged
    {
        private string zip = string.Empty;
        private string zipError;

        public string Zip
        {
            get { return zip; }
            set { if (zip != value)
                {
                    zip = value;
                    OnPropertyChanged("ZipCode");
                }
                    
                        }
        }
        public string Error
        {
            get
            {
                return ZipCodeError;
            }
        }

        public string ZipCodeError
        {
            get { return zipError; }
            private set { zipError = value; }
        }

        readonly string usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        readonly string caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        private bool IsUSOrCanadianZipCode(string zipCode)
        {
            var validZipCode = true;
            if ((!Regex.Match(zipCode, usZipRegEx).Success) && (!Regex.Match(zipCode, caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }



        public bool ValidZipCode
        {
            get
            {
                return IsUSOrCanadianZipCode(Zip.ToUpper());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string this[string columnName] => IsUSOrCanadianZipCode(Zip.ToUpper()).ToString();
    }
}
