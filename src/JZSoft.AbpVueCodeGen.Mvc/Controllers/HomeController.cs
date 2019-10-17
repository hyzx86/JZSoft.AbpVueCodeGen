﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JZSoft.AbpVueCodeGen.Mvc.Models;
using Newtonsoft.Json.Linq;

namespace JZSoft.AbpVueCodeGen.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public static string ApiJsonUrl { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult TestJsonPath(JsonPathInput input)
        {
            try
            {
                JToken token = JToken.Parse(input.Json);
                return new JsonResult(token.SelectToken(input.JsonPath));
            }
            catch (Exception)
            {
                throw new Exception("JsonPath Error");
            }
        }

        public IActionResult GetPartCode(PartCodeInnput input)
        {
            Response.ContentType = "text/plian;charset=utf-8";
            try
            {
                var result = GetPartResult(input);
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception("JsonPath Error"+ ex.Message);
            }
        }
        public JsonResult TryGetProps(JsonPathInput input)
        {
            try
            {
                PartCodeResult result = GetPartResult(input);
                return new JsonResult(result);
            }
            catch (Exception)
            {
                return new JsonResult("Convert Error");
            }
        }

        private static PartCodeResult GetPartResult(JsonPathInput input)
        {
            JToken token = JToken.Parse(input.Json);
            var paramDefList = new List<ParamDef>();
            var ErrorCount = 0;
            foreach (var item in token.SelectToken(input.JsonPath))
            {
                try
                {
                    var def = new ParamDef();
                    GetProperties(item, def);
                    paramDefList.Add(def);
                }
                catch { ErrorCount++; }
            }
            var result = new PartCodeResult
            {
                Properties = paramDefList,
                ErrorCount = ErrorCount
            };
            return result;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult GenCode(GenCodeConfigInput input)
        {
            if (string.IsNullOrEmpty(input.JsonData))
            {
                return View();
            }
            var ErrorDict = new Dictionary<string, List<string>>();
            var output = GetConfig(input, ErrorDict);
            ViewBag.ErrorDict = ErrorDict;
            Response.ContentType = "text/plian;charset=utf-8";
            return View(output);
        }



        public GenCodeOutput GetConfig(GenCodeConfigInput input, Dictionary<string, List<string>> ErrorDict)
        {

            var Model = JObject.Parse(input.JsonData);
            GenCodeOutput genCodeConfig = new GenCodeOutput();
            genCodeConfig.Tag = Model["tag"].ToString();
            genCodeConfig.ServiceClassName = genCodeConfig.Tag + "ServiceProxy";

            List<string> dtoNames = new List<string>();
            dtoNames.Add(genCodeConfig.ServiceClassName);

            #region list
            var listApi = new ListApi();
            if (!string.IsNullOrEmpty(input.ListDtoName))
            {
                listApi.ListResultDtoName = input.ListDtoName;
            }
            else
            {
                listApi.ListResultDtoName = Model.SelectToken("$.ListApi.responses[0].value[1].value[0].value.refName").ToString();
            }
            var ListApiName = Model.SelectToken("$.ListApi.path").ToString();
            if (!string.IsNullOrEmpty(ListApiName))
            {
                ListApiName = ListApiName.Split('/', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            }
            listApi.JsMethodName = ListApiName;
            dtoNames.Add(listApi.ListResultDtoName);
            genCodeConfig.ListApi = listApi;

            listApi.ListResultDtoItemName = Model.SelectToken("$.ListApi.responses[0].value[1].value[0].value.refData[1].value[1].value[2].value[0].value.refName").ToString();
            if (!string.IsNullOrEmpty(input.ListItemsDtoName))
            {
                listApi.ListResultDtoItemName = input.ListItemsDtoName;
            }
            genCodeConfig.ListApi = listApi;
            dtoNames.Add(listApi.ListResultDtoItemName);


            JToken ListReturnPropertiesDef = Model.SelectToken("$.ListApi.responses[0].value[1].value[0].value.refData[1].value[1].value[2].value[0].value.refData[1].value");

            if (!string.IsNullOrEmpty(input.ListPropertiesJsonPath))
            {
                ListReturnPropertiesDef = Model.SelectToken(input.ListPropertiesJsonPath);
            }
            if (ListReturnPropertiesDef != null)
            {

                foreach (var item in ListReturnPropertiesDef)
                {
                    ParamDef paramDef = new ParamDef();
                    try
                    {
                        GetProperties(item, paramDef);
                    }
                    catch
                    {
                        PushDict(ErrorDict, "ListReturnPropertiesDef", item.ToString());
                        continue;
                    }
                    genCodeConfig.ListApi.Properties.Add(paramDef);
                }
            }


            var SelectParams = Model.SelectToken("ListApi.parameters");
            if (!string.IsNullOrEmpty(input.ListParamsJsonPath))
            {
                SelectParams = Model.SelectToken(input.ListParamsJsonPath);
            }
            foreach (var item in SelectParams)
            {
                ParamDef paramDef = new ParamDef();
                try
                {
                    GetProperties(item, paramDef);
                }
                catch
                {
                    PushDict(ErrorDict, "SelectParams", item.ToString());
                    continue;
                }
                genCodeConfig.ListApi.Properties.Add(paramDef);
            }

            #endregion

            var EnableCreate = Model["CreateApi"] != null;
            if (EnableCreate)
            {
                var createApi = new Createapi();
                var CreateDtoName = Model.SelectToken("$.CreateApi.parameters[0][3].value[0].value.refName").ToString();
                if (!string.IsNullOrEmpty(input.CreateDtoName))
                {
                    CreateDtoName = input.CreateDtoName;
                }
                createApi.RequestDtoName = CreateDtoName;

                var CreateDtoDef = Model.SelectToken("$.CreateApi.parameters[0][3].value[0].value.refData[1].value");
                if (!string.IsNullOrEmpty(input.CreateParamsJsonPath))
                {
                    CreateDtoDef = Model.SelectToken(input.CreateParamsJsonPath);
                }
                foreach (var item in CreateDtoDef)
                {
                    ParamDef paramDef = new ParamDef();
                    try
                    {
                        GetProperties(item, paramDef);
                    }
                    catch
                    {
                        PushDict(ErrorDict, "CreateDtoDef", item.ToString());
                        continue;
                    }
                    createApi.Properties.Add(paramDef);
                }
                var CreateApiName = Model["CreateApi"]["path"].ToString().Split('/', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                createApi.JsMethodName = CreateApiName.ToLowerStart();
                dtoNames.Add(createApi.RequestDtoName);
                genCodeConfig.CreateApi = createApi;
            }

            var EnableUpdate = Model["UpdateApi"] != null;
            if (EnableUpdate)
            {
                Updateapi updateapi = new Updateapi();
                var UpdateDtoDef = Model.SelectToken("$.UpdateApi.parameters[0][3].value[0].value.refData[1].value");
                if (!string.IsNullOrWhiteSpace(input.UpdateParamsJsonPath))
                {
                    UpdateDtoDef = Model.SelectToken(input.UpdateParamsJsonPath);
                }
                foreach (var item in UpdateDtoDef)
                {
                    ParamDef paramDef = new ParamDef();
                    try
                    {
                        paramDef.Type = item.FirstOrDefault(o => o["key"].ToString() == "type")["value"].ToString();
                        paramDef.Format = item.FirstOrDefault(o => o["key"].ToString() == "format") == null ?
                            string.Empty :
                            item.FirstOrDefault(o => o["key"].ToString() == "format")["value"].ToString();
                    }
                    catch
                    {
                        PushDict(ErrorDict, "CreateDtoDef", item.ToString());
                        continue;
                    }
                    updateapi.Properties.Add(paramDef);
                }

                var UpdateDtoName = Model.SelectToken("$.UpdateApi.parameters[0][3].value[0].value.refName").ToString();
                if (!string.IsNullOrWhiteSpace(input.UpdateDtoName))
                {
                    dtoNames.Add(UpdateDtoName);
                    updateapi.RequestDtoName = UpdateDtoName;
                }
                var UpdateApiName = Model["UpdateApi"]["path"].ToString().Split('/', StringSplitOptions.RemoveEmptyEntries).Last();
                updateapi.JsMethodName = UpdateApiName.ToLowerStart();
                genCodeConfig.UpdateApi = updateapi;
            }

            var EnableDelete = Model["DeleteApi"] != null;
            if (EnableDelete)
            {
                Deleteapi deleteapi = new Deleteapi();
                var DeleteApiName = Model["DeleteApi"]["path"].ToString().Split('/', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
                deleteapi.JsMethodName = DeleteApiName.ToLowerStart();
                genCodeConfig.DeleteApi = deleteapi;
            }

            genCodeConfig.ImportClassNames = dtoNames;

            return genCodeConfig;
        }

        private static void GetProperties(JToken item, ParamDef paramDef)
        {
            paramDef.Name = item["key"].ToString();
            paramDef.Type = item["value"].FirstOrDefault(o => o["key"].ToString() == "type")["value"].ToString();
            if (item["value"].Any(o => o["key"].ToString() == "format"))
            {
                paramDef.Format = item["value"].FirstOrDefault(o => o["key"].ToString() == "format")["value"].ToString();
            }
        }

        private void PushDict(Dictionary<string, List<string>> dict, string key, string value)
        {
            var list = new List<string>();
            if (dict.ContainsKey(key))
            {
                list = dict[key];
            }
            list.Add(value.ToString());
            dict[key] = list;
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
