using System.Collections.Generic;

namespace Adressbuch_Model
{
    public static class StaticData
    {
        public static List<Address> AdressList = new List<Address>()
        {
            new Address { ForeName = "Hans", LastName = "Wurst", Street = "Am Wald 1", Town = "12345 Stadt", Country = "Deutschland" },
            new Address { ForeName = "Peter", LastName = "Hase", Street = "Friedhofstr. 10", Town = "54321 Ort", Country = "Deutschland" },
            new Address { ForeName = "Hildegard", LastName = "Knef", Street = "Mühlenstr. 87", Town = "33333 Dingsbums", Country = "Deutschland" }
        };
    }
}
