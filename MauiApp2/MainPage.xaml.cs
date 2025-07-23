namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private Controls.GradientButton? gradientButton1;
        private Controls.GradientButton? gradientButton2;

        public MainPage()
        {
            InitializeComponent();

            // Find our gradient buttons
            //gradientButton1 = this.FindByName<Controls.GradientButton>("GradientButton1");
            //gradientButton2 = this.FindByName<Controls.GradientButton>("GradientButton2");

            // Subscribe to the second gradient button's click event
            //if (gradientButton2 != null)
            //{
            //    gradientButton2.Clicked += OnGradientButton2Clicked;
            //}
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
            {
                CounterBtn.Text = $"Clicked {count} time";
            }
            else
            {
                CounterBtn.Text = $"Clicked {count} times";
            }

            // Update the first gradient button text as well
            if (gradientButton1 != null)
            {
                gradientButton1.Text = $"Clicked {count} times";
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnGradientButton2Clicked(object? sender, EventArgs e)
        {
            if (gradientButton2 == null)
            {
                return;
            }

            // Change the gradient colors when clicked
            if (gradientButton2.GradientStartColor == Color.Parse("#06D6A0"))
            {
                gradientButton2.GradientStartColor = Color.Parse("#FF6B6B");
                gradientButton2.GradientEndColor = Color.Parse("#FFE66D");
                gradientButton2.Text = "Colors Changed!";
            }
            else
            {
                gradientButton2.GradientStartColor = Color.Parse("#06D6A0");
                gradientButton2.GradientEndColor = Color.Parse("#FFD166");
                gradientButton2.Text = "Top-Bottom Gradient 2";
            }
        }
    }
}
