﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JZSoft.AbpVueCodeGen.Mvc.Models
{
    public class JsonPathInput
    {
        public string Json { get; set; }
        public string JsonPath { get; set; }
    }
    public class PartCodeInnput : JsonPathInput
    {
        public TemplateType TemplateName { get; set; }
    }

    public enum TemplateType
    {
        ListItem, 
        QueryParamsDef,
        QueryParamsQueryCode,
        FormItems
    }
}
