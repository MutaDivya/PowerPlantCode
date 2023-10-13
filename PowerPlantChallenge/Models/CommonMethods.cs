namespace WebApplication1.Models
{
    public class CommonMethods
    {
        public PowerProductionOutPut CalculateGasTurbineLoads(PowerplantEntity objPowerPlantEnt, ref decimal TempLoad)
        {
            if (TempLoad >= objPowerPlantEnt.pmin && TempLoad < objPowerPlantEnt.pmax)
            {
                objPowerPlantEnt.TotalPowerProducedByThisType = TempLoad;
                TempLoad = Convert.ToDecimal(TempLoad - objPowerPlantEnt.TotalPowerProducedByThisType);
            }
            else if (TempLoad >= objPowerPlantEnt.pmax)
            {
                objPowerPlantEnt.TotalPowerProducedByThisType = objPowerPlantEnt.pmax;
                TempLoad = Convert.ToDecimal(TempLoad - objPowerPlantEnt.TotalPowerProducedByThisType);
            }
            else
            {
                objPowerPlantEnt.TotalPowerProducedByThisType = 0;
            }

            using (PowerProductionOutPut powerProductionDetailsTemp = new PowerProductionOutPut())
            {
                
                powerProductionDetailsTemp.SuppliedLoad = objPowerPlantEnt.TotalPowerProducedByThisType;
                powerProductionDetailsTemp.PlantName = objPowerPlantEnt.name;
                return powerProductionDetailsTemp;
            }
        }
    }
}
