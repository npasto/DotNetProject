using System;
using System.Threading;
using System.Windows.Forms;

namespace StockMarketSimulator
{
	namespace SimulationUtils
	{

		/// <summary>
		/// Classe de description d'une valeur de stock simulée
		/// </summary>
		internal class StockSimulator
		{
			///<remark>Tableau des noms de stocks à simuler</remark>
			private String[] mStockNameList;
			///<remark>evt levé lorsque la valeur du stock a chagé</remark>
			public event ValueChangedFunctionHandler ValueChanged;
			///<remark>Délégué : description de la fonction à lever lorsque l'evt ValueChanged est apparu</remark>
			public delegate void ValueChangedFunctionHandler(string StockName, float NewStockValue);
			///<remark>Thread de calcul des valeurs</remark>
			private Thread BackgroundThread;
		

			/// <summary>
			/// Créateur : il prend la liste des noms de sotcks à simuler en paramètre
			/// </summary>
			/// 
			public StockSimulator(string[] TickerNameList)
			{
				mStockNameList = TickerNameList;
			}

			/// <summary>
			/// Créateur
			/// </summary>
			/// 
			public void StartSimulation()
			{
			
				//			// def de la méthode à appeler dans le thread = GenerateRandomValue()
				ThreadStart MethodeAAppelerDansLeThread = new ThreadStart(this.GenerateRandomValue);
				//			//on lance le thread !
				BackgroundThread = new Thread(MethodeAAppelerDansLeThread);
				//this.GenerateRandomValue();
				BackgroundThread.Start();

			}
			public void StopSimulation()
			{
				BackgroundThread.Abort();

			}

			/// <summary>
			/// Méthode qui boucle à l'infini est qui génére un valeur de stock aléatoire
			/// </summary>
			/// 
			private void GenerateRandomValue()
			{
				Random R =new Random(2);
				int NbStockToBeMonitored = mStockNameList.Length-1;
				int SleepTime;
				int RandomStockNameIndex = R.Next(NbStockToBeMonitored);
				float NewStockValue=R.Next(200);
				while (true)
				{
					//on leve l'evt pour dire que ca a chagé ...
					this.ValueChanged(mStockNameList[RandomStockNameIndex],NewStockValue);
					//on attend un temps aléatoire avant de regénérer une valeur de stock au hazard
					SleepTime = R.Next(10000);
					Thread.Sleep(SleepTime);
					//génération aléatoire : nom de stock + valeur
					RandomStockNameIndex = R.Next(NbStockToBeMonitored);
					NewStockValue = R.Next(200);
				}
				this.ValueChanged("fini",0);
			}



		}
	}
}