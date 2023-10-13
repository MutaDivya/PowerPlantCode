namespace WebApplication1.Models
{
    public class Windturbine: ICalculatePowerProduced
    {
        public List<PowerProductionOutPut> CalculatePowerProducedByThisType(LoadDetailsViewModel loadDetailsViewModel,ref decimal TempLoad)
        {
             List<PowerProductionOutPut> objTempList = new List<PowerProductionOutPut>();

         for (int i = 0; i<loadDetailsViewModel.powerplants.Count; i++)
            {
                if (loadDetailsViewModel.powerplants[i].type.Equals(PowerPlantNames.windturbine.ToString()) && TempLoad>0)
                {
                    if (TempLoad >loadDetailsViewModel.powerplants[i].pmin)
                    {
                        loadDetailsViewModel.powerplants[i].TotalPowerProducedByThisType = Convert.ToDecimal(loadDetailsViewModel.fuels.windPercentage * loadDetailsViewModel.powerplants[i].pmax* 0.01);
                    }
                    else
                    {
                        loadDetailsViewModel.powerplants[i].TotalPowerProducedByThisType = Convert.ToDecimal(loadDetailsViewModel.fuels.windPercentage * loadDetailsViewModel.powerplants[i].pmin * 0.01);
                    }

                    if (TempLoad >= loadDetailsViewModel.powerplants[i].TotalPowerProducedByThisType)
                    {
                        using (PowerProductionOutPut powerProductionDetailsTemp = new PowerProductionOutPut())
                        {
                            TempLoad = Convert.ToDecimal((TempLoad - loadDetailsViewModel.powerplants[i].TotalPowerProducedByThisType));
                            powerProductionDetailsTemp.SuppliedLoad = loadDetailsViewModel.powerplants[i].TotalPowerProducedByThisType;
                            powerProductionDetailsTemp.PlantName = loadDetailsViewModel.powerplants[i].name;
                            objTempList.Add(powerProductionDetailsTemp);
                        }
                    }
                }

            }

             return objTempList;

        }
    }
}
