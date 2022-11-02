using System.Collections.Immutable;
using FrontDeskApp.WinForm.Models;
using FrontDeskApp.WinForm.Services;
using FrontDeskApp.WinForm.Shared;

namespace FrontDeskApp.WinForm;
public partial class Storage : Form
{
	private StorageDto.SearchCriteria SearchCriteria;
	public Storage()
	{
		InitializeComponent();

		SearchCriteria = new StorageDto.SearchCriteria
		{
			LoadChildren = true,
			IsPagingEnabled = true,
			PageSize = 5
		};
	}

	private void Storage_Shown(object sender, EventArgs e)
	{
		GetStorages();
	}

	private void GetStorages()
	{
		Task.Run(async () =>
		{
			// Retrieves the records
			var storageSvc = new StorageService();

			var result = await storageSvc.GetStorages(SearchCriteria);

			// Binds the data
			dataGrd.DataSource = result.Result;

		}).GetAwaiter().GetResult();
	}
}
