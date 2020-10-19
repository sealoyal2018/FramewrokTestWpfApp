using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramewrokTestWpfApp.Models
{
    public class Staff : PropertyChangedBase
    {
        private string _Name;
        private int _Age;
        private string _Sex;
        private string _Duty;
        private bool _IsSelected;
        private bool _IsExpanded;

        private ObservableCollection<Staff> _StaffList = new ObservableCollection<Staff>();

        public ObservableCollection<Staff> StaffList {
            get { return _StaffList; }

            set {
                _StaffList = value;
                NotifyOfPropertyChange(nameof(StaffList));
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name {
            get { return _Name; }

            set {
                _Name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age {
            get { return _Age; }

            set {
                _Age = value;
                NotifyOfPropertyChange(nameof(Age));
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex {
            get { return _Sex; }

            set {
                _Sex = value;
                NotifyOfPropertyChange(nameof(Sex));
            }
        }

        /// <summary>
        /// 职务
        /// </summary>
        public string Duty {
            get { return _Duty; }

            set {
                _Duty = value;
                NotifyOfPropertyChange(nameof(Duty));
            }
        }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected {
            get { return _IsSelected; }

            set {
                _IsSelected = value;
                NotifyOfPropertyChange(nameof(IsSelected));
            }
        }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsExpanded {
            get { return _IsExpanded; }

            set {
                _IsExpanded = value;
                NotifyOfPropertyChange(nameof(IsExpanded));
            }
        }

        public Staff() {
            IsSelected = false;
            IsExpanded = false;
        }
    }
}