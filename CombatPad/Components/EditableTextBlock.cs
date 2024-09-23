using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace CombatPad.Components
{
    public class EditableTextBlock : TextBlock
    {
        private EditableTextBlockAdorner _adorner = null!;

        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), 
            typeof(EditableTextBlock), new PropertyMetadata(int.MaxValue));

        // Using a DependencyProperty as the backing store for IsInEditMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInEditModeProperty = DependencyProperty.Register("IsInEditMode", typeof(bool), 
            typeof(EditableTextBlock), new UIPropertyMetadata(false, IsInEditModeUpdate));

        private static void IsInEditModeUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is EditableTextBlock tb)
            {
                var layer = AdornerLayer.GetAdornerLayer(tb);

                if (tb.IsInEditMode)
                {
                    tb._adorner ??= new EditableTextBlockAdorner(tb);
                    tb._adorner.TextBoxLostFocus += (o, e) => tb.IsInEditMode = false;
                    tb._adorner.TextBoxKeyUp += (o, e) => {
                        if (e.Key == Key.Enter)
                        {
                            tb.IsInEditMode = false;
                        }
                    };
                    layer.Add(tb._adorner);
                }
                else
                {
                    layer.GetAdorners(tb)?
                        .ToList()
                        .ForEach(x => layer.Remove(x));

                    if (tb.GetBindingExpression(TextProperty) is BindingExpression expr)
                    {
                        expr.UpdateTarget();
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            IsInEditMode = e.MiddleButton == MouseButtonState.Pressed ||
                e.ClickCount == 2;
        }
    }
}
