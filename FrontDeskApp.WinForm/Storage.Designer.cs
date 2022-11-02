namespace FrontDeskApp.WinForm;

partial class Storage
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
			this.dataGrd = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGrd)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrd
			// 
			this.dataGrd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrd.Location = new System.Drawing.Point(12, 272);
			this.dataGrd.Name = "dataGrd";
			this.dataGrd.RowHeadersWidth = 45;
			this.dataGrd.RowTemplate.Height = 27;
			this.dataGrd.Size = new System.Drawing.Size(1172, 618);
			this.dataGrd.TabIndex = 0;
			// 
			// Storage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1196, 950);
			this.Controls.Add(this.dataGrd);
			this.Name = "Storage";
			this.Text = "Storage";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.Storage_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGrd)).EndInit();
			this.ResumeLayout(false);

	}

	#endregion

	private DataGridView dataGrd;
}