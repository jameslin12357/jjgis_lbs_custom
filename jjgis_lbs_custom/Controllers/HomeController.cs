using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using jjgis_lbs_custom.Models;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;

namespace jjgis_lbs_custom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            string stringXQHSQ = System.IO.File.ReadAllText(@"C:\Users\mac\Documents\PoisHousingCFS\PoisHousingHSQ\PoisHousingXQ\poisHousingHSQMoreF.txt", Encoding.UTF8);
            string stringLHSQ = System.IO.File.ReadAllText(@"C:\Users\mac\Documents\PoisHousingCFS\PoisHousingHSQ\PoisHousingL\poisHousingLF.txt", Encoding.UTF8);
            string stringXQSSQ = System.IO.File.ReadAllText(@"C:\Users\mac\Documents\PoisHousingCFS\PoisHousingSSQ\PoisHousingXQ\poisHousingSSQMoreF.txt", Encoding.UTF8);
            string stringLSSQ = System.IO.File.ReadAllText(@"C:\Users\mac\Documents\PoisHousingCFS\PoisHousingSSQ\PoisHousingL\poisHousingLF.txt", Encoding.UTF8);

            List<Dictionary<string, string>> objXQHSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringXQHSQ);
            List<Dictionary<string, string>> objLHSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringLHSQ);
            List<Dictionary<string, string>> objXQSSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringXQSSQ);
            List<Dictionary<string, string>> objLSSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringLSSQ);

            string connectionString = "User Id=john;Password=pudong;Data Source=localhost:1521/socialclone";
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            //for (var i = 0; i < objXQHSQ.Count; i++)
            //{
            //    OracleCommand cmd = connection.CreateCommand();

            //    string sql = $"begin insert into LBS_AJ_VILLAGE (VILLAGE_NAME, VILLAGE_ADDRESS, VILLAGE_TYPE, MEMO, VILLAGE_REGION, HOUSEHOLDS, AREA_ID, VILLAGE_CODE, VILLAGE_BOUNDS, VILLAGE_X, VILLAGE_Y, VILLAGE_LNG, VILLAGE_LAT) values ('{objXQHSQ[i]["poiName"]}','{objXQHSQ[i]["poiAddress"]}','{objXQHSQ[i]["poiType"]}','','{objXQHSQ[i]["poiRegion"]}','','','{objXQHSQ[i]["poiId"]}','{objXQHSQ[i]["poiBounds"]}','{objXQHSQ[i]["poiLng"]}','{objXQHSQ[i]["poiLat"]}','{objXQHSQ[i]["poiLng"]}','{objXQHSQ[i]["poiLat"]}');commit;end;";
            //    cmd.CommandText = sql;
            //    cmd.ExecuteNonQuery();
            //}
            //for (var i = 0; i < objXQSSQ.Count; i++)
            //{
            //    OracleCommand cmd = connection.CreateCommand();

            //    string sql = $"begin insert into LBS_AJ_VILLAGE (VILLAGE_NAME, VILLAGE_ADDRESS, VILLAGE_TYPE, MEMO, VILLAGE_REGION, HOUSEHOLDS, AREA_ID, VILLAGE_CODE, VILLAGE_BOUNDS, VILLAGE_X, VILLAGE_Y, VILLAGE_LNG, VILLAGE_LAT) values ('{objXQSSQ[i]["poiName"]}','{objXQSSQ[i]["poiAddress"]}','{objXQSSQ[i]["poiType"]}','','{objXQSSQ[i]["poiRegion"]}','','','{objXQSSQ[i]["poiId"]}','{objXQSSQ[i]["poiBounds"]}','{objXQSSQ[i]["poiLng"]}','{objXQSSQ[i]["poiLat"]}','{objXQSSQ[i]["poiLng"]}','{objXQSSQ[i]["poiLat"]}');commit;end;";
            //    cmd.CommandText = sql;
            //    cmd.ExecuteNonQuery();
            //}
            for (var i = 0; i < objLHSQ.Count; i++)
            {
                OracleCommand cmd = connection.CreateCommand();

                string sql = $"begin insert into LBS_AJ_BUILDING (BUILDING_NUMBER, BUILDING_ADDRESS, BUILDING_X, BUILDING_Y, BUILDING_LNG, BUILDING_LAT, VILLAGE_ID, BUILDING_REGION, BUILDING_BOUNDS, BUILDING_TYPE) values ('{objLHSQ[i]["poiName"]}','{objLHSQ[i]["poiAddress"]}','{objLHSQ[i]["poiLng"]}','{objLHSQ[i]["poiLat"]}','{objLHSQ[i]["poiLng"]}','{objLHSQ[i]["poiLat"]}','{objLHSQ[i]["poiVillage"]}','{objLHSQ[i]["poiRegion"]}','{objLHSQ[i]["poiBounds"]}','{objLHSQ[i]["poiType"]}');commit;end;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            for (var i = 0; i < objLSSQ.Count; i++)
            {
                OracleCommand cmd = connection.CreateCommand();

                string sql = $"begin insert into LBS_AJ_BUILDING (BUILDING_NUMBER, BUILDING_ADDRESS, BUILDING_X, BUILDING_Y, BUILDING_LNG, BUILDING_LAT, VILLAGE_ID, BUILDING_REGION, BUILDING_BOUNDS, BUILDING_TYPE) values ('{objLSSQ[i]["poiName"]}','{objLSSQ[i]["poiAddress"]}','{objLSSQ[i]["poiLng"]}','{objLSSQ[i]["poiLat"]}','{objLSSQ[i]["poiLng"]}','{objLSSQ[i]["poiLat"]}','{objLSSQ[i]["poiVillage"]}','{objLSSQ[i]["poiRegion"]}','{objLSSQ[i]["poiBounds"]}','{objLSSQ[i]["poiType"]}');commit;end;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            connection.Close();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
