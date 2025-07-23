using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace MauiApp2.Controls
{
    public partial class GradientButton : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text), typeof(string), typeof(GradientButton), default(string));

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), typeof(Color), typeof(GradientButton), Colors.White);

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize), typeof(double), typeof(GradientButton), 16.0);

        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(
            nameof(FontAttributes), typeof(FontAttributes), typeof(GradientButton), FontAttributes.Bold);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command), typeof(ICommand), typeof(GradientButton), null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter), typeof(object), typeof(GradientButton), null);

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius), typeof(float), typeof(GradientButton), 10.0f);

        public static readonly BindableProperty GradientStartColorProperty = BindableProperty.Create(
            nameof(GradientStartColor), typeof(Color), typeof(GradientButton), Colors.DodgerBlue);

        public static readonly BindableProperty GradientEndColorProperty = BindableProperty.Create(
            nameof(GradientEndColor), typeof(Color), typeof(GradientButton), Colors.MediumPurple);

        // Changed default values for gradient direction from (0,0)-(1,1) to (0,0)-(0,1) for top-to-bottom
        public static readonly BindableProperty GradientStartPointProperty = BindableProperty.Create(
            nameof(GradientStartPoint), typeof(Point), typeof(GradientButton), new Point(0, 0));

        public static readonly BindableProperty GradientEndPointProperty = BindableProperty.Create(
            nameof(GradientEndPoint), typeof(Point), typeof(GradientButton), new Point(0, 1));

        public static readonly new BindableProperty PaddingProperty = BindableProperty.Create(
            nameof(Padding), typeof(Thickness), typeof(GradientButton), new Thickness(12, 8));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Color GradientStartColor
        {
            get => (Color)GetValue(GradientStartColorProperty);
            set => SetValue(GradientStartColorProperty, value);
        }

        public Color GradientEndColor
        {
            get => (Color)GetValue(GradientEndColorProperty);
            set => SetValue(GradientEndColorProperty, value);
        }

        public Point GradientStartPoint
        {
            get => (Point)GetValue(GradientStartPointProperty);
            set => SetValue(GradientStartPointProperty, value);
        }

        public Point GradientEndPoint
        {
            get => (Point)GetValue(GradientEndPointProperty);
            set => SetValue(GradientEndPointProperty, value);
        }

        public new Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        // Event for button clicks
        public event EventHandler<EventArgs>? Clicked;

        public GradientButton()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            // Forward the click event
            Clicked?.Invoke(this, e);
        }
    }
}