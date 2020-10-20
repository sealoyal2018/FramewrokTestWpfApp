using Caliburn.Micro;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

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

        public double ItemHeight {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(TreeListView), new PropertyMetadata(30.00));

        public GridViewColumnCollection Columns {
            get { return (GridViewColumnCollection)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(GridViewColumnCollection), typeof(TreeListView), new PropertyMetadata(null));

        public TreeListViewColumnCollection ViewColumns {
            get { return (TreeListViewColumnCollection)GetValue(ViewColumnsProperty); }
            set { SetValue(ViewColumnsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewColumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewColumnsProperty =
            DependencyProperty.Register("ViewColumns", typeof(TreeListViewColumnCollection), typeof(TreeListView), new PropertyMetadata(null, new PropertyChangedCallback(OnColumnHeandersChange)));

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue) {
            //CollectionView cv = CollectionViewSource.GetDefaultView(this.ItemsSource) as CollectionView;

            //var jobTitleSort = new System.ComponentModel.SortDescription("JobTitle", System.ComponentModel.ListSortDirection.Ascending);
            //cv.SortDescriptions.Add(jobTitleSort);
            base.OnItemsSourceChanged(oldValue, newValue);
        }

        private static void OnColumnHeandersChange(DependencyObject obj, DependencyPropertyChangedEventArgs e) {
            var newValue = e.NewValue as TreeListViewColumnCollection;
            var value = newValue.FirstOrDefault();
            if (value is null)
                return;

            #region 模版生成

            #region toggle button

            var dockpanel = new FrameworkElementFactory(typeof(DockPanel));
            dockpanel.SetValue(DockPanel.LastChildFillProperty, true);

            var toggleButton = new FrameworkElementFactory(typeof(ToggleButton));
            toggleButton.Name = "Expander";
            toggleButton.SetValue(ToggleButton.ClickModeProperty, ClickMode.Press);

            Binding marginBinding = new Binding();
            var relativeSourece = new RelativeSource();
            relativeSourece.AncestorType = typeof(TreeListViewItem);
            marginBinding.RelativeSource = relativeSourece;
            marginBinding.Path = new PropertyPath("Level");
            marginBinding.Converter = new Converters.LevelToIndentConverter();
            toggleButton.SetBinding(ToggleButton.MarginProperty, marginBinding);

            var isCheckBinding = new Binding();
            isCheckBinding.RelativeSource = relativeSourece;
            isCheckBinding.Path = new PropertyPath("IsExpanded");
            toggleButton.SetBinding(ToggleButton.IsCheckedProperty, isCheckBinding);

            Style expandCollapseToggleStyle = new Style();
            expandCollapseToggleStyle.Setters.Add(new Setter(ToggleButton.WidthProperty, 19.00));
            expandCollapseToggleStyle.Setters.Add(new Setter(ToggleButton.HeightProperty, 13.00));
            expandCollapseToggleStyle.Setters.Add(new Setter(ToggleButton.FocusableProperty, false));

            var toggleButtonTemplate = new ControlTemplate();

            #region the template style and trigger of the toggle button

            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.WidthProperty, 19.00);
            border.SetValue(Border.HeightProperty, 13.00);
            border.SetValue(Border.BackgroundProperty, Brushes.Transparent);
            var innerborder = new FrameworkElementFactory(typeof(Border));
            innerborder.SetValue(Border.WidthProperty, 9.00);
            innerborder.SetValue(Border.HeightProperty, 9.00);
            innerborder.SetValue(Border.BorderBrushProperty, new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7898B5")));
            innerborder.SetValue(Border.BorderThicknessProperty, new Thickness(1));
            innerborder.SetValue(Border.CornerRadiusProperty, new CornerRadius(1));
            innerborder.SetValue(Border.SnapsToDevicePixelsProperty, true);

            var linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new Point(0, 0);
            linearGradientBrush.EndPoint = new Point(1, 1);
            var gradientStops = new GradientStopCollection();
            gradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFFFFFFF"), 0.2));
            gradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFC0B7A6"), 1));
            linearGradientBrush.GradientStops = gradientStops;
            innerborder.SetValue(Border.BackgroundProperty, linearGradientBrush);

            var path = new FrameworkElementFactory(typeof(Path));
            path.Name = "ExpandPath";
            path.SetValue(Path.NameProperty, "ExpandPath");
            path.SetValue(Path.MarginProperty, new Thickness(1));
            string sData = "M 0 2 L 0 3 L 2 3 L 2 5 L 3 5 L 3 3 L 5 3 L 5 2 L 3 2 L 3 0 L 2 0 L 2 2 Z";
            path.SetValue(Path.DataProperty, TypeDescriptor.GetConverter(typeof(Geometry)).ConvertFrom(sData) as Geometry);
            path.SetValue(Path.FillProperty, Brushes.Black);
            innerborder.AppendChild(path);
            border.AppendChild(innerborder);

            toggleButtonTemplate.VisualTree = border;

            Trigger isCheckedTrigger = new Trigger();
            isCheckedTrigger.Property = ToggleButton.IsCheckedProperty;
            isCheckedTrigger.Value = true;
            var sTriggerData = "M 0 2 L 0 3 L 5 3 L 5 2 Z";
            isCheckedTrigger.Setters.Add(new Setter() { TargetName = "ExpandPath", Property = Path.DataProperty, Value = TypeDescriptor.GetConverter(typeof(Geometry)).ConvertFrom(sTriggerData) as Geometry });
            toggleButtonTemplate.Triggers.Add(isCheckedTrigger);

            #endregion the template style and trigger of the toggle button

            expandCollapseToggleStyle.Setters.Add(new Setter(ToggleButton.TemplateProperty, toggleButtonTemplate));

            toggleButton.SetValue(StyleProperty, expandCollapseToggleStyle);

            toggleButton.SetValue(DockPanel.DockProperty, Dock.Left);
            dockpanel.AppendChild(toggleButton);

            #endregion toggle button

            var block = new FrameworkElementFactory(typeof(TextBlock));
            var textBinding = new Binding();
            textBinding.Path = new PropertyPath(value.Field);
            block.SetBinding(TextBlock.TextProperty, textBinding);
            block.SetBinding(TextBlock.ToolTipProperty, textBinding);
            block.SetValue(TextBlock.TextTrimmingProperty, TextTrimming.CharacterEllipsis);
            dockpanel.AppendChild(block);

            var dataTemplate = new DataTemplate {
                VisualTree = dockpanel,
            };

            var hiddenTrigger = new DataTrigger();

            Binding itemBinding = new Binding();
            itemBinding.Path = new PropertyPath("HasItems");
            itemBinding.RelativeSource = relativeSourece;

            hiddenTrigger.Binding = itemBinding;
            hiddenTrigger.Value = false;
            hiddenTrigger.Setters.Add(new Setter(ToggleButton.VisibilityProperty, Visibility.Hidden, "Expander"));

            dataTemplate.Triggers.Add(hiddenTrigger);

            #endregion 模版生成

            var columns = new GridViewColumnCollection();
            foreach (var item in newValue) {
                var col = new GridViewColumn() {
                    Header = item.Header,
                };
                if (item.Field == value.Field) {
                    col.CellTemplate = dataTemplate;
                    columns.Add(col);
                    continue;
                }
                col.DisplayMemberBinding = new Binding() {
                    Path = new PropertyPath(item.Field)
                };
                columns.Add(col);
            }

            (obj as TreeListView).Columns = columns;
        }

        public FrameworkElementFactory GeneralEdiable(string field) {
            var grid = new FrameworkElementFactory(typeof(Grid));

            var block = new FrameworkElementFactory(typeof(TextBlock));
            var textBinding = new Binding();
            textBinding.Path = new PropertyPath(field);
            block.SetBinding(TextBlock.TextProperty, textBinding);

            grid.AppendChild(block);

            var textBox = new FrameworkElementFactory(typeof(TextBox));
            textBox.SetValue(TextBox.VisibilityProperty, Visibility.Collapsed);
            textBox.SetValue(TextBox.TextProperty, textBinding);
            grid.AppendChild(textBox);

            var trigger = new Trigger();

            return grid;
        }
    }
}