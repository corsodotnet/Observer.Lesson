using System;


namespace Observer.Lesson
{
    public delegate void NotificaPrezzo(object sender, NotificaAzioneEventArgs e);

    internal class Program
    {
        static void Main(string[] args)
        {
            NotificaPrezzo notifica = new NotificaPrezzo(Notify);
            Banca banca = new Banca();
            CryptoPortfolio Portfolio = new CryptoPortfolio();
            banca.Notify += notifica;
            Portfolio.Notify += notifica;

          
            banca.CentralBankName  = "Banca Centrale Europea";
        }
        static void Notify(object sender, NotificaAzioneEventArgs e)
        {
            Console.WriteLine(e.message);
        }
    }
    public class CentralBank
    {
        protected string centralBankName;
        public virtual event NotificaPrezzo Notify;
        public virtual string CentralBankName
        {
            get; set;
        } = "Banca D'Italia";
        public CentralBank()
        {

        }
    }
    public class NotificaAzioneEventArgs : EventArgs
    {

        public string message;
        
        public NotificaAzioneEventArgs(string Message)
        {
            message = Message;
           
        }
    }

    public class Banca : CentralBank
    {  
        public string BankName { get; set; } = "Banca Unicredit";
        public override event NotificaPrezzo Notify;
        public override string CentralBankName
        {
            get { return base.centralBankName; }
            set
            {
                if (base.centralBankName != value)
                {
                    if (Notify != null)
                    {
                        NotificaAzioneEventArgs args = new NotificaAzioneEventArgs($"Buongiorno banca {this.BankName}. Da oggi rispsodi a {value}");
                        try
                        {
                            Notify(this, args);
                            base.centralBankName = value;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        } 
         
        public Banca():base()
        {

        }
    }
    public class CryptoPortfolio : CentralBank
    {  
        public string PortfolioName { get; set; } = "Binance";
        public override event NotificaPrezzo Notify;
        public override string CentralBankName
        {
            get { return base.centralBankName; }
            set
            {
                if (base.centralBankName != value)
                {
                    if (Notify != null)
                    {
                        NotificaAzioneEventArgs args = new NotificaAzioneEventArgs(
                            $"Ciao {this.PortfolioName}. La tua banca di riferimento è cambiata.{this.CentralBankName} Da oggi  risponde a {value}" );
                        try
                        {
                            Notify(this, args);
                            base.centralBankName = value;
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public CryptoPortfolio() : base()
        {

        }
    }
}
