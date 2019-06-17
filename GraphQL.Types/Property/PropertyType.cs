using GraphQL.Types;
using WSI.GraphQL.DataAccess.Repositories;
using WSI.GraphQL.Types.Payment;

namespace WSI.GraphQL.Types.Property
{
    public class PropertyType:ObjectGraphType<Database.Models.Property>
    {
        public PropertyType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);
            Field<ListGraphType<PaymentType>>("payments",
                resolve: context => paymentRepository.GetAllForProperty(context.Source.Id));
        }
    }
}
