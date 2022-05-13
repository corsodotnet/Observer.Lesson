namespace Observer.Pattern
{
    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    public interface IInvestor
    {  
        void Update(Stock stock);
         int Investment //this is child property
        {
            get;
            set;

        }


    }
}

