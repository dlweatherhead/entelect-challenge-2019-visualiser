using System.IO;
using Newtonsoft.Json;

namespace EC2019.Utility {
    public class JsonFileParser<T> {

        private readonly string filePath;
        
        public JsonFileParser(string filePath) {
            this.filePath = filePath;
        }

        public T GetSerializedData() {
            var streamReader = new StreamReader(filePath);
            var contents = streamReader.ReadToEnd();
            streamReader.Close();
            
            return JsonConvert.DeserializeObject<T>(contents);
        }
    }
}