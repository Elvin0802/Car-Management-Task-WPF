using CarManagementTaskWPF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CarManagementTaskWPF.Views;

public partial class CarView : Window
{
	public string? OperationBtn { get; set; }

	#region NotifyPropertyChanged

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	#endregion

	private Car? car;
	public Car? Car
	{
		get { return car; }
		set
		{
			car = value;
			OnPropertyChanged();
		}
	}


	public CarView()
	{
		InitializeComponent();

		DataContext = this;
	}
	
	private void Cancel_Button(object sender, RoutedEventArgs e)
	{
		DialogResult = false;
	}

	private void Operation_Button(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(m.Text) || string.IsNullOrEmpty(v.Text) || y.Text.Length < 4)
		{
			MessageBox.Show("Parameters is null", "Operation", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
		}

		var text = (sender as Button)?.Content.ToString();

		if (text?.First() == 'U')
		{
			Car!.Model = m.Text;
			Car.Vendor = v.Text;
			Car.Year = y.Text;
		}
		else if (text?.First() == 'A')
		{
			Car!.Model = m.Text;
			Car.Vendor = v.Text;
			Car.Year = y.Text;
		}
		else { return; }

		DialogResult = true;
	}
}
