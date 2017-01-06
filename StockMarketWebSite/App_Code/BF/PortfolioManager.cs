using System;

using System.Collections.Generic;


namespace BF
{
    /// <summary>
    /// Summary description for PortfolioManager
    /// </summary>
    public class PortfolioManager
    {
        public PortfolioManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static List<DTO.valorizedStockInfo> getCurrentPorfolioValorization(int idClient)
        {
            List<DTO.valorizedStockInfo> res;
            List<DTO.stockOwnedInfo> ownedStocks = DAL.DAClients.getOwnedStockByClientID(idClient);
            if (ownedStocks.Count != 0)
            {
                res = new List<DTO.valorizedStockInfo>();
                DTO.valorizedStockInfo valorizedStockInfoInstance;
                foreach (DTO.stockOwnedInfo ownedStockInstance in ownedStocks)
                {
                    valorizedStockInfoInstance = new DTO.valorizedStockInfo(ownedStockInstance.stockName, ownedStockInstance.nbStocksOwned * float.Parse(stockMarketSystem.MW.GetStockValue(ownedStockInstance.stockName)));
                    res.Add(valorizedStockInfoInstance);
                }
                return res;

            }
            else { return null; }
        }

        //public static IEnumerable<DTO.valorizedStockInfo> getCurrentPorfolioValorization(EDM.client aClient)
        //{
        //    //List<DTO.stockOwnedInfo> ownedStocks = DAL.DAClients.getOwnedStockByClientID(idClient);
        //    if (aClient.clientsPortfolios.Count != 0)
        //    {
        //        foreach (EDM.Stock ownedStockInstance in aClient.clientsPortfolios)
        //        {
        //            yield return new DTO.valorizedStockInfo(ownedStockInstance.idStock, ownedStockInstance.nbOwned * float.Parse(stockMarketSystem.MW.GetStockValue(ownedStockInstance.idStock)));

        //        }


        //    }
        //    else { yield return null; }
        //}

        //public static IEnumerable<EDM.Stock> getCurrentPorfolioValorizationEDM(EDM.client aClient)
        //{
        //    //List<DTO.stockOwnedInfo> ownedStocks = DAL.DAClients.getOwnedStockByClientID(idClient);
        //    if (aClient.clientsPortfolios.Count != 0)
        //    {
        //        foreach (EDM.Stock ownedStockInstance in aClient.clientsPortfolios)
        //        {
        //            ownedStockInstance.UpdateValorization(float.Parse(stockMarketSystem.MW.GetStockValue(ownedStockInstance.idStock)));
        //            yield return ownedStockInstance;
        //        }
        //    }
        //    else { yield return null; }
        //}
    }

}