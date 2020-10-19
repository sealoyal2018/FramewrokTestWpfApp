using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramewrokTestWpfApp.Models
{
    public class PersonInfo : PropertyChangedBase
    {
        private string fullName;
        private string jobTitle;
        private string country;
        private DateTime birthDate;
        private string phone;
        private int age = 10;
        private BindableCollection<PersonInfo> children;

        public string FullName {
            get {
                return this.fullName;
            }

            set {
                this.fullName = value;
                NotifyOfPropertyChange(nameof(FullName));
            }
        }

        public string JobTitle {
            get {
                return this.jobTitle;
            }

            set {
                this.jobTitle = value;
                NotifyOfPropertyChange(nameof(JobTitle));
            }
        }

        public string Country {
            get {
                return this.country;
            }

            set {
                this.country = value;
                NotifyOfPropertyChange(nameof(Country));
            }
        }

        public DateTime BirthDate {
            get {
                return this.birthDate;
            }

            set {
                this.birthDate = value;
                NotifyOfPropertyChange(nameof(BirthDate));
            }
        }

        public string Phone {
            get {
                return this.phone;
            }

            set {
                this.phone = value;
                NotifyOfPropertyChange(nameof(Phone));
            }
        }

        public BindableCollection<PersonInfo> Children {
            get {
                return this.children;
            }

            set {
                this.children = value;
                NotifyOfPropertyChange(nameof(Children));
            }
        }

        public int Age {
            get {
                return this.age;
            }

            set {
                this.age = value;
                NotifyOfPropertyChange(nameof(Age));
            }
        }
    }
}