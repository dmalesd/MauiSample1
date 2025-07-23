using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace MauiApp2.Controls
{
    public partial class RoundedEntry : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text), typeof(string), typeof(RoundedEntry), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder), typeof(string), typeof(RoundedEntry), default(string));

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor), typeof(Color), typeof(RoundedEntry), Colors.Gray);

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius), typeof(float), typeof(RoundedEntry), 10.0f);

        public static readonly new BindableProperty BackgroundColorProperty = BindableProperty.Create(
            nameof(BackgroundColor), typeof(Color), typeof(RoundedEntry), Colors.Transparent);

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
            nameof(IsPassword), typeof(bool), typeof(RoundedEntry), false);

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
            nameof(Keyboard), typeof(Keyboard), typeof(RoundedEntry), Keyboard.Default);

        public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(
            nameof(TextChangedCommand), typeof(ICommand), typeof(RoundedEntry), null);

        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
            nameof(IsReadOnly), typeof(bool), typeof(RoundedEntry), false);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public ICommand TextChangedCommand
        {
            get => (ICommand)GetValue(TextChangedCommandProperty);
            set => SetValue(TextChangedCommandProperty, value);
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public RoundedEntry()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangedCommand?.Execute(e.NewTextValue);
        }

        // Method to focus the entry field
        public new void Focus()
        {
            EntryField.Focus();
        }

        // Method to unfocus the entry field
        public new void Unfocus()
        {
            EntryField.Unfocus();
        }
    }
}