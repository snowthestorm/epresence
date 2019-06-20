using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyPresence.Common
{
    public static class Helpers
    {
        public static bool LoadData()
        {
            try
            {
                using (var r = new StreamReader("easyPresence.json"))
                {
                
                    var jsonData = r.ReadToEnd();
                    {
                        Data.Configurations = JsonConvert.DeserializeObject<Configurations>(jsonData);
                        Data.CurrentIdentifier = Data.Configurations.Identifier;
                        return true;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Data.CurrentIdentifier = Data.DefaultPresenceId;
                return false;
            }
        }
    }
}