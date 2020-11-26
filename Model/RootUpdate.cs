using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeilsData.Model
{
    // RootUpdate myDeserializedClass = JsonConvert.DeserializeObject<RootUpdate>(myJsonResponse); 
    public class RootUpdate
    {
        public UpdateProduct product { get; set; }
    }

    public class UpdateProduct
    {
        public int stock_quantity { get; set; }
    }
}
