namespace CSVExample
{
    public class DataProcessor
    {
        public string ChunkName { get; set; }
        public List<string> Chunk { get; set; }
        public Dictionary<string, int> GenderCount = new();

        public void ProcessChunk()
        {
            // 1,Lloyd,Crockatt,lcrockatt0@theatlantic.com,Male

            foreach (string line in Chunk)
            {
                // Skip the iteration if the line is empty
                if (string.IsNullOrEmpty(line)) continue;
                
                string[] values = line.Split(separator: ',');

                // If the line (CSV value) contains at least 5 value
                if (values.Length >= 5)
                {
                    // Read the value at index 4 (assuming it is gender value)
                    string gender = values[4].Trim().ToLower();

                    // If the gender already exists in the GenderCount dictionary
                    if (GenderCount.ContainsKey(gender))
                    {
                        GenderCount[gender]++;
                    }
                    else
                    {
                        GenderCount.Add(gender, 1);
                    }
                }

                // Simulate delay
                Random r = new();
                Thread.Sleep(100 * r.Next(2, 5));
            }
        }
    }
}
