using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace PeriodicTableData
{
    public class PeriodicTableDataEngine
    {
        // Location of th JSon File
        const string JsonSource = "https://raw.githubusercontent.com/Bowserinator/Periodic-Table-JSON/master/PeriodicTableJSON.json";


        public PeriodicTableDataEngine()
        {

        }

        public async Task<PeriodicTableDataModel> InitializeData()
        {

            // Create a new instance of the HttpClient class.
            HttpClient client = new HttpClient();

            // Use the HttpClient.GetAsync method to download the file asynchronously.
            var response = await client.GetAsync(JsonSource);

            // Read the response content as a string.
            if (!response.IsSuccessStatusCode)
            {
                return new PeriodicTableDataModel(); ;
            }

            // Deserialize the JSON string into an object.
            PeriodicTableDataModel? table = null;
            try
            {
                table = await response.Content.ReadFromJsonAsync<PeriodicTableDataModel>();
            }
            catch (ArgumentNullException ex)
            {
                Debug.Fail($"ArgumentNullException parsing JsonSource {ex.Message}");
            }
            catch (JsonException ex) 
            {
                Debug.Fail($"JsonException parsing JsonSource {ex.Message}");
            }
            catch (NotSupportedException ex) 
            {
                Debug.Fail($"NotSupportedException parsing JsonSource {ex.Message}");
            }

            return table;
        }

    }
}