using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ShelterInzynierka.Models.DB
{
    public partial class Volunteer : IDataErrorInfo, INotifyPropertyChanged
    {
        public Volunteer()
        {
            Adoption = new HashSet<Adoption>();
        }
      

        public int IdVolunteer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Adoption> Adoption { get; set; }

        #region IdataErrorInfo
        public string Error
        {
            get
            {
                return null;
            }
        }


        public string this[string propertyName]
        {
            get
            {
                string result = String.Empty;
                switch (propertyName)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Podanie imienia jest wymagane!";
                        break;

                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname))
                            result = "Podanie nazwiska jest wymagane!";
                        break;

                }
                return result;
            }
        }
        #endregion

        #region Validation
        static readonly string[] ValidatedProperties =
        {
            "Name"
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }
        string GetValidationError(String propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "Name":
                    error = ValidateName();
                    break;
            }

            return error;
        }
        private string ValidateName()
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                return "Imię wolontariusza nie może być puste!";
            }
            return null;
        }
        #endregion
    }
}
