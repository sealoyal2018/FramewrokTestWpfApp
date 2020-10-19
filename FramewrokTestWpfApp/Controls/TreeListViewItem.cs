using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FramewrokTestWpfApp.Controls
{
    public class TreeListViewItem : TreeViewItem
    {
        // 计算当前节点的深度
        private int level = -1;

        public int Level {
            get {
                if (level == -1) {
                    TreeListViewItem parent = ItemsControl.ItemsControlFromItemContainer(this) as TreeListViewItem;
                    level = (parent != null) ? parent.Level + 1 : 0;
                }
                return level;
            }
        }

        protected override DependencyObject GetContainerForItemOverride() {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item) {
            return item is TreeListViewItem;
        }

        public int ItemHeight {
            get { return (int)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(int), typeof(TreeListViewItem), new PropertyMetadata(30));
    }
}