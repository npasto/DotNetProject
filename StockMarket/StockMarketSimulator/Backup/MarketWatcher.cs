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
		public float InitialValue 
		{
			get{return mInitialValue;}
		}
		public float Delta 
		{
			get{return mDelta;}
		}
	}
	/// <summary>
	/// Classe de surveillance du marché
	/// elle contient la liste des stocks(Hastable) avec leurs valeurs (classe StockSnapShot)
	/// </summary>
	public class MarketWatcher
	{
		static private System.Collections.Hashtable mStockList = new System.Collections.Hashtable();
		static private StockMarketSimulator.SimulationUtils.StockSimulator StockSimu;
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
		/// Quand un evt de changement apparait : retrouver le stock dans mStockList
		/// et mettre a jour sa valeur instantanée
		/// </summary>
		private void UpdateStockValue(string StName, float StPrice)
		{
			((StockSnapShot)(mStockList[StName])).CurrentValue = StPrice;
		}
		public string GetStockValue (string StName){
			float CurVal = ((StockSnapShot) mStockList[StName]).CurrentValue;
			return (CurVal.ToString());
		}
	}
	

}
