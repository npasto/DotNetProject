using System;

namespace StockMarketSimulator
{
	/// <summary>
	/// Classe contenant les valeurs instantanées d'un stock.
	/// </summary>
	internal class StockSnapShot
	{
		private float mInitialValue = 0;
		private float mCurrentValue = 0;
		private float mDelta = 0;
		/// <summary>
		/// Prop de MAJ de la valeur courante :
		/// set :
		/// if (mInitialValue == 0)
		///{
		///mInitialValue = value;mCurrentValue=value;
		///}
		///else
		///{
		///mCurrentValue=value;
		///mDelta = mCurrentValue - mInitialValue;
		///}
		/// </summary>
		public float CurrentValue 
		{
			set 
			{
				if (mInitialValue == 0)
				{
					mInitialValue = value;mCurrentValue=value;
				}
				else
				{
					mCurrentValue=value;
					mDelta = mCurrentValue - mInitialValue;
				}
			}
			get {return mCurrentValue;}
		}
		/// <summary>
		/// get only !
		/// </summary>
		public float InitialValue 
		{
			get{return mInitialValue;}
		}
		/// <summary>
		/// get only !
		/// </summary>
		public float Delta 
		{
			get{return mDelta;}
		}
	}
	/// <summary>
	/// Classe de surveillance du marché (seule clase publique de la DLL
	/// elle contient la liste des stocks(Hastable) avec leurs valeurs (classe StockSnapShot)
	/// elle contient un objet de type StockSimulator et abonne sa méthode UpdateStockValue à StockSimulator.ValueChanged
	/// </summary>
	public class MarketWatcher
	{
		/// <summary>
		/// De niveau classe ! 
		/// </summary>
		static private System.Collections.Hashtable mStockList = new System.Collections.Hashtable();
		/// <summary>
		/// De niveau classe ! 
		/// </summary>
		static private StockMarketSimulator.SimulationUtils.StockSimulator StockSimu;
		/// <summary>
		/// Créateur : instancie la HT mStockList à partir des noms de Stocks
		/// (création des couples "nom de stock" et objet StockSnapShot dans la HT)
		/// + instanciation de StockSimu et abonnement de UpdateStockValue à StockSimu.ValueChanged
		/// </summary>
		public MarketWatcher(string[] TickerNameList)
		{
			//creation du tableau de stock
			foreach (string TickerName in TickerNameList)
			{
				mStockList.Add(TickerName,new StockSnapShot());
			}
			//abonnement de la fct de MAJ aux evts
			StockSimu = new StockMarketSimulator.SimulationUtils.StockSimulator(TickerNameList);
			StockSimu.ValueChanged += new StockMarketSimulator.SimulationUtils.StockSimulator.ValueChangedFunctionHandler(this.UpdateStockValue);
			//démarage de la simulation
			StockSimu.StartSimulation();
		}
		/// <summary>
		/// Fct qui doit être abonnée à l'evt StockSimulator.ValueChanged (nom stock, valeur Stock)
		/// Quand un evt de changement apparait : retrouver le stock dans mStockList
		/// et mettre a jour sa valeur instantanée
		/// </summary>
		private void UpdateStockValue(string StName, float StPrice)
		{
			((StockSnapShot)(mStockList[StName])).CurrentValue = StPrice;
		}
		/// <summary>
		/// retourne la valeur courante d'un stock depuis un objet StockSnapShot trouvé dans la HT
		/// </summary>
		public string GetStockValue (string StName)
		{
			float CurVal = ((StockSnapShot) mStockList[StName]).CurrentValue;
			return (CurVal.ToString());
		}

		/// <summary>
		/// retourne la valeur initiale d'un stock depuis un objet StockSnapShot trouvé dans la HT
		/// </summary>
		public string GetStockInitialValue (string StName)
		{
			float CurVal = ((StockSnapShot) mStockList[StName]).InitialValue;
			return (CurVal.ToString());
		}
		/// <summary>
		/// retourne le delta d'un stock depuis un objet StockSnapShot trouvé dans la HT
		/// </summary>
		public string GetStockDelta (string StName)
		{
			float CurVal = ((StockSnapShot) mStockList[StName]).Delta;
			return (CurVal.ToString());
		}
	}
	

}
