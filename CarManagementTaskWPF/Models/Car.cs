using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarManagementTaskWPF.Models;

public class Car : INotifyPropertyChanged
{
	private string? vendor;
	private string? model;
	private string? year;

	public string? Vendor
	{
		get { return vendor; }
		set
		{
			vendor = value;
			OnPropertyChanged();
		}
	}
	public string? Model
	{
		get { return model; }
		set
		{
			model = value;
			OnPropertyChanged();
		}
	}
	public string? Year
	{
		get { return year; }
		set
		{
			year = value;
			OnPropertyChanged();
		}
	}


	#region NotifyPropertyChanged

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string name = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	#endregion
}

