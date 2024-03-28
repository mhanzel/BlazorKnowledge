using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Shared;

public abstract class HandlerControllerBase : ControllerBase
{
    protected async Task<ActionResult<T>> ExecuteAsync<T>(Func<Task<T>>? method)
    {      
        try
        {
            if (method == null) throw new ArgumentNullException("Funkcja wykonawcza nie istnieje.");

            var result = await method.Invoke();

            return StatusCode((int)StatusCodesEnum.OK, result);
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
    }
}
