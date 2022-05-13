using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Observer.Pattern
{
    public abstract class Stock 
    {
        private string symbol;
        private double price;
        public List<IInvestor> investors = new List<IInvestor>();
        
        public int MarketCap { get; set; }       

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        private void MarketCapChanged(object o, PropertyChangedEventArgs e)
        {
                int newInvestment = int.Parse(e.PropertyName);            
                this.MarketCap += newInvestment;
                Console.WriteLine($"MarketCap of {symbol} now is:  {this.MarketCap}");
                  
        }
        public void Attach(IInvestor investor) 
        {
            var ivs = (Investor) investor;
            ivs.PropertyChanged += MarketCapChanged;
            investors.Add(ivs);
        }
        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        // Gets or sets the price
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }
        // Gets the symbol
        public string Symbol
        {
            get { return symbol; }
        }
    }
}

