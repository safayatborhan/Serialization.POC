using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.Playground
{
    public class Description
    {
        public string Text { get; set; }
    }

    public class MetadataDescription
    {
        public string Description { get; set; }
        public string Language { get; set; }
    }

    public class ScreenShot
    {
        public List<string> ScreenShots { get; set; }
    }

    public class LinguisticDescription
    {
        public List<MetadataDescription> Descriptions { get; set; }
    }
}
