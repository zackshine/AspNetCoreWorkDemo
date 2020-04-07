using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3API.Filters
{


    //public interface IActionConstraint : IActionConstraintMetadata
    //{
    //    /// <summary>
    //    /// The constraint order.
    //    /// </summary>
    //    /// <remarks>
    //    /// Constraints are grouped into stages by the value of <see cref="Order"/>. See remarks on
    //    /// <see cref="IActionConstraint"/>.
    //    /// </remarks>

    //    int Order { get; }
    //    /// <summary>
    //    /// Determines whether an action is a valid candidate for selection.
    //    /// </summary>
    //    /// <param name="context">The <see cref="ActionConstraintContext"/>.</param>
    //    /// <returns>True if the action is valid for selection, otherwise false.</returns>
    //    bool Accept(ActionConstraintContext context);
    //}

    public class RequiredFromQueryActionConstraint : IActionConstraint
    {
        private readonly string _parameter;

        public RequiredFromQueryActionConstraint(string parameter)
        {
            _parameter = parameter;
        }

        public int Order => 999;
        public bool Accept(ActionConstraintContext context)
        {
            if (!context.RouteContext.HttpContext.Request.Query.ContainsKey(_parameter))
            {
                return false;
            }

            return true;
        }
    }

    public class RequiredFromQueryAttribute : FromQueryAttribute, IParameterModelConvention
    {
        public void Apply(ParameterModel parameter)
        {
            if (parameter.Action.Selectors != null && parameter.Action.Selectors.Any())
            {
                parameter.Action.Selectors.Last().ActionConstraints.Add(new RequiredFromQueryActionConstraint(parameter.BindingInfo?.BinderModelName ?? parameter.ParameterName));
            }
        }
    }
}
