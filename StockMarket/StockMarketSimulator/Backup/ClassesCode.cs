using System;
using System.Threading;
using System.Windows.Forms;

namespace StockMarketSimulator
{
	namespace SimulationUtils
	{

		/// <summary>
		/// Classe de description d'une valeur de stock simul�e
		/// </summary>
		internal class StockSimulator
		{
			///<remark>Tableau des noms de stocks � simuler</remark>
			private String[] mStockNameList;
			///<remark>evt lev� lorsque la valeur du stock a chag�</remark>
			public event ValueChangedFunctionHandler ValueChanged;
			///<remark>D�l�gu� : description de la fonction � lever lorsque l'evt ValueChanged est apparu</remark>
			public delegate void ValueChangedFunctionHandler(string StockName, float NewStockValue);
			///<remark>Thread de calcul des valeurs</remark>
			private Thread BackgroundThread;
		

			/// <summary>
			/// Cr�ateur : il prend la liste des noms de sotcks � simuler en param�tre
			/// </summary>
			/// 
			public StockSimulator(string[] TickerNameList)
			{
				mStockNameList = TickerNameList;
			}

			/// <summary>
			/// Cr�ateur
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
			public void StopSimulation()
			{
				BackgroundThread.Abort();

			}

			/// <summary>
			/// M�thode qui boucle � l'infini est qui g�n�re un valeur de stock al�atoire
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
					//on leve l'evt pour dire que ca a chag� ...
					this.ValueChanged(mStockNameList[RandomStockNameIndex],NewStockValue);
					//on attend un temps al�atoire avant de reg�n�rer une valeur de stock au hazard
					SleepTime = R.Next(10000);
					Thread.Sleep(SleepTime);
					//g�n�ration al�atoire : nom de stock + valeur
					RandomStockNameIndex = R.Next(NbStockToBeMonitored);
					NewStockValue = R.Next(200);
				}
				this.ValueChanged("fini",0);
			}



		}
	}
}