using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace StockMarketSimulator
{
	/// <summary>
	/// Description résumée de Aff.
	/// </summary>
	/// 

	

	public class Aff : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label AffStock;
		private System.Windows.Forms.Button GetStock;
		private System.Windows.Forms.ListBox liststock;
		
		MarketWatcher MW;
		
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Aff()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
			string[] stocksNames ={"MSFT","ORCL","IBM","YAHO"};
			MW = new MarketWatcher(stocksNames);
			liststock.DataSource = stocksNames;
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.AffStock = new System.Windows.Forms.Label();
			this.GetStock = new System.Windows.Forms.Button();
			this.liststock = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// AffStock
			// 
			this.AffStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AffStock.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.AffStock.Location = new System.Drawing.Point(16, 136);
			this.AffStock.Name = "AffStock";
			this.AffStock.Size = new System.Drawing.Size(264, 88);
			this.AffStock.TabIndex = 3;
			this.AffStock.Text = "--";
			// 
			// GetStock
			// 
			this.GetStock.Location = new System.Drawing.Point(200, 24);
			this.GetStock.Name = "GetStock";
			this.GetStock.Size = new System.Drawing.Size(64, 48);
			this.GetStock.TabIndex = 6;
			this.GetStock.Text = "get stock value";
			this.GetStock.Click += new System.EventHandler(this.GetStock_Click);
			// 
			// liststock
			// 
			this.liststock.Location = new System.Drawing.Point(40, 16);
			this.liststock.Name = "liststock";
			this.liststock.Size = new System.Drawing.Size(152, 82);
			this.liststock.TabIndex = 7;
			// 
			// Aff
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 271);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.liststock,
																		  this.GetStock,
																		  this.AffStock});
			this.Name = "Aff";
			this.Text = "Aff";
			this.ResumeLayout(false);

		}
		#endregion
		[STAThread]
		static void Main() 
		{
			Application.Run(new Aff());
		}

		private void GetStock_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show("in proc");
			string SelectedStock = liststock.SelectedItem.ToString();
			//float StockValue = (float)MW.GetStockValue(SelectedStock);
			//this.AffStock.Text = StockValue.ToString();
			this.AffStock.Text = MW.GetStockValue(SelectedStock);
			this.Refresh();
		}
	}

}
