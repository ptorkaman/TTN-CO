using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TTN
{
    
    public static class HtmlTextWriterExtensions
    {

        public static void AddAttributes(this XmlTextWriter writer, IDictionary<string, object> attributes)
        {
            if (attributes.Any<KeyValuePair<string, object>>())
            {
                foreach (var pair in attributes)
                {
                    //if (pair.Value != null)
                    //    writer.AddAttribute(pair.Key, pair.Value.ToString(), true);
                }
            }
        }


    }

}
