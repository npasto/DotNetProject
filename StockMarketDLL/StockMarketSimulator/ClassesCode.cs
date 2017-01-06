using System;
using System.Threading;

namespace StockMarketSimulator
{
	namespace SimulationUtils
	{

		/// <summary>
		/// Classe de g�n�ration d'un nom de stock et d'une valeur al�atoire
		/// nb : dans le NS StockMarketSimulator/SimulationUtils
		/// </summary>
		internal class StockSimulator
		{
			/// <summary>Tableau des noms de stocks � simuler</summary>
			private String[] mStockNameList;
			///<summary>evt lev� lorsque la valeur du stock a chag�</summary>
			public event ValueChangedFunctionHandler ValueChanged;
			///<summary>D�l�gu� : description de la fonction � lever lorsque l'evt ValueChanged est apparu</summary>
			public delegate void ValueChangedFunctionHandler(string StockName, float NewStockValue);
			///<summary>Thread de calcul des valeurs : il sera li� � GenerateRandomValue()</summary>
			private Thread BackgroundThread;
		

			/// <summary>
			/// Cr�ateur : il prend la liste des noms de sotcks � simuler en param�tre
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
			
				//			// def de la m�thode � appeler dans le thread = GenerateRandomValue()
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
			/// M�thode qui boucle � l'infini est qui g�n�re un valeur de stock al�atoire
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
					//on leve l'evt pour dire que ca a chag� ...
					this.ValueChanged(mStockNameList[RandomStockNameIndex],NewStockValue);
					//on attend un temps al�atoire avant de reg�n�rer une valeur de stock au hazard
					SleepTime = R.Next(10000);
					Thread.Sleep(SleepTime);
					//g�n�ration al�atoire : nom de stock + valeur
					RandomStockNameIndex = R.Next(NbStockToBeMonitored);
					NewStockValue = R.Next(200);
				}
				//this.ValueChanged("fini",0);
			}



		}
	}
}