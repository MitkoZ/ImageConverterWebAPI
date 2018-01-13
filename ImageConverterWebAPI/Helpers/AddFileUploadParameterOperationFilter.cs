using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ImageConverterWebAPI.Helpers
{
    public class AddFileUploadParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            operation.consumes.Add("application/form-data");
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            operation.parameters.Add(new Parameter
            {
                name = "image",
                @in = "formData",
                required = true,
                type = "file"
            });
        }
    }
}