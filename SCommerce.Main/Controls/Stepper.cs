using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace SCommerce.Main.Controls
{
    [TemplatePart(Name = PART_AddButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_SubtractButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_RemoveButton, Type = typeof(Button))]

    public sealed class Stepper : Control
    {
        private const string PART_AddButton = "PART_AddButton";
        private const string PART_SubtractButton = "PART_SubtractButton";
        private const string PART_RemoveButton = "PART_RemoveButton";

        private const string STATE_NORMAL = "Normal";
        private const string STATE_MANY_ITEMS = "ManyItems";

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Stepper), new PropertyMetadata(0, OnValuePropertyChanged));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (Stepper)d;
            self.UpdateVisualState();
        }

        public event RoutedEventHandler Removed;
        public event RoutedEventHandler Added;
        public event RoutedEventHandler Subtracted;

        public Stepper()
        {
            this.DefaultStyleKey = typeof(Stepper);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            BindClickEvents();

            UpdateVisualState();
        }

        private void BindClickEvents()
        {
            if (GetTemplateChild(PART_AddButton) is Button addBtn)
            {
                addBtn.Click += OnAdd;
            }

            if (GetTemplateChild(PART_SubtractButton) is Button subtractBtn)
            {
                subtractBtn.Click += OnSubtract;
            }

            if (GetTemplateChild(PART_RemoveButton) is Button removeBtn)
            {
                removeBtn.Click += OnSubtract;
            }
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            Value++;
            Added?.Invoke(this, new RoutedEventArgs());
        }

        private void OnSubtract(object sender, RoutedEventArgs e)
        {
            Value--;
            Subtracted?.Invoke(this, new RoutedEventArgs());


            if (Value == 0)
            {
                Removed?.Invoke(this, new RoutedEventArgs());
            }
        }

        private void UpdateVisualState()
        {
            var state = (Value <= 1 ? STATE_NORMAL : STATE_MANY_ITEMS);
            VisualStateManager.GoToState(this, state, false);
        }

    }
}
