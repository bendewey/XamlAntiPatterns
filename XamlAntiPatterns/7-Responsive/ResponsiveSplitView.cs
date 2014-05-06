using System.Windows;
using System.Windows.Controls;

namespace XamlAntiPatterns._7_Responsive
{
    [TemplatePart(Name = ScrollViewerPartName, Type = typeof(ScrollViewer))]
    [TemplatePart(Name = SecondColumnPartName, Type = typeof(ColumnDefinition))]
    [TemplatePart(Name = LeftContentPartName, Type = typeof(ContentControl))]
    [TemplatePart(Name = RightContentPartName, Type = typeof(ContentControl))]
    public class ResponsiveSplitView : Control
    {
        private const string ScrollViewerPartName = "PART_ScrollViewer";
        private const string SecondColumnPartName = "PART_SecondColumnDefinition";
        private const string LeftContentPartName = "PART_LeftContent";
        private const string RightContentPartName = "PART_RightContent";

        private ScrollViewer _scrollViewer;
        private ColumnDefinition _secondColumnDefinition;
        private ContentControl _leftContent;
        private ContentControl _rightContent;

        public ResponsiveSplitView()
        {
            DefaultStyleKey = typeof (ResponsiveSplitView);
        }

        public object LeftContent
        {
            get { return (object)GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }

        public static readonly DependencyProperty LeftContentProperty =
            DependencyProperty.Register("LeftContent", typeof(object), typeof(ResponsiveSplitView), new PropertyMetadata(null));

        public object RightContent
        {
            get { return (object)GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }

        public static readonly DependencyProperty RightContentProperty =
            DependencyProperty.Register("RightContent", typeof(object), typeof(ResponsiveSplitView), new PropertyMetadata(null));

        public SplitMode SplitMode
        {
            get { return (SplitMode)GetValue(SplitModeProperty); }
            set { SetValue(SplitModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SplitMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SplitModeProperty =
            DependencyProperty.Register("SplitMode", typeof(SplitMode), typeof(ResponsiveSplitView), new PropertyMetadata(SplitMode.LeftRight));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _scrollViewer = GetTemplateChild(ScrollViewerPartName) as ScrollViewer;
            _secondColumnDefinition = GetTemplateChild(SecondColumnPartName) as ColumnDefinition;
            _leftContent = GetTemplateChild(LeftContentPartName) as ContentControl;
            _rightContent = GetTemplateChild(RightContentPartName) as ContentControl;

            UpdateView();
        }

        public bool IsValidTemplate()
        {
            return _scrollViewer != null
                   && _secondColumnDefinition != null
                   && _leftContent != null
                   && _rightContent != null;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (sizeInfo.NewSize.Width < 768 && SplitMode == SplitMode.LeftRight)
            {
                SplitMode = SplitMode.TopBottom;
                UpdateView();
            }
            else if (sizeInfo.NewSize.Width >= 768 && SplitMode == SplitMode.TopBottom)
            {
                SplitMode = SplitMode.LeftRight;
                UpdateView();
            }
        }

        public void UpdateView()
        {
            if (!IsValidTemplate()) return;

            if (SplitMode == SplitMode.LeftRight)
            {
                _secondColumnDefinition.Width = new GridLength(1, GridUnitType.Star);
                Grid.SetRow(_rightContent, 0);
                Grid.SetColumn(_rightContent, 1);
            }
            else // TopBottom
            {
                _secondColumnDefinition.Width = new GridLength(0, GridUnitType.Auto);
                Grid.SetRow(_rightContent, 1);
                Grid.SetColumn(_rightContent, 0);
            }
        }
    }

    public enum SplitMode
    {
        LeftRight,
        TopBottom
    }
}
