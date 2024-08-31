using CombatPad.Models.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.JoshSmith.Controls;

namespace CombatPad.Components
{
    public class MyDragCanvas : DragCanvas
    {
        public MyDragCanvas()
        {

        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(MyDragCanvas), new PropertyMetadata(null));

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if(ElementBeingDragged is ContentPresenter presenter)
            {
                SelectedItem = presenter.DataContext;
            }
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            if(ElementBeingDragged is not null && this.IsDragInProgress)
            {
                if(SelectedItem is IDraggable draggable)
                {
                    draggable.Left = GetLeft(ElementBeingDragged);
                    draggable.Top = GetTop(ElementBeingDragged);
                }
            }
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            if (visualAdded is ContentPresenter presenter) 
            {
                SelectedItem = presenter.DataContext;

                if(SelectedItem is IDraggable draggable)
                {
                    SetLeft(presenter, draggable.Left);
                    SetTop(presenter, draggable.Top);
                }
            }
        }
    }
}
