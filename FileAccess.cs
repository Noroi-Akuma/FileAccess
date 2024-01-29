namespace FileAccess
{
    public class FileAccess
    {

       static void Main(string[] args)
        {

        }

        /// <summary>
        /// Read from a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<string> ReadFromFile(string fileName)
        {
            List<string> rows = new List<string>();
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            rows.Add(line);
                        }
                    }
                }
                else
                {
                    throw new Exception(string.Format("Reading exception: {0} does not exist", fileName));
                }
            }
            catch (FileNotFoundException fnfe)
            {
                throw new Exception("Exception thrown: " + fnfe.Message);
            }
            catch (IOException ioe)
            {
                throw new Exception("Exception thrown: " +  ioe.Message);
            } return rows;
        } 

        /// <summary>
        /// Overwrite file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public static void writeToFile(string fileName, string data) 
        {
            FileAccess.writeToFile(fileName, data, true);
        }

        /// <summary>
        /// Write to a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        /// <param name="append"></param>
        /// <exception cref="Exception"></exception>
        public static void writeToFile(string fileName, string data, bool append)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, append))
                {
                    writer.Write(data);
                }
            } catch (IOException ioe)
            {
                throw new Exception("Exception thrown: " +  ioe.Message);
            }
        }

    }
}
