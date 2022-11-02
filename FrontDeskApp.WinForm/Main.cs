using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontDeskApp.WinForm;
public partial class Main : Form
{
	public string Token { get; private set; }

	public Main()
	{
		InitializeComponent();
	}

	public void EnableMenu(
		string token)
	{
		//mainMenu.Enabled = true;
		Token = token;
	}

	private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!IsOpen("Transaction"))
		{

			var form = new Transaction();
			form.MdiParent = this;
			form.Show();

		}
	}

	private void storageToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!IsOpen("Storage"))
		{

			var form = new Storage();
			form.MdiParent = this;
			form.Show();

		}
	}

	private void customerToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!IsOpen("Customer"))
		{

			var form = new Customer();
			form.MdiParent = this;
			form.Show();

		}
	}

	private bool IsOpen(
		string formName)
	{
		var isOpen = false;
		foreach (Form f in Application.OpenForms)
		{

			if (f.Text.Equals(formName))
			{

				isOpen = true;
				f.Focus();
				break;

			}
		}

		return isOpen;
	}

	private void Main_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.Exit();
	}

	private void Main_Load(object sender, EventArgs e)
	{
		var login = new Login();
		login.MdiParent = this;

		login.ShowDialog();
	}

	private void Main_Shown(object sender, EventArgs e)
	{
		var login = new Login();
		login.MdiParent = this;
		login.Show();
	}
}
