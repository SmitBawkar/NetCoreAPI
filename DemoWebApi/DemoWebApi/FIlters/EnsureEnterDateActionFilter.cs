﻿using DemoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.FIlters
{
    public class EnsureEnterDateActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["Ticket"] as Ticket;

            if (ticket != null && !ticket.EnterDate.HasValue)
            {
                context.ModelState.AddModelError("EnterDate","EnterDate is required");
                context.Result = new BadRequestObjectResult(context.ModelState); //Short circuiting;
            }
        }
    }
}
