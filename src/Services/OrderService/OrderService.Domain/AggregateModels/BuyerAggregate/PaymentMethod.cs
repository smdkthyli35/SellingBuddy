using OrderService.Domain.Exceptions;
using OrderService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.AggregateModels.BuyerAggregate
{
    public class PaymentMethod : BaseEntity
    {
        public string Alias;
        public string CardNumber;
        public string SecurityNumber;
        public string CardHolderName;
        public DateTime Expiration;

        public int CardTypeId;

        public CardType CardType { get; private set; }

        public PaymentMethod() { }

        public PaymentMethod(int cardTypeId, string alias, string cardNumber, string securityNumber, string cardHolderName, DateTime expiration)
        {

            CardNumber = !string.IsNullOrWhiteSpace(cardNumber) ? cardNumber : throw new OrderingDomainException(nameof(cardNumber));
            SecurityNumber = !string.IsNullOrWhiteSpace(securityNumber) ? securityNumber : throw new OrderingDomainException(nameof(securityNumber));
            CardHolderName = !string.IsNullOrWhiteSpace(cardHolderName) ? cardHolderName : throw new OrderingDomainException(nameof(cardHolderName));

            if (expiration < DateTime.UtcNow)
            {
                throw new OrderingDomainException(nameof(expiration));
            }

            Alias = alias;
            Expiration = expiration;
            CardTypeId = cardTypeId;
        }

        public bool IsEqualTo(int cardTypeId, string cardNumber, DateTime expiration)
        {
            return CardTypeId == cardTypeId
                && CardNumber == cardNumber
                && Expiration == expiration;
        }
    }
}
