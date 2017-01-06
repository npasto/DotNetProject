using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace StockMarketSimulator
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label AffStock;
		StockMarketSimulator.SimulationUtils.StockSimulator Stock;
		private System.Windows.Forms.Button StartSimu;
		private System.Windows.Forms.Button StopSimu;
		private System.Windows.Forms.Button btX;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//

			string[] stocksNames ={"MSFT","ORCL","IBM","YAHO"};
			Stock = new StockMarketSimulator.SimulationUtils.StockSimulator(stocksNames);
			Stock.ValueChanged += new StockMarketSimulator.SimulationUtils.StockSimulator.ValueChangedFunctionHandler(this.DisplayStockValue);

			

		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.StartSimu = new System.Windows.Forms.Button();
			this.StopSimu = new System.Windows.Forms.Button();
			this.btX = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// AffStock
			// 
			this.AffStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AffStock.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.AffStock.Location = new System.Drawing.Point(64, 56);
			this.AffStock.Name = "AffStock";
			this.AffStock.TabIndex = 0;
			this.AffStock.Text = "--";
			// 
			// StartSimu
			// 
			this.StartSimu.Location = new System.Drawing.Point(40, 200);
			this.StartSimu.Name = "StartSimu";
			this.StartSimu.Size = new System.Drawing.Size(64, 48);
			this.StartSimu.TabIndex = 1;
			this.StartSimu.Text = "StartSimu";
			this.StartSimu.Click += new System.EventHandler(this.StartSimu_Click);
			// 
			// StopSimu
			// 
			this.StopSimu.Location = new System.Drawing.Point(160, 152);
			this.StopSimu.Name = "StopSimu";
			this.StopSimu.Size = new System.Drawing.Size(88, 48);
			this.StopSimu.TabIndex = 2;
			this.StopSimu.Text = "StopSimu";
			this.StopSimu.Click += new System.EventHandler(this.StopSimu_Click);
			// 
			// btX
			// 
			this.btX.Location = new System.Drawing.Point(208, 40);
			this.btX.Name = "btX";
			this.btX.TabIndex = 3;
			this.btX.Text = "button1";
			this.btX.Click += new System.EventHandler(this.btX_Click);
				btX.Text = "titi";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 271);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btX,
																		  this.StopSimu,
																		  this.StartSimu,
																		  this.AffStock});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void DisplayStockValue(string StName, float StPrice)
		{
			//MessageBox.Show("in proc");
			this.AffStock.Text = StName + " " + StPrice.ToString();
			this.Refresh();
		}

		private void StartSimu_Click(object sender, System.EventArgs e)
		{
					Stock.StartSimulation();
		}

		private void StopSimu_Click(object sender, System.EventArgs e)
		{
			Stock.StopSimulation();
		}

		private void btX_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
