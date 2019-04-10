using System;

namespace JNKJ.Dto.Customers
{
    [Serializable]
    public class CustomerQueryRequest
    {
        public DateTime? createdFromUtc { get; set; }
        public DateTime? createdToUtc { get; set; }
        public Guid[] customerRoleIds { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int dayOfBirth { get; set; }
        public int monthOfBirth { get; set; }
        public int customerType { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string zipPostalCode { get; set; }
        public int status { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
