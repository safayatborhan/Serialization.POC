using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.POC
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public IList<Description> Descriptions { get; set; }
        public List<string> Screenshots { get; set; }
    }

    public class Description
    {
        public string Text { get; set; }
        public string Language { get; set; }
    }
}
