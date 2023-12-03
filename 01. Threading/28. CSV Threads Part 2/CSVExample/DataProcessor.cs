using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVExample
{
    public class DataProcessor
    {
        public string ChunkName { get; set; }
        public List<string> Chunk { get; set; }
        public Dictionary<string, int> GenderCount = new();

        public void ProcessChunk()
        {

        }
    }
}
