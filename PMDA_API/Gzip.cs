using Newtonsoft.Json;
using PMDA_API.Models;
using System.IO.Compression;
using System.Text;

namespace PMDA_API
{
    public static class Gzip
    {
        public static (List<byte[]>, long, long) CompressAndChunkFlightData(FlightData objFlightDataResult, int chunkSizeInKB = 1024)
        {
            // Serialize FlightData object to JSON
            string jsonData = JsonConvert.SerializeObject(objFlightDataResult);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);
            long originalSize = jsonBytes.Length;

            // Compress the JSON data using Gzip
            byte[] compressedData = CompressData(jsonBytes);
            long compressedSize = compressedData.Length;

            // Split compressed data into chunks
            List<byte[]> chunks = ChunkData(compressedData, chunkSizeInKB * 1024);

            Console.WriteLine($"Original Size: {originalSize / 1024.0} KB");
            Console.WriteLine($"Compressed Size: {compressedSize / 1024.0} KB");
            Console.WriteLine($"Compression Ratio: {(100.0 * compressedSize / originalSize):0.00}%");

            return (chunks, originalSize, compressedSize);
        }

        private static byte[] CompressData(byte[] data)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(data, 0, data.Length);
                }
                return memoryStream.ToArray();
            }
        }

        private static List<byte[]> ChunkData(byte[] data, int chunkSize)
        {
            List<byte[]> chunks = new List<byte[]>();
            int offset = 0;

            while (offset < data.Length)
            {
                int size = Math.Min(chunkSize, data.Length - offset);
                byte[] chunk = new byte[size];
                Buffer.BlockCopy(data, offset, chunk, 0, size);
                chunks.Add(chunk);
                offset += size;
            }

            return chunks;
        }
    }
}

