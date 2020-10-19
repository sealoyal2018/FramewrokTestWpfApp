using Caliburn.Micro;
using FramewrokTestWpfApp.Interfaces;
using FramewrokTestWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FramewrokTestWpfApp.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        public BindableCollection<PersonInfo> Items {
            get {
                return this.items;
            }

            set {
                this.items = value;
            }
        }

        private BindableCollection<PersonInfo> items;

        private ObservableCollection<Staff> _StaffList = new ObservableCollection<Staff>();

        public ObservableCollection<Staff> StaffList {
            get { return _StaffList; }

            set {
                _StaffList = value;
                this.NotifyOfPropertyChange(nameof(StaffList));
            }
        }

        public ShellViewModel() {

            #region test

            Items = new BindableCollection<PersonInfo>() {
                new PersonInfo{
                    FullName = "Bruce Cambell",
                    JobTitle = "Chief Executive Officer",
                    Country = "Japan",
                    BirthDate = new DateTime(1957, 9, 6),
                    Phone = "(417)166-3268",
                    Children = new BindableCollection<PersonInfo>() {
                        new PersonInfo {
                            FullName = "Cindy Haneline",
                            JobTitle = "Information Services Manager",
                            Country = "Singapore",
                            BirthDate = new DateTime(1973, 12, 23),
                            Phone = "(918)161-3649",
                            Children = null,
                        },
                        new PersonInfo {
                            FullName = "Carolyn Baker",
                            JobTitle = "Marketing Manager",
                            Country = "Hungary",
                            BirthDate = new DateTime(1978, 3, 23),
                            Phone = "(209)125-4334",
                            Children = new BindableCollection<PersonInfo>() {
                                new PersonInfo {
                                    FullName = "Anthony Rounds",
                                    JobTitle = "Marketing Specialist",
                                    Country = "Germany",
                                    BirthDate = new DateTime(1973, 1 ,4),
                                    Phone = "(559)453-3698",
                                    Children = null,
                                },
                                new PersonInfo {
                                    FullName = "Anthony Peterson",
                                    JobTitle = "Marketing Specialist",
                                    Country = "Germany",
                                    BirthDate = new DateTime(1971, 1, 4),
                                    Phone="(559)224-4648",
                                    Children = null,
                                },
                            }
                        }
                    }
                },
                new PersonInfo {
                    FullName = "Allison Etter",
                    JobTitle = "Research and Development Manager"
                    , Country = "United States",
                    BirthDate = new DateTime(1982, 2, 10),
                    Phone = "(703)826-9719",
                    Children = null,
                }
            };

            #endregion test

#if false

            #region sample

            Staff staff = new Staff() {
                Name = "张三",
                Age = 30,
                Sex = "男",
                Duty = "经理",
                IsExpanded = true
            };
            Staff staff2 = new Staff() {
                Name = "张三1",
                Age = 21,
                Sex = "男",
                Duty = "员工",
                IsExpanded = true
            };
            Staff staff3 = new Staff() {
                Name = "张三11",
                Age = 21,
                Sex = "男",
                Duty = "员工"
            };
            staff2.StaffList.Add(staff3);
            staff3 = new Staff() {
                Name = "张三22",
                Age = 21,
                Sex = "女",
                Duty = "员工"
            };
            staff2.StaffList.Add(staff3);
            staff.StaffList.Add(staff2);
            staff2 = new Staff() {
                Name = "张三2",
                Age = 22,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff() {
                Name = "张三3",
                Age = 23,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            StaffList.Add(staff);

            staff = new Staff() {
                Name = "李四",
                Age = 31,
                Sex = "男",
                Duty = "副经理"
            };
            staff2 = new Staff() {
                Name = "李四1",
                Age = 24,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff() {
                Name = "李四2",
                Age = 25,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff() {
                Name = "李四3",
                Age = 26,
                Sex = "男",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            StaffList.Add(staff);

            staff = new Staff() {
                Name = "王五",
                Age = 32,
                Sex = "女",
                Duty = "组长"
            };
            staff2 = new Staff() {
                Name = "王五1",
                Age = 27,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            staff2 = new Staff() {
                Name = "王五2",
                Age = 28,
                Sex = "女",
                Duty = "员工"
            };
            staff.StaffList.Add(staff2);
            StaffList.Add(staff);

            #endregion sample

#endif
        }
    }
}