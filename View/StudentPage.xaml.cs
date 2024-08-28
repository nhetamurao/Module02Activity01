using Module02Activity01.ViewModel;
namespace Module02Activity01.View;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		InitializeComponent();
		BindingContext = new StudentViewModel();
	}
}