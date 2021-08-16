using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Filters
{
    public class ODataFeatureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var odataFeature = context.HttpContext.ODataFeature();
            if (odataFeature != null && context.Result is OkObjectResult objectResult)
            {
                if (odataFeature.TotalCount != null)
                {
                    objectResult.Value = new { Count = odataFeature.TotalCount, objectResult.Value };
                    context.Result = objectResult;
                    context.HttpContext.Response.Headers.Add("$odatacount", odataFeature.TotalCount.ToString());
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
