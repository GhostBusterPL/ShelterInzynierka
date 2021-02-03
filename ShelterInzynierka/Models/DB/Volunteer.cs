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
        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }


        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
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
