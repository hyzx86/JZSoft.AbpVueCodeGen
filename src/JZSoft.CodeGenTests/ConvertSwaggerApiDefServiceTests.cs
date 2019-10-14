﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using JZSoft.CodeGen;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JZSoft.CodeGen.Tests
{
    [TestClass()]
    public class ConvertSwaggerApiDefServiceTests
    {
        [TestMethod()]
        public void ConvertSwaggerApiDefServiceTest()
        {

            //var obj = JsonConvert.DeserializeObject<dynamic>("{\"Tag\":\"Order\",\"ListApiName\":\"/api/services/app/Order/GetListAsync\",\"CreateApiName\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"UpdateApiName\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"DeleteApiName\":\"/api/services/app/Order/CancelOrderAsync\",\"ListApi\":{\"Parameters\":[{\"Name\":\"Name\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"},{\"Name\":\"CustName\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"},{\"Name\":\"PO\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"},{\"Name\":\"FinancialStatusList\",\"Required\":false,\"ObjectType\":\"array\",\"In\":\"query\"},{\"Name\":\"SkipCount\",\"Required\":false,\"ObjectType\":\"integer\",\"Format\":\"int32\",\"In\":\"query\"},{\"Name\":\"MaxResultCount\",\"Required\":false,\"ObjectType\":\"integer\",\"Format\":\"int32\",\"In\":\"query\"},{\"Name\":\"Sorting\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"}],\"Method\":\"get\",\"Path\":\"/api/services/app/Order/GetListAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderGetlistasyncGet\",\"Response\":{\"ObjectRef\":{\"Properties\":[{\"Name\":\"items\",\"ObjectType\":\"OrderDto\",\"IsArray\":true,\"IsComplexModel\":false,\"ObjectRef\":{\"Properties\":[{\"Name\":\"orderName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"orderFinancialStatus\",\"IsArray\":false,\"IsComplexModel\":false,\"ObjectType\":\"enum\",\"ObjectRef\":{\"Items\":{\"Planed\":0,\"Ordered\":1,\"Invoiced\":2,\"Recived\":3,\"Completed\":4,\"Canceled\":5},\"Name\":\"OrderFinancialStatus\"}},{\"Name\":\"poId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"poNumber\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"courierNumber\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"billingDate\",\"Format\":\"date-time\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"description\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"workloadTotal\",\"Format\":\"int32\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"taxRate\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"discont\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"unitPrice\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"OrderDto\",\"ObjectType\":\"object\"}}],\"Name\":\"ListResultDtoOfOrderDto\",\"ObjectType\":\"object\"},\"RetunType\":\"ListResultDtoOfOrderDto\"}},\"CreateApi\":{\"Parameters\":[{\"Name\":\"input\",\"Required\":false,\"RefPath\":\"OrderDto\",\"ObjectRef\":{\"Properties\":[{\"Name\":\"orderName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"orderFinancialStatus\",\"IsArray\":false,\"IsComplexModel\":false,\"ObjectType\":\"enum\",\"ObjectRef\":{\"Items\":{\"Planed\":0,\"Ordered\":1,\"Invoiced\":2,\"Recived\":3,\"Completed\":4,\"Canceled\":5},\"Name\":\"OrderFinancialStatus\"}},{\"Name\":\"poId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"poNumber\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"courierNumber\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"billingDate\",\"Format\":\"date-time\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"description\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"workloadTotal\",\"Format\":\"int32\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"taxRate\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"discont\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"unitPrice\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"OrderDto\",\"ObjectType\":\"object\"},\"ObjectType\":\"enum\",\"In\":\"body\"}],\"Method\":\"post\",\"Path\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderCreateorupdateasyncPost\",\"Response\":{\"RetunType\":\"integer\"}},\"UpdateApi\":{\"Parameters\":[{\"Name\":\"input\",\"Required\":false,\"RefPath\":\"OrderDto\",\"ObjectRef\":{\"Properties\":[{\"Name\":\"orderName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"orderFinancialStatus\",\"IsArray\":false,\"IsComplexModel\":false,\"ObjectType\":\"enum\",\"ObjectRef\":{\"Items\":{\"Planed\":0,\"Ordered\":1,\"Invoiced\":2,\"Recived\":3,\"Completed\":4,\"Canceled\":5},\"Name\":\"OrderFinancialStatus\"}},{\"Name\":\"poId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"poNumber\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"courierNumber\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"billingDate\",\"Format\":\"date-time\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"description\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"workloadTotal\",\"Format\":\"int32\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"taxRate\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"discont\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"unitPrice\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"OrderDto\",\"ObjectType\":\"object\"},\"ObjectType\":\"enum\",\"In\":\"body\"}],\"Method\":\"post\",\"Path\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderCreateorupdateasyncPost\",\"Response\":{\"RetunType\":\"integer\"}},\"DeleteApi\":{\"Parameters\":[{\"Name\":\"input\",\"Required\":false,\"RefPath\":\"EntityDtoOfInt64\",\"ObjectRef\":{\"Properties\":[{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"EntityDtoOfInt64\",\"ObjectType\":\"object\"},\"ObjectType\":\"enum\",\"In\":\"body\"}],\"Method\":\"post\",\"Path\":\"/api/services/app/Order/CancelOrderAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderCancelorderasyncPost\",\"Response\":{}}}");
            //Console.WriteLine(obj);
            var Model = JObject.Parse("{\"Tag\":\"Order\",\"ListApiName\":\"/api/services/app/Order/GetListAsync\",\"CreateApiName\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"UpdateApiName\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"DeleteApiName\":\"/api/services/app/Order/CancelOrderAsync\",\"ListApi\":{\"Parameters\":[{\"Name\":\"Name\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"},{\"Name\":\"CustName\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"},{\"Name\":\"PO\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"},{\"Name\":\"FinancialStatusList\",\"Required\":false,\"ObjectType\":\"array\",\"In\":\"query\"},{\"Name\":\"SkipCount\",\"Required\":false,\"ObjectType\":\"integer\",\"Format\":\"int32\",\"In\":\"query\"},{\"Name\":\"MaxResultCount\",\"Required\":false,\"ObjectType\":\"integer\",\"Format\":\"int32\",\"In\":\"query\"},{\"Name\":\"Sorting\",\"Required\":false,\"ObjectType\":\"string\",\"In\":\"query\"}],\"Method\":\"get\",\"Path\":\"/api/services/app/Order/GetListAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderGetlistasyncGet\",\"Response\":{\"ObjectRef\":{\"Properties\":[{\"Name\":\"items\",\"ObjectType\":\"OrderDto\",\"IsArray\":true,\"IsComplexModel\":false,\"ObjectRef\":{\"Properties\":[{\"Name\":\"orderName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"orderFinancialStatus\",\"IsArray\":false,\"IsComplexModel\":false,\"ObjectType\":\"enum\",\"ObjectRef\":{\"Items\":{\"Planed\":0,\"Ordered\":1,\"Invoiced\":2,\"Recived\":3,\"Completed\":4,\"Canceled\":5},\"Name\":\"OrderFinancialStatus\"}},{\"Name\":\"poId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"poNumber\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"courierNumber\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"billingDate\",\"Format\":\"date-time\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"description\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"workloadTotal\",\"Format\":\"int32\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"taxRate\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"discont\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"unitPrice\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"OrderDto\",\"ObjectType\":\"object\"}}],\"Name\":\"ListResultDtoOfOrderDto\",\"ObjectType\":\"object\"},\"RetunType\":\"ListResultDtoOfOrderDto\"}},\"CreateApi\":{\"Parameters\":[{\"Name\":\"input\",\"Required\":false,\"RefPath\":\"OrderDto\",\"ObjectRef\":{\"Properties\":[{\"Name\":\"orderName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"orderFinancialStatus\",\"IsArray\":false,\"IsComplexModel\":false,\"ObjectType\":\"enum\",\"ObjectRef\":{\"Items\":{\"Planed\":0,\"Ordered\":1,\"Invoiced\":2,\"Recived\":3,\"Completed\":4,\"Canceled\":5},\"Name\":\"OrderFinancialStatus\"}},{\"Name\":\"poId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"poNumber\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"courierNumber\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"billingDate\",\"Format\":\"date-time\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"description\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"workloadTotal\",\"Format\":\"int32\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"taxRate\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"discont\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"unitPrice\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"OrderDto\",\"ObjectType\":\"object\"},\"ObjectType\":\"object\",\"In\":\"body\"}],\"Method\":\"post\",\"Path\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderCreateorupdateasyncPost\",\"Response\":{\"RetunType\":\"integer\"}},\"UpdateApi\":{\"Parameters\":[{\"Name\":\"input\",\"Required\":false,\"RefPath\":\"OrderDto\",\"ObjectRef\":{\"Properties\":[{\"Name\":\"orderName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerName\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"customerId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"orderFinancialStatus\",\"IsArray\":false,\"IsComplexModel\":false,\"ObjectType\":\"enum\",\"ObjectRef\":{\"Items\":{\"Planed\":0,\"Ordered\":1,\"Invoiced\":2,\"Recived\":3,\"Completed\":4,\"Canceled\":5},\"Name\":\"OrderFinancialStatus\"}},{\"Name\":\"poId\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"poNumber\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"courierNumber\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"billingDate\",\"Format\":\"date-time\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"description\",\"ObjectType\":\"string\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"workloadTotal\",\"Format\":\"int32\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"taxRate\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"discont\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"unitPrice\",\"Format\":\"double\",\"ObjectType\":\"number\",\"IsArray\":false,\"IsComplexModel\":false},{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"OrderDto\",\"ObjectType\":\"object\"},\"ObjectType\":\"object\",\"In\":\"body\"}],\"Method\":\"post\",\"Path\":\"/api/services/app/Order/CreateOrUpdateAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderCreateorupdateasyncPost\",\"Response\":{\"RetunType\":\"integer\"}},\"DeleteApi\":{\"Parameters\":[{\"Name\":\"input\",\"Required\":false,\"RefPath\":\"EntityDtoOfInt64\",\"ObjectRef\":{\"Properties\":[{\"Name\":\"id\",\"Format\":\"int64\",\"ObjectType\":\"integer\",\"IsArray\":false,\"IsComplexModel\":false}],\"Name\":\"EntityDtoOfInt64\",\"ObjectType\":\"object\"},\"ObjectType\":\"object\",\"In\":\"body\"}],\"Method\":\"post\",\"Path\":\"/api/services/app/Order/CancelOrderAsync\",\"Tag\":\"Order\",\"OperationId\":\"ApiServicesAppOrderCancelorderasyncPost\",\"Response\":{}}}");
            Console.WriteLine(Model);

        }
        [TestMethod]
        public void Swagger()
        {
            var Model = JObject.Parse("{\"tag\":\"CustPO\",\"ListApi\":{\"path\":\"/api/services/app/CustPO/GetAll\",\"method\":\"get\",\"tag\":\"CustPO\",\"responses\":[{\"key\":\"200\",\"value\":[{\"key\":\"description\",\"value\":\"Success\"},{\"key\":\"schema\",\"value\":[{\"key\":\"$ref\",\"value\":{\"refName\":\"PagedResultDtoOfCustPODto\",\"refData\":[{\"key\":\"type\",\"value\":\"object\"},{\"key\":\"properties\",\"value\":[{\"key\":\"totalCount\",\"value\":[{\"key\":\"format\",\"value\":\"int32\"},{\"key\":\"type\",\"value\":\"integer\"}]},{\"key\":\"items\",\"value\":[{\"key\":\"uniqueItems\",\"value\":false},{\"key\":\"type\",\"value\":\"array\"},{\"key\":\"items\",\"value\":[{\"key\":\"$ref\",\"value\":{\"refName\":\"CustPODto\",\"refData\":[{\"key\":\"type\",\"value\":\"object\"},{\"key\":\"properties\",\"value\":[{\"key\":\"poNumber\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"poAmount\",\"value\":[{\"key\":\"format\",\"value\":\"double\"},{\"key\":\"type\",\"value\":\"number\"}]},{\"key\":\"poDescription\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"id\",\"value\":[{\"key\":\"format\",\"value\":\"int64\"},{\"key\":\"type\",\"value\":\"integer\"}]}]}]}}]}]}]}]}}]}]}],\"parameters\":[[{\"key\":\"name\",\"value\":\"Keyword\"},{\"key\":\"in\",\"value\":\"query\"},{\"key\":\"required\",\"value\":false},{\"key\":\"type\",\"value\":\"string\"}],[{\"key\":\"name\",\"value\":\"KeywordsDict\"},{\"key\":\"in\",\"value\":\"query\"},{\"key\":\"required\",\"value\":false},{\"key\":\"type\",\"value\":\"object\"}],[{\"key\":\"name\",\"value\":\"Sorting\"},{\"key\":\"in\",\"value\":\"query\"},{\"key\":\"required\",\"value\":false},{\"key\":\"type\",\"value\":\"string\"}],[{\"key\":\"name\",\"value\":\"SkipCount\"},{\"key\":\"in\",\"value\":\"query\"},{\"key\":\"required\",\"value\":false},{\"key\":\"type\",\"value\":\"integer\"},{\"key\":\"format\",\"value\":\"int32\"},{\"key\":\"maximum\",\"value\":2147483647},{\"key\":\"minimum\",\"value\":0}],[{\"key\":\"name\",\"value\":\"MaxResultCount\"},{\"key\":\"in\",\"value\":\"query\"},{\"key\":\"required\",\"value\":false},{\"key\":\"type\",\"value\":\"integer\"},{\"key\":\"format\",\"value\":\"int32\"},{\"key\":\"maximum\",\"value\":2147483647},{\"key\":\"minimum\",\"value\":1}]]},\"CreateApi\":{\"path\":\"/api/services/app/CustPO/Create\",\"method\":\"post\",\"tag\":\"CustPO\",\"responses\":[{\"key\":\"200\",\"value\":[{\"key\":\"description\",\"value\":\"Success\"},{\"key\":\"schema\",\"value\":[{\"key\":\"$ref\",\"value\":{\"refName\":\"CustPODto\",\"refData\":[{\"key\":\"type\",\"value\":\"object\"},{\"key\":\"properties\",\"value\":[{\"key\":\"poNumber\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"poAmount\",\"value\":[{\"key\":\"format\",\"value\":\"double\"},{\"key\":\"type\",\"value\":\"number\"}]},{\"key\":\"poDescription\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"id\",\"value\":[{\"key\":\"format\",\"value\":\"int64\"},{\"key\":\"type\",\"value\":\"integer\"}]}]}]}}]}]}],\"parameters\":[[{\"key\":\"name\",\"value\":\"input\"},{\"key\":\"in\",\"value\":\"body\"},{\"key\":\"required\",\"value\":false},{\"key\":\"schema\",\"value\":[{\"key\":\"$ref\",\"value\":{\"refName\":\"CustPODto\",\"refData\":[{\"key\":\"type\",\"value\":\"object\"},{\"key\":\"properties\",\"value\":[{\"key\":\"poNumber\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"poAmount\",\"value\":[{\"key\":\"format\",\"value\":\"double\"},{\"key\":\"type\",\"value\":\"number\"}]},{\"key\":\"poDescription\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"id\",\"value\":[{\"key\":\"format\",\"value\":\"int64\"},{\"key\":\"type\",\"value\":\"integer\"}]}]}]}}]}]]},\"UpdateApi\":{\"path\":\"/api/services/app/CustPO/Update\",\"method\":\"put\",\"tag\":\"CustPO\",\"responses\":[{\"key\":\"200\",\"value\":[{\"key\":\"description\",\"value\":\"Success\"},{\"key\":\"schema\",\"value\":[{\"key\":\"$ref\",\"value\":{\"refName\":\"CustPODto\",\"refData\":[{\"key\":\"type\",\"value\":\"object\"},{\"key\":\"properties\",\"value\":[{\"key\":\"poNumber\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"poAmount\",\"value\":[{\"key\":\"format\",\"value\":\"double\"},{\"key\":\"type\",\"value\":\"number\"}]},{\"key\":\"poDescription\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"id\",\"value\":[{\"key\":\"format\",\"value\":\"int64\"},{\"key\":\"type\",\"value\":\"integer\"}]}]}]}}]}]}],\"parameters\":[[{\"key\":\"name\",\"value\":\"input\"},{\"key\":\"in\",\"value\":\"body\"},{\"key\":\"required\",\"value\":false},{\"key\":\"schema\",\"value\":[{\"key\":\"$ref\",\"value\":{\"refName\":\"CustPODto\",\"refData\":[{\"key\":\"type\",\"value\":\"object\"},{\"key\":\"properties\",\"value\":[{\"key\":\"poNumber\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"poAmount\",\"value\":[{\"key\":\"format\",\"value\":\"double\"},{\"key\":\"type\",\"value\":\"number\"}]},{\"key\":\"poDescription\",\"value\":[{\"key\":\"type\",\"value\":\"string\"}]},{\"key\":\"id\",\"value\":[{\"key\":\"format\",\"value\":\"int64\"},{\"key\":\"type\",\"value\":\"integer\"}]}]}]}}]}]]},\"DeleteApi\":{\"path\":\"/api/services/app/CustPO/Delete\",\"method\":\"delete\",\"tag\":\"CustPO\",\"responses\":[{\"key\":\"200\",\"value\":[{\"key\":\"description\",\"value\":\"Success\"}]}],\"parameters\":[[{\"key\":\"name\",\"value\":\"Id\"},{\"key\":\"in\",\"value\":\"query\"},{\"key\":\"required\",\"value\":false},{\"key\":\"type\",\"value\":\"integer\"},{\"key\":\"format\",\"value\":\"int64\"}]]}}");
            Console.WriteLine(Model);
        }
    }
}