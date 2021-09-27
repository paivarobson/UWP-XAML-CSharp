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
    public sealed class Rating : Control
    {
        private const string STATE_RATING_1 = "Rating1";
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Rating), new PropertyMetadata(1, OnValuePropertyChanged));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (Rating)d;
            self.UpdateRatingState();
        }

        public Rating()
        {
            this.DefaultStyleKey = typeof(Rating);
        }

        private void UpdateRatingState()
        {
            var val = Math.Clamp(Value, 1, 5);
            var state = $"Rating{val}";
            var result = VisualStateManager.GoToState(this, state, false);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateRatingState();
        }
        
    }
}
