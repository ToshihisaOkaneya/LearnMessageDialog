using System;
using System.Diagnostics;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LearnMessageDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ShowMessageDialog_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog("MessageDialog content", "Title").ShowAsync();
        }

        private async void ShowContentDialog_Click(object sender, RoutedEventArgs e)
        {
            var contentDialog = new ContentDialog
            {
                Title             = "Title",
                Content           = "ContentDialog content",
                PrimaryButtonText = "PrimaryButtonText"
            };
            await contentDialog.ShowAsync();
        }

        private async void ShowMessageDialogWithQuestion_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog =  new MessageDialog("Answer yes or no.", "Question");
            messageDialog.Commands.Add(new UICommand("Yes"));
            messageDialog.Commands.Add(new UICommand("No"));
            var response = await messageDialog.ShowAsync();
            if (response.Label == "Yes")
            {
                Debug.WriteLine("Answer is yes.");
            }
            else if (response.Label == "No")
            {
                Debug.WriteLine("Answer is no.");
            }
        }

        private async void ShowContentDialogWithQuestion_Click(object sender, RoutedEventArgs e)
        {
            var contentDialog = new ContentDialog
            {
                Title               = "Title",
                Content             = "Answer yes or no.",
                PrimaryButtonText   = "Yes",
                SecondaryButtonText = "No",
            };
            var response = await contentDialog.ShowAsync();
            if (response == ContentDialogResult.Primary)
            {
                Debug.WriteLine("Answer is yes.");
            }
            else if (response == ContentDialogResult.Secondary)
            {
                Debug.WriteLine("Answer is no.");
            }
        }
    }
}
