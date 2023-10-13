//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace WebApplication1.Models
{
    public class LoadDetailsViewModel
    {
        public int load { get; set; }        
        public FuelEntity fuels { get; set; }
        public List<PowerplantEntity> powerplants { get; set; }
       
    }
    public enum PowerPlantNames
    {
        windturbine, gasfired, turbojet
    }
    public class FuelEntity
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public decimal gasPrice { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal kerosinePrice { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public decimal co2Allowance { get; set; }

        [JsonPropertyName("wind(%)")]
        public int windPercentage { get; set; }
    }

    public class PowerplantEntity
    {
        public string name { get; set; }
        public string type { get; set; }
        public decimal efficiency { get; set; }
        public int pmin { get; set; }
        public int pmax { get; set; }

        [JsonIgnore]
        public decimal TotalPowerProducedByThisType { get; set; }

        [JsonIgnore]
        public decimal costpermwh { get; set; }

    }
    public class PowerProductionOutPut:IDisposable
    {
        void IDisposable.Dispose() { }

        [JsonPropertyName("name")]
        public string PlantName { get; set; }

        [JsonPropertyName("p")]
        public decimal SuppliedLoad { get; set; }
        
    }

    interface ICalculatePowerProduced
    {
        List<PowerProductionOutPut> CalculatePowerProducedByThisType(LoadDetailsViewModel loadDetailsViewModel,ref decimal TempLoad);
    }
    interface ICalculateCostOfPowerProduced
    {
        decimal CalculateCostOfPowerProducedThisType(FuelEntity objFuels);
    }

    
}
