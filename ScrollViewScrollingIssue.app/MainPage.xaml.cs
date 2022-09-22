using System.Diagnostics;

namespace ScrollViewScrollingIssue.app;

public partial class MainPage : ContentPage {
	public MainPage() {
		InitializeComponent();

        for (int i = 0; i < 30; i++) {
            scrollViewContent.Children.Add(
                new Label {
                    Text = "Label number " + i,
                    FontSize = 30,
                });
        }
    }

	private void ScrollButtonListener(object sender, EventArgs e) {
        ScrollDown();
    }

    private void AddAndScrollButtonListener(object sender, EventArgs e) {
        scrollViewContent.Children.Add(
                new Label {
                    Text = "Label number " + scrollViewContent.Children.Count,
                    FontSize = 30,
                });

        ScrollDown();
    }

    private async void ScrollDown() {
        int lastChild = scrollViewContent.Children.Count - 1;

        Debug.WriteLine("The last child's index is: " + lastChild);

        if (lastChild >= 0) {
            View lastElement = (View)scrollViewContent.Children[lastChild];

            Debug.WriteLine("The last child's text is: " + ((Label)lastElement).Text);

            await mainScrollView.ScrollToAsync(lastElement, ScrollToPosition.MakeVisible, false);

            showButtonAction.Text = "Scrolled to: Lable number " + lastChild + " ";
            Debug.WriteLine("Scrolled to: Lable number " + lastChild + " ");
        }
    }
}
