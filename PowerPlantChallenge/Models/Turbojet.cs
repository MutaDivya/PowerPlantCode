
namespace WebApplication1.Models
{
    public class Turbojet : ICalculatePowerProduced, ICalculateCostOfPowerProduced
    {
        public Turbojet() 
        { }
        public List<PowerProductionOutPut> CalculatePowerProducedByThisType(LoadDetailsViewModel loadDetailsViewModel, ref decimal TempLoad)
        {            
            List<PowerProductionOutPut> objTempList = new List<PowerProductionOutPut>();
            CommonMethods objCommonMethod=new CommonMethods();  

            for (int i = 0; i < loadDetailsViewModel.powerplants.Count; i++)
            {
                if (loadDetailsViewModel.powerplants[i].type.Equals(PowerPlantNames.turbojet.ToString()))
                {
                    objTempList.Add(objCommonMethod.CalculateGasTurbineLoads(loadDetailsViewModel.powerplants[i], ref TempLoad));
                }
            } 
            return objTempList;
        }
        
        public decimal CalculateCostOfPowerProducedThisType(FuelEntity objFuels)
        {
            return 0;
        }
    }
}
