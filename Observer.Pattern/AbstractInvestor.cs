using System;
using System.ComponentModel;

namespace Observer.Pattern
{
    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    public abstract class AbstractInvestor : IInvestor, INotifyPropertyChanged
    { 
        private string name;
        private Stock stock;
        public abstract event PropertyChangedEventHandler PropertyChanged;
        protected int investment;
        public abstract int Investment //this is child property
        {
            get;
            set;
            
        }
        protected abstract void OnNotifyPropertyChanged(string propertyName);
        
        public AbstractInvestor(string name)
        {
            this.name = name;   
        }
        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s stock price " +
                "changed to {2:C}", name, stock.Symbol, stock.Price);
        }
        // Gets or sets the stock
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
    public  class Investor: AbstractInvestor
    {
        public override event PropertyChangedEventHandler PropertyChanged;

        public Investor(string name) : base(name)
        {

        }
        public override int Investment //this is child property
        {
            get { return investment; }
            set
            {
                if (investment != value)
                {
                    OnNotifyPropertyChanged(value.ToString());
                    investment = value;
                }
            }
        }
        protected override void OnNotifyPropertyChanged(string propertyName)
        {
            var tmp = PropertyChanged;
            if (tmp != null)
            {
                tmp(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

