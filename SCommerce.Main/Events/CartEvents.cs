using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Events
{
    public class AddedToCartEvent : PubSubEvent<AddedToCartEvent.PayLoad>
    {
        public class PayLoad
        {
            public int ProductId { get; set; }
            public int Quatity { get; set; }
        }
    }

    public class SubtractedFromCartEvent : PubSubEvent<SubtractedFromCartEvent.PayLoad>
    {
        public class PayLoad
        {
            public int ProductId { get; set; }
            public int Quatity { get; set; }
        }
    }

    public class RemovedFromCartEvent : PubSubEvent<RemovedFromCartEvent.PayLoad>
    {
        public class PayLoad
        {
            public int ProductId { get; set; }
        }
    }
}
