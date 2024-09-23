using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CombatPad.Components
{
    public class EditableTextBlockAdorner : Adorner
    {
        private readonly VisualCollection _visuals;
        private readonly TextBlock _textBlock;
        private readonly TextBox _textBox;

        public EditableTextBlockAdorner(EditableTextBlock element) : base(element)
        {
            _visuals = new(this);
            _textBox = new();
            _textBlock = element;

            var binding = new Binding("Text") { Source = element };

            _textBox.SetBinding(TextBox.TextProperty, binding);
            _textBox.AcceptsReturn = true;
            _textBox.MaxLength = element.MaxLength;
            _textBox.KeyUp += (o, e) => {
                _textBox.Text = _textBox.Text.Replace("\r\n", string.Empty);
                var expresssion = _textBox.GetBindingExpression(TextBox.TextProperty);
                expresssion?.UpdateSource();
            };
            _visuals.Add(_textBox);
        }

        protected override Visual GetVisualChild(int index) => _visuals[index];
        protected override int VisualChildrenCount => _visuals.Count;
        protected override Size ArrangeOverride(Size finalSize)
        {
            _textBox.Arrange(new Rect(0, 0, _textBlock.DesiredSize.Width + 50, _textBlock.DesiredSize.Height + 1.5));
            _textBox.Focus();

            return finalSize;
        }
        protected override void OnRender(DrawingContext drawingContext) => drawingContext.DrawRectangle(null, new Pen { Brush = Brushes.Gold, Thickness = 2 },
                new Rect(0, 0, _textBlock.DesiredSize.Width + 50, _textBlock.DesiredSize.Height + 1.5));

        public event RoutedEventHandler TextBoxLostFocus
        {
            add => _textBox.LostFocus += value;
            remove => _textBox.LostFocus -= value;
        }

        public event KeyEventHandler TextBoxKeyUp
        {
            add => _textBox.KeyUp += value;
            remove => _textBox.KeyUp -= value;
        }
    }
}
