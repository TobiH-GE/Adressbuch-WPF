using System.Collections.Generic;

namespace Adressbuch_Model
{
    public static class StaticData /// only for testing
    {
        public static List<Contact> ContactsList = new List<Contact>()
        {
            new Contact { ForeName = "Hans", LastName = "Wurst", Street = "Am Wald 1", Town = "12345 Stadt", Country = "Deutschland" },
            new Contact { ForeName = "Peter", LastName = "Hase", Street = "Friedhofstr. 10", Town = "54321 Ort", Country = "Deutschland" },
            new Contact { ForeName = "Hildegard", LastName = "Knef", Street = "Mühlenstr. 87", Town = "33333 Dingsbums", Country = "Deutschland" }
        };
    }
}
