using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServicesDTOs
{
    public sealed class StockVariation
    {
        private string _stockName = String.Empty;
        private int _variation = 0;

        public StockVariation()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public StockVariation(string StName, int variation)
        {
            this._variation = variation;
            this._stockName = StName;
        }



        public int variation
        {
            get { return _variation; }
            set { _variation = value; }
        }

        public string name
        {
            get { return _stockName; }
            set { _stockName = value; }
        }
    }//stock
}
