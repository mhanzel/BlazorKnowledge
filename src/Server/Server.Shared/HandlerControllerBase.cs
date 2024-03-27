using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Server.Shared;

public abstract class HandlerControllerBase : ControllerBase
{
    protected async Task<object> ExecuteAsync(Func<object, Task<object>>? method, object parameter)
    {
        var returlResult = StatusCode((int)StatusCodesEnum.InternalServerError, null);
        
        try
        {
            if (method == null) throw new ArgumentNullException("Funkcja wykonawcza nie istnieje.");

            var result = await method.Invoke(parameter);
            returlResult = StatusCode((int)StatusCodesEnum.OK, result);
        }
        catch (ArgumentNullException ex)
        {
            //TODO Zmodyfikować
            return StatusCode((int)StatusCodesEnum.NoContent, ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode((int)StatusCodesEnum.BadRequest, ex.Message);
        }
        catch (TaskCanceledException ex)
        {
            //TODO Zmodyfikować
            return StatusCode((int)StatusCodesEnum.RequestTimeout, ex.Message);
        }
        catch (OperationCanceledException ex)
        {
            //TODO Zmodyfikować
            return StatusCode((int)StatusCodesEnum.GatewayTimeout, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode((int)StatusCodesEnum.InternalServerError, ex.Message);
        }

        return returlResult;

    }
}
