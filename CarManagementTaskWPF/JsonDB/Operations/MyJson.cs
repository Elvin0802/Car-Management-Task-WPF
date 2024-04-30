using CarManagementTaskWPF.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace CarManagementTaskWPF.JsonDB.Operations;

public static class MyJson
{
	public static JsonSerializerOptions op = new JsonSerializerOptions() { WriteIndented = true };
	public static string path = "../../../JsonDB/JsonFiles/cars.json";

	public static bool Write(ObservableCollection<Car>? carList)
	{
		try
		{
			if (carList is not null)
			{
				File.WriteAllText(path, JsonSerializer.Serialize<ObservableCollection<Car>>(carList, op));
				return true;
			}
			else { return false; }
		}
		catch
		{ return false; }
	}

	public static ObservableCollection<Car>? Read()
	{
		var data = File.ReadAllText(path);
		return JsonSerializer.Deserialize<ObservableCollection<Car>>(data);
	}
}
