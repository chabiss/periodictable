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
        static Dictionary<int, Lickability> LickabilityMap;

        public PeriodicTableDataEngine()
        {

        }

        static PeriodicTableDataEngine()
        {
            LickabilityMap = new Dictionary<int, Lickability>
            {
                { 1, Lickability.Sure_Probably_Fine },
                { 2, Lickability.Sure_Probably_Fine },
                { 3, Lickability.Maybe_No_a_Good_Idea},
                { 4, Lickability.You_Should_Not},
                { 5, Lickability.Sure_Probably_Fine},
                { 6, Lickability.Sure_Probably_Fine},
                { 7, Lickability.Sure_Probably_Fine},
                { 8, Lickability.Sure_Probably_Fine},
                { 9, Lickability.You_Should_Not},
                { 10, Lickability.Sure_Probably_Fine},
                { 11, Lickability.You_Should_Not},
                { 12, Lickability.Sure_Probably_Fine},
                { 13, Lickability.Sure_Probably_Fine},
                { 14, Lickability.Sure_Probably_Fine},
                { 15, Lickability.Maybe_No_a_Good_Idea},
                { 16, Lickability.Sure_Probably_Fine},
                { 17, Lickability.You_Should_Not},
                { 18, Lickability.Sure_Probably_Fine},
                { 19, Lickability.You_Should_Not},
                { 20, Lickability.Sure_Probably_Fine},
                { 21, Lickability.Sure_Probably_Fine},
                { 22, Lickability.Sure_Probably_Fine},
                { 23, Lickability.Sure_Probably_Fine},
                { 24, Lickability.Sure_Probably_Fine},
                { 25, Lickability.Sure_Probably_Fine},
                { 26, Lickability.Sure_Probably_Fine},
                { 27, Lickability.Sure_Probably_Fine},
                { 28, Lickability.Sure_Probably_Fine},
                { 29, Lickability.Sure_Probably_Fine},
                { 30, Lickability.Sure_Probably_Fine},
                { 31, Lickability.Sure_Probably_Fine},
                { 32, Lickability.Sure_Probably_Fine},
                { 33, Lickability.You_Should_Not},
                { 34, Lickability.Maybe_No_a_Good_Idea},
                { 35, Lickability.You_Should_Not},
                { 36, Lickability.Sure_Probably_Fine},
                { 37, Lickability.You_Should_Not},
                { 38, Lickability.You_Should_Not},
                { 39, Lickability.Sure_Probably_Fine},
                { 40, Lickability.Sure_Probably_Fine},
                { 41, Lickability.Sure_Probably_Fine},
                { 42, Lickability.Sure_Probably_Fine},
                { 43, Lickability.You_Should_Not},
                { 44, Lickability.Sure_Probably_Fine},
                { 45, Lickability.Sure_Probably_Fine},
                { 46, Lickability.Sure_Probably_Fine},
                { 47, Lickability.Sure_Probably_Fine},
                { 48, Lickability.You_Should_Not},
                { 49, Lickability.Sure_Probably_Fine},
                { 50, Lickability.Sure_Probably_Fine},
                { 51, Lickability.Maybe_No_a_Good_Idea},
                { 52, Lickability.Maybe_No_a_Good_Idea},
                { 53, Lickability.You_Should_Not},
                { 54, Lickability.Sure_Probably_Fine},
                { 55, Lickability.You_Should_Not},
                { 56, Lickability.You_Should_Not},
                { 57, Lickability.Sure_Probably_Fine},
                { 58, Lickability.Sure_Probably_Fine},
                { 59, Lickability.Sure_Probably_Fine},
                { 60, Lickability.Sure_Probably_Fine},
                { 61, Lickability.You_Should_Not},
                { 62, Lickability.Sure_Probably_Fine},
                { 63, Lickability.Sure_Probably_Fine},
                { 64, Lickability.Sure_Probably_Fine},
                { 65, Lickability.Sure_Probably_Fine},
                { 66, Lickability.Sure_Probably_Fine},
                { 67, Lickability.Sure_Probably_Fine},
                { 68, Lickability.Sure_Probably_Fine},
                { 69, Lickability.Sure_Probably_Fine},
                { 70, Lickability.Sure_Probably_Fine},
                { 71, Lickability.Sure_Probably_Fine},
                { 72, Lickability.Sure_Probably_Fine},
                { 73, Lickability.Sure_Probably_Fine},
                { 74, Lickability.Sure_Probably_Fine},
                { 75, Lickability.Sure_Probably_Fine},
                { 76, Lickability.Maybe_No_a_Good_Idea},
                { 77, Lickability.Sure_Probably_Fine},
                { 78, Lickability.Sure_Probably_Fine},
                { 79, Lickability.Sure_Probably_Fine},
                { 80, Lickability.You_Should_Not},
                { 81, Lickability.You_Should_Not},
                { 82, Lickability.Maybe_No_a_Good_Idea},
                { 83, Lickability.Sure_Probably_Fine},
                { 84, Lickability.Please_Reconsider},
                { 85, Lickability.Please_Reconsider},
                { 86, Lickability.Please_Reconsider},
                { 87, Lickability.Please_Reconsider},
                { 88, Lickability.Please_Reconsider},
                { 89, Lickability.Please_Reconsider},
                { 90, Lickability.Maybe_No_a_Good_Idea},
                { 91, Lickability.Please_Reconsider},
                { 92, Lickability.Maybe_No_a_Good_Idea},
                { 93, Lickability.Please_Reconsider},
                { 94, Lickability.Please_Reconsider},
                { 95, Lickability.Please_Reconsider},
                { 96, Lickability.Please_Reconsider},
                { 97, Lickability.Please_Reconsider},
                { 98, Lickability.Please_Reconsider},
                { 99, Lickability.Please_Reconsider},
                {100, Lickability.Please_Reconsider},
                {101, Lickability.Please_Reconsider},
                {102, Lickability.Please_Reconsider},
                {103, Lickability.Please_Reconsider},
                {104, Lickability.Please_Reconsider},
                {105, Lickability.Please_Reconsider},
                {106, Lickability.Please_Reconsider},
                {107, Lickability.Please_Reconsider},
                {108, Lickability.Please_Reconsider},
                {109, Lickability.Please_Reconsider},
                {110, Lickability.Please_Reconsider},
                {111, Lickability.Please_Reconsider},
                {112, Lickability.Please_Reconsider},
                {113, Lickability.Please_Reconsider},
                {114, Lickability.Please_Reconsider},
                {115, Lickability.Please_Reconsider},
                {116, Lickability.Please_Reconsider},
                {117, Lickability.Please_Reconsider},
                {118, Lickability.Please_Reconsider}
            };
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

            // Add Lickability
            PeriodicTableDataEngine.MapLickability(table);

            return table;
        }

        private static void MapLickability(PeriodicTableDataModel? table)
        {
            if(table == null)
            {
                return;
            }

            foreach (var element in table.Elements)
            {
                if (LickabilityMap.TryGetValue(element.Number, out Lickability lickability))
                {
                    element.Lickability = lickability;
                }
            }
        }
    }
}