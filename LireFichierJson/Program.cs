
using System.Text.Json;
using LireFichierJson;
using Newtonsoft.Json;

const string FILE_PATH = @"C:\Users\pc\Downloads\PowerPlantCoding\PowerPlantCoding\payload1.json";
Console.WriteLine("Lire fichier");
string[] lines = System.IO.File.ReadAllLines(FILE_PATH);
string allJsonText = String.Join("\n", lines);

using (StreamReader ReaderObject = new StreamReader(FILE_PATH))
{

    while (!ReaderObject.EndOfStream)
    {
        string line = ReaderObject.ReadLine();
        Console.WriteLine(line);
    }
}

Document doc = JsonConvert.DeserializeObject<Document>(allJsonText);
Console.WriteLine(doc.Load);
Console.WriteLine(doc.FuelsPrice);
foreach (var item in doc.PowerPlants)
{
    Console.WriteLine(item);

}


Response[] productionPlan = new Response[doc.PowerPlants.Count];
int index = 0;
int load = doc.Load;
foreach (var item in doc.PowerPlants)
{
    Response response = new Response();
    response.name = item.Name;

    if (load >= item.Pmax)
    {
        response.p = item.Pmax;
    }
    else if (load <= item.Pmax && load > 0)
    {
        response.p = load;
    }
    else if (load <= 0)
    {
        response.p = 0;
    }
       
    load -= item.Pmax;
    

    productionPlan[index++] = response;
    Console.WriteLine(response);
}

string responseJson = JsonConvert.SerializeObject(productionPlan, Formatting.Indented);
Console.WriteLine(responseJson);


