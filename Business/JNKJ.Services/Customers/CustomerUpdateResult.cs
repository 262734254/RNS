using System.Collections.Generic;

namespace JNKJ.Services.Customers
{
    public class CustomerResult
    {
        public IList<string> Errors { get; set; }

        public CustomerResult()
        {
            this.Errors = new List<string>();
        }

        public bool Success
        {
            get { return this.Errors.Count == 0; }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}
