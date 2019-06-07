using System.Collections.Generic;
using System.Text;

namespace WSI.GraphQL.Database.Models
{
    public class Property
    {
        public Property()
        {
            Payments = new List<Payment>();
        }
        public int  Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public decimal Value { get; set; }
        public string Family { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
