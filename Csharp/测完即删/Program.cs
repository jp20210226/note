using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
namespace 测完即删
{
     
    public class program
    {
        static void Main(string[] args)
        {
            Stock s = new Stock("南天");
            s.Price = 123;
            s.PriceChanged += stock_PriceChanged; s.Price = 121;
        }
        
        public static  void stock_PriceChanged(object sender, PriceChangedArgs e)
        {
            Console.WriteLine(e.LastPrice + e.NewPrice);
        }
    }

    public class PriceChangedArgs : EventArgs
    {
        public decimal LastPrice { set; get; }
        public decimal NewPrice { set; get; }

        public PriceChangedArgs(decimal lastprice, decimal newprice)
        {
            this.LastPrice = lastprice;
            this.NewPrice = newprice;
        }
    }

    public class Stock
    {
        public string Symbol;
        public Stock(string symbol)
        {
            this.Symbol = symbol; 
        }
        private decimal price;

        public event EventHandler<PriceChangedArgs> PriceChanged;

        public virtual void OnPriceChanged(PriceChangedArgs  e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal tempprice = price;
                price = value;
                OnPriceChanged(new PriceChangedArgs(tempprice, price));
            }
        }
    }

}
