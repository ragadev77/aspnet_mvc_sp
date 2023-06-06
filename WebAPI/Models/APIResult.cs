using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace WebAPI.Models
{
    public class APIResult
    {

        public string GetMessage(string code)
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("apimessage.json");

            var config = builder.Build();
            return config.GetSection(code).Value.ToString();
        }

        public JsonArray convertDynamicToJArray(List<dynamic> list)
        {
            var jsonObject = new JsonObject();
            dynamic data = jsonObject;
            data.Lists = new JsonArray() as dynamic;
            dynamic detail = new JsonObject();
            foreach (dynamic dr in list)
            {
                detail = new JsonObject();
                foreach (var pair in dr)
                {
                    detail.Add(pair.Key, pair.Value);
                }
                data.Lists.Add(detail);
            }
            return data.Lists;
        }

        public JsonObject HTTPResponseNoDataFound()
        {
            var retVal = new JsonObject();

            retVal.Add("status", this.GetMessage("api_output_ok"));
            retVal.Add("message", this.GetMessage("data_not_found"));

            return retVal;
        }

        public JsonObject HTTPResponseSaveSuccess()
        {
            var retVal = new JsonObject();
            retVal.Add("status", this.GetMessage("api_output_ok"));
            retVal.Add("message", this.GetMessage("save_success"));

            return retVal;
        }

        public JsonObject HTTPResponseUpdateSuccess()
        {
            var retVal = new JsonObject();
            retVal.Add("status", this.GetMessage("api_output_ok"));
            retVal.Add("message", this.GetMessage("update_success"));

            return retVal;
        }

        public JsonObject HTTPResponseDeleteSuccess()
        {
            var retVal = new JsonObject();
            retVal.Add("status", this.GetMessage("api_output_ok"));
            retVal.Add("message", this.GetMessage("delete_success"));

            return retVal;
        }
    }
}
