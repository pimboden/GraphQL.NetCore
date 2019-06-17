using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Transactions;
using GraphQL.Types;

namespace WSI.GraphQL.Types.Payment
{
    public class PaymentType:ObjectGraphType<Database.Models.Payment>
    {
        public PaymentType()
        {
            Field(x => x.Id);
            Field(x => x.Value);
            Field(x => x.DateCreated);
            Field(x => x.DateOverdue);
            Field(x => x.Paid);
        }
    }
}
