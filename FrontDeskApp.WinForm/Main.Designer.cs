namespace FrontDeskApp.WinForm;

partial class Main
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.transactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.storageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionToolStripMenuItem,
            this.storageToolStripMenuItem,
            this.customerToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(1215, 25);
			this.mainMenu.TabIndex = 0;
			this.mainMenu.Text = "menuStrip1";
			// 
			// transactionToolStripMenuItem
			// 
			this.transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
			this.transactionToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
			this.transactionToolStripMenuItem.Text = "Transaction";
			this.transactionToolStripMenuItem.Click += new System.EventHandler(this.transactionToolStripMenuItem_Click);
			// 
			// storageToolStripMenuItem
			// 
			this.storageToolStripMenuItem.Name = "storageToolStripMenuItem";
			this.storageToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
			this.storageToolStripMenuItem.Text = "Storage";
			this.storageToolStripMenuItem.Click += new System.EventHandler(this.storageToolStripMenuItem_Click);
			// 
			// customerToolStripMenuItem
			// 
			this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
			this.customerToolStripMenuItem.Size = new System.Drawing.Size(76, 21);
			this.customerToolStripMenuItem.Text = "Customer";
			this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1215, 997);
			this.Controls.Add(this.mainMenu);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mainMenu;
			this.Name = "Main";
			this.Text = "Main";
			this.Shown += new System.EventHandler(this.Main_Shown);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private MenuStrip mainMenu;
	private ToolStripMenuItem transactionToolStripMenuItem;
	private ToolStripMenuItem storageToolStripMenuItem;
	private ToolStripMenuItem customerToolStripMenuItem;
}
