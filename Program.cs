using Newtonsoft.Json.Linq;

var client = new HttpClient();
var apikey = JObject.Parse(File.ReadAllText("appsettings.json")).GetValue("apiKey").ToString();
var cat = "recipes";
var search = "complexSearch";
var parms = new List<string>() { "query=pasta", "maxFat=25", "number=2" };
var spoonURL = $"https://api.spoonacular.com/{cat}/{search}?apiKey={apikey}";
foreach (var param in parms)
{
    spoonURL += "&" + param;
}
var food = client.GetStringAsync(spoonURL).Result;
var finalfood = JObject.Parse(food);
JArray results = (JArray)finalfood["results"];
foreach (JObject result in results)
{
    string title = (string)result["title"];
    Console.WriteLine(title);
}
