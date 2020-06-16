using System.IO;
using System.Data;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc; 
using appointmentControl.Backend.Model;
using appointmentControl.Backend.BussinessLogic; 
using appointmentControl.Backend.Extender;
using static appointmentControl.Backend.Model.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
namespace appointmentControl.Backend.WepApi
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicalServiceController : Controller
    {
        private IConfiguration configuration;
        public MedicalServiceController(IConfiguration iConfiguration)
        {
            configuration = iConfiguration;
        }
        #region Region [Methods] 

        [Route("List")]
        [HttpPost]
        public async Task<IActionResult> List([FromBody] Model.Medical_Service model)
        {
            try
            {
                var message = new Message();
                message.BusinessLogic = configuration.GetValue<string>("AppSettings:BusinessLogic:Medical_Service");
                message.Connection = configuration.GetValue<string>("ConnectionStrings:appointmentControl");
                message.Operation = Operation.List;
                message.MessageInfo = model.SerializeObject();
                using (var businessLgic = new DoWorkService())
                {
                    var result = await businessLgic.DoWork(message);
                    if (result.Status == Status.Failed)
                    {
                        return BadRequest(result.Result);
                    }
                    var list = result.DeSerializeObject<IEnumerable<Model.Medical_Service>>(); 
                    return Ok(list);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.Ambiguous, new { ex = ex, param = model });
            }
        }
        [Route("Get")]
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] Model.Medical_Service model)
        {
            try
            {
                var message = new Message();
                message.BusinessLogic = configuration.GetValue<string>("AppSettings:BusinessLogic:Medical_Service");
                message.Connection = configuration.GetValue<string>("ConnectionStrings:appointmentControl");
                message.Operation = Operation.Get;
                message.MessageInfo = model.SerializeObject();
                using (var businessLgic = new DoWorkService())
                {
                    var result = await businessLgic.DoWork(message);
                    if (result.Status == Status.Failed)
                    {
                        return BadRequest(result.Result);
                    }
                    var resultModel = result.DeSerializeObject<Model.Medical_Service>(); 
                    return Ok(resultModel);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.Ambiguous, new { ex = ex, param = model });
            }
        }
        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Model.Medical_Service model)
        {
            try
            {
                var message = new Message();
                message.BusinessLogic = configuration.GetValue<string>("AppSettings:BusinessLogic:Medical_Service");
                message.Connection = configuration.GetValue<string>("ConnectionStrings:appointmentControl");
                message.Operation = Operation.Save;
                message.MessageInfo = model.SerializeObject();
                using (var businessLgic = new DoWorkService())
                {
                    var result = await businessLgic.DoWork(message);
                    if (result.Status == Status.Failed)
                    {
                        return BadRequest(result.Result);
                    }
                    var resultModel = result.DeSerializeObject<Model.Medical_Service>(); 
                    return Ok(resultModel);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.Ambiguous, new { ex = ex, param = model });
            }
        }
        #endregion Region [Methods]
    }
}
