using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LireFichierJson
{
    public class Document
    {
        public int Load { get; set; }
        [JsonProperty(PropertyName = "fuels")]
        public FuelsPrice FuelsPrice { get; set; }
        public IList<PowerPlant> PowerPlants { get; set; }


    }
    
    public class FuelsPrice
    {
        [JsonProperty(PropertyName = "gas(euro/MWh")]
        public decimal Gas { get; set; }

        [JsonProperty(PropertyName = "Kerosine(euro/MWh")]
        public decimal Kerosine { get; set; }

        [JsonProperty(PropertyName = "co2(euro/ton")]
        public decimal CO2 { get; set; }

        [JsonProperty(PropertyName = "wind(%)")]
        public int WindPercent { get; set; }

        public override string ToString()
        {
            return $"Gas = {this.Gas} \t\nKerosine = {this.Kerosine} \t\nCO2 = {this.CO2} \t\nWind = {this.WindPercent}%";
        }

    }
    public class PowerPlant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Efficiency { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }


        public override string ToString()
        {
            return $"Plant : \t\nName = {this.Name} \t\nType = {this.Type} \t\nEfficiency = {this.Efficiency} \t\nPmin = {this.Pmin} \t\nPmax = {this.Pmax}";
        }

    }

}
