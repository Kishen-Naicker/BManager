using System.Threading.Tasks;
using System.Windows;

namespace BudgetManager.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Window
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            //sets the progress bar and textblock to visible
            progressBar.Visibility = Visibility.Visible;
            progressTb.Visibility = Visibility.Visible;

            //add a thread
            Task.Factory.StartNew(() =>
            {
                //3 seconds sleep --> works together with progressbar duration
                System.Threading.Thread.Sleep(3000);

                //since im not using a UI thread
                //use a dispathcher
                this.Dispatcher.Invoke(() =>
                {
                    //closes the current view and opens the option view window
                    OptionView optionView = new OptionView();
                    this.Close();
                    optionView.Show();

                });

            });
        }

        private void DeclineBtn_Click(object sender, RoutedEventArgs e)
        {
            //message to show if decline button is clicked
            MessageBox.Show("Sorry to say without accepting the term you cannot continue forward to use the budgeting system.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
