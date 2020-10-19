using System.Windows;
using System.Windows.Controls;

namespace FramewrokTestWpfApp.Controls
{
    public class TreeListView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride() {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item) {
            return item is TreeListViewItem;
        }

        public GridViewColumnCollection Heanders {
            get { return (GridViewColumnCollection)GetValue(HeandersProperty); }
            set { SetValue(HeandersProperty, value); }
        }

        public static readonly DependencyProperty HeandersProperty =
            DependencyProperty.Register("Heanders", typeof(GridViewColumnCollection), typeof(TreeView), new PropertyMetadata(null));
    }
}