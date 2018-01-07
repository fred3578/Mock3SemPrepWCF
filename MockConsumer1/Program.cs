using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MockConsumer1
{
   
class Program
{
    static void Main(string[] args)
    {
        string RestService = "http://mock3semprepwcfrest.azurewebsites.net/service1.svc/";
            IList<Catch> CatchList = GetCatchList("Catch/", RestService).Result;

        //Add Catch
        Catch Testfisk = new Catch(3, "TestFisk3", "TestArt3", 3, "TestSted3", 3);
        AddCatch(Testfisk, "Catch/", RestService);

        Thread.Sleep(10000);
        CatchList = GetCatchList("Catch/", RestService).Result;

            //Show All Catch
            Console.WriteLine("** Alle fisk **");
        ShowAllFish(CatchList);

        //show 1 fish
        Catch tempFish = GetOneFish(1, "Catch/", RestService).Result;

        Thread.Sleep(10000);

        Console.WriteLine("** 1 fisk **");
        Console.WriteLine(
            "Id: " + tempFish.Id + "\n" +
            "Navn: " + tempFish.Navn + "\n" +
            "Art: " + tempFish.Art + "\n" +
            "Vægt: " + tempFish.Vaegt + "\n" +
            "Sted: " + tempFish.Sted + "\n" +
            "Uge: " + tempFish.Uge + "\n");

        //Remove fish
        Console.WriteLine("** removing fish **");
        Thread.Sleep(10000);
        RemoveOneFish(3, "Catch/", RestService);

            Thread.Sleep(10000);

        CatchList = GetCatchList("Catch/", RestService).Result;
            ShowAllFish(CatchList);

        Console.ReadLine();
    }

    private static async Task<IList<Catch>> GetCatchList(string GetString, string RestUrl)
    {
        RestUrl = RestUrl + GetString;
        using (HttpClient client = new HttpClient())
        {
            string content = await client.GetStringAsync(RestUrl);
            IList<Catch> cList = JsonConvert.DeserializeObject<IList<Catch>>(content);
            return cList;
        }
    }
    private static async Task<Catch> GetOneFish(int id, string GetString, string RestUrl)
    {
        RestUrl = RestUrl + GetString + id;
        using (HttpClient client = new HttpClient())
        {
            string content = await client.GetStringAsync(RestUrl);
            Catch c = JsonConvert.DeserializeObject<Catch>(content);
            return c;
        }
    }

    private static async void RemoveOneFish(int id, string removeString, string restUrl)
    {
        restUrl = restUrl + removeString + id;
        using (HttpClient client = new HttpClient())
        {
            await client.DeleteAsync(restUrl);
        }
    }

    private static async Task AddCatch(Catch t, string PostString, string RestUrl)
    {
        RestUrl = RestUrl + PostString;
        string data = JsonConvert.SerializeObject(t);
        byte[] buffer = Encoding.UTF8.GetBytes(data);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        using (HttpClient client = new HttpClient())
        {
            await client.PostAsync(RestUrl, byteContent);
        }
    }

    private static void ShowAllFish(IList<Catch> catchList)
    {
        foreach (Catch c in catchList)
        {
            Console.WriteLine(
                "Id: " + c.Id + "\n" +
                "Navn: " + c.Navn + "\n" +
                "Art: " + c.Art + "\n" +
                "Vægt: " + c.Vaegt + "\n" +
                "Sted: " + c.Sted + "\n" +
                "Uge: " + c.Uge + "\n");
        }
    }
}
}
