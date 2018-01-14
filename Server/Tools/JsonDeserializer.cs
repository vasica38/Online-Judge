using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Server.Tools
{
    public class JsonDeserializer
    {
        public static SubmissionJson Deserialize(string json)
        {
            var result = JsonConvert.DeserializeObject<SubmissionJson>(json);

            return result;

        }
    }
}
