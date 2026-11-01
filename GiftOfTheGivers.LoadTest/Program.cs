using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiftOfTheGivers.LoadTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Make sure this matches your local port!
            string url = "https://localhost:7148/";

            int concurrentUsers = 5;
            int requestsPerUser = 5;

            Console.WriteLine("==========================================");
            Console.WriteLine($" STARTING LOAD TEST FOR: {url}");
            Console.WriteLine($" Configuration: {concurrentUsers} Concurrent Users, {requestsPerUser} Requests each.");
            Console.WriteLine("==========================================\n");

            // This bypasses the localhost certificate error so it doesn't crash
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            var stopwatch = Stopwatch.StartNew();
            Task[] tasks = new Task[concurrentUsers];

            for (int i = 0; i < concurrentUsers; i++)
            {
                int userId = i + 1;
                tasks[i] = Task.Run(async () =>
                {
                    using var client = new HttpClient(handler);
                    for (int j = 0; j < requestsPerUser; j++)
                    {
                        try
                        {
                            var response = await client.GetAsync(url);
                            Console.WriteLine($"[User {userId}] Request {j + 1}: Status {(int)response.StatusCode}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[User {userId}] Error: {ex.Message}");
                        }
                    }
                });
            }

            // Wait for all 5 users to finish
            await Task.WhenAll(tasks);
            stopwatch.Stop();

            int totalRequests = concurrentUsers * requestsPerUser;
            Console.WriteLine("\n==========================================");
            Console.WriteLine(" TEST RESULTS");
            Console.WriteLine("==========================================");
            Console.WriteLine($" Total Requests Sent: {totalRequests}");
            Console.WriteLine($" Total Time Taken:    {stopwatch.Elapsed.TotalSeconds:F2} seconds");
            Console.WriteLine($" Average Time/Req:    {(stopwatch.ElapsedMilliseconds / totalRequests)} ms");
            Console.WriteLine("==========================================");
        }
    }
}