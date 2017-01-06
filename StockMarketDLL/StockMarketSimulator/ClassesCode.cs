using System;
using System.Threading;

namespace StockMarketSimulator
{
	namespace SimulationUtils
	{

		/// <summary>
		/// Classe de génération d'un nom de stock et d'une valeur aléatoire
		/// nb : dans le NS StockMarketSimulator/SimulationUtils
		/// </summary>
		internal class StockSimulator
		{
			/// <summary>Tableau des noms de stocks à simuler</summary>
			private String[] mStockNameList;
			///<summary>evt levé lorsque la valeur du stock a chagé</summary>
			public event ValueChangedFunctionHandler ValueChanged;
			///<summary>Délégué : description de la fonction à lever lorsque l'evt ValueChanged est apparu</summary>
			public delegate void ValueChangedFunctionHandler(string StockName, float NewStockValue);
			///<summary>Thread de calcul des valeurs : il sera lié à GenerateRandomValue()</summary>
			private Thread BackgroundThread;
		

			/// <summary>
			/// Créateur : il prend la liste des noms de sotcks à simuler en paramètre
			/// pour copier dans mStockNameList
			/// </summary>
			/// 
			public StockSimulator(string[] TickerNameList)
			{
				mStockNameList = TickerNameList;
			}

			/// <summary>
			/// Lance la simulation :
			/// ThreadStart MethodeAAppelerDansLeThread = new ThreadStart(this.GenerateRandomValue);
			//BackgroundThread = new Thread(MethodeAAppelerDansLeThread);
			//BackgroundThread.Start(); 
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
			/// <summary>
			/// Stoppe la simulation :
			/// BackgroundThread.Abort();
			/// </summary>
			/// 

			public void StopSimulation()
			{
				BackgroundThread.Abort();

			}

			/// <summary>
			/// Méthode qui boucle à l'infini est qui génére un valeur de stock aléatoire
			/// Notes de codes :
			/// 				Random R =new Random(2);
			///int NbStockToBeMonitored = mStockNameList.Length;
			///int SleepTime;
			///int RandomStockNameIndex = R.Next(NbStockToBeMonitored);
			///float NewStockValue=R.Next(200);
			///while (true)
			///{this.ValueChanged(mStockNameList[RandomStockNameIndex],NewStockValue);
			///SleepTime = R.Next(10000);
			///Thread.Sleep(SleepTime);
			///RandomStockNameIndex = R.Next(NbStockToBeMonitored);
			///NewStockValue = R.Next(200);}
			/// </summary>
			/// 
			private void GenerateRandomValue()
			{
				Random R =new Random((int)System.DateTime.Now.Ticks);
				int NbStockToBeMonitored = mStockNameList.Length;
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
				//this.ValueChanged("fini",0);
			}



		}
	}
}