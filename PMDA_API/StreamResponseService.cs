using System.Text.Json;

namespace PMDA_API
{
    public class StreamResponseService
    {
        public async Task StreamJsonResponse<T>(HttpResponse response, IEnumerable<T> data, int chunkSize)
        {
            response.Headers["Content-Type"] = "application/x-ndjson"; // Newline-delimited JSON
            response.Headers["Cache-Control"] = "no-cache";
            response.Headers["Transfer-Encoding"] = "chunked";

            var options = new JsonSerializerOptions { WriteIndented = false };
            int count = 0;

            var writer = response.BodyWriter.AsStream();
            await using var streamWriter = new StreamWriter(writer);

            foreach (var record in data)
            {
                string json = JsonSerializer.Serialize(record, options);
                await streamWriter.WriteLineAsync(json);
                count++;
                if (count % chunkSize == 0)
                {
                    await streamWriter.FlushAsync();
                    await response.Body.FlushAsync();
                }
            }

            await streamWriter.FlushAsync(); 
            await response.Body.FlushAsync();
        }
    }

}
