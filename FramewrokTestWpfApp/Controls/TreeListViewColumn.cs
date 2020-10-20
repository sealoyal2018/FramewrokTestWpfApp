using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FramewrokTestWpfApp.Controls
{
    public class TreeListViewColumn : GridViewColumn
    {
        public string Field { get; set; }
    }
}