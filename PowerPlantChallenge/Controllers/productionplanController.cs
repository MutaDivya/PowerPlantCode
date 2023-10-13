using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productionplanController : ControllerBase
    {
        private decimal TempLoad;
        private List<PowerProductionOutPut> PowerProductionOutPutList;
        private PowerProductionOutPut powerProductionDetailsTemp;
        private Windturbine objWindT;
        private Gasfired objGasfired;
        private Turbojet objTurbojet;

              
        [HttpPost]
        public JsonResult productionplan(LoadDetailsViewModel loadDetailsViewModel)
        {
            try
            {
                TempLoad = Convert.ToDecimal(loadDetailsViewModel.load);
                //powerProductionDetailsTemp = new PowerProductionOutPut();
                PowerProductionOutPutList = new List<PowerProductionOutPut>();
                if (TempLoad > 0)
                {
                    objWindT = new Windturbine();
                    objGasfired = new Gasfired();
                    objTurbojet = new Turbojet();

                    PowerProductionOutPutList.AddRange(objWindT.CalculatePowerProducedByThisType(loadDetailsViewModel, ref TempLoad));
                    PowerProductionOutPutList.AddRange(objGasfired.CalculatePowerProducedByThisType(loadDetailsViewModel, ref TempLoad));
                    PowerProductionOutPutList.AddRange(objTurbojet.CalculatePowerProducedByThisType(loadDetailsViewModel, ref TempLoad));

                }


                return new JsonResult(PowerProductionOutPutList);
            }

            catch (Exception ex) {
                return new JsonResult(""); }
            finally { 
            }
        }
    }
}