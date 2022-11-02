using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontDeskApp.WinForm.Services;
using FrontDeskApp.WinForm.Shared;

namespace FrontDeskApp.WinForm;
public partial class Login : Form
{
	public Login()
	{
		InitializeComponent();
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		Task.Run(async () =>
		{
			var loginSvc = new LoginService();
			var result = await loginSvc.LoginAsync(txtUsername.Text, txtPassword.Text);

			if (result.NoErrors)
			{

				RestApiHelper.AccessToken = result.Dto.Token;
				RestApiHelper.AddAuthenticationToken();
				(this.MdiParent as Main).EnableMenu(result.Dto.Token);

				this.Hide();
				this.Close();

			}

			else
			{
				MessageBox.Show("Error");
			}
		}).GetAwaiter().GetResult();
	}
}
