using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
namespace IntellicenceProgramInWpf
{
    public class Helper
    {
        public List<Data> Datas { get; set; }
        public void SeriailizeEndatasToJson()
        {
            using (StreamWriter sw = new StreamWriter("words.json"))
            {
                var item = JsonConvert.SerializeObject(Datas);
                sw.WriteLine(item);
            }
        }
        public List<Data> DeserializeEnDatasFromJson()
        {
            try
            {
                var context = File.ReadAllText("words.json");
                Datas = JsonConvert.DeserializeObject<List<Data>>(context);
            }
            catch (Exception)
            {
            }
            return Datas;
        }
    }
}


