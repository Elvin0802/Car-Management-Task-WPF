using CarManagementTaskWPF.JsonDB.Operations;
using CarManagementTaskWPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CarManagementTaskWPF.Views;

public partial class MainView : Window, INotifyPropertyChanged
{
	#region NotifyPropertyChanged

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	#endregion

	ObservableCollection<Car>? cars;

	public ObservableCollection<Car>? Cars
	{
		get { return cars; }
		set
		{
			cars = value;
			OnPropertyChanged();
		}
	}

	private Car? newCar;
	public Car? NewCar
	{
		get { return newCar; }
		set
		{
			newCar = value;
			OnPropertyChanged();
		}
	}

	public MainView()
	{
		InitializeComponent();

		DataContext = this;

		Cars = new();
		NewCar = new();
	}

	private void Show_Window(string text)
	{
		var win = new CarView();

		win.WindowStartupLocation = WindowStartupLocation.CenterScreen;

		win.OperationBtn = text;

		win.Car = NewCar;

		Hide();

		if ((bool)win.ShowDialog()!)
			if (text.First() == 'A')
				Cars.Add(NewCar);

		NewCar = new();

		Show();
	}

	private void AddNewCar_Button(object sender, RoutedEventArgs e)
	{
		Show_Window("Add New Car");
	}

	private void Cars_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
	{
		NewCar = (sender as ListView).SelectedItem as Car;
		Show_Window("Update Car");
	}

	private void GetCarsFromJsonFile(object sender, RoutedEventArgs e)
	{
		try
		{
			Cars!.Clear();

			Cars = MyJson.Read();

			MessageBox.Show("Cars Loaded.", "Operation", MessageBoxButton.OK, MessageBoxImage.Information);
		}
		catch
		{
			MessageBox.Show("Cars NOT Loaded.", "Operation", MessageBoxButton.OK, MessageBoxImage.Warning);
		}
	}

	private void SaveCarsToJsonFile(object sender, RoutedEventArgs e)
	{
		try
		{
			if (MyJson.Write(Cars))
				MessageBox.Show("Cars Saved.", "Operation", MessageBoxButton.OK, MessageBoxImage.Information);
			else
				MessageBox.Show("Cars NOT Saved.", "Operation", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		catch
		{
			MessageBox.Show("Cars NOT Saved.", "Operation", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}

}
