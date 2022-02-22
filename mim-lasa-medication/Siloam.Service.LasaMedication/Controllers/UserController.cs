using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Hub;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModels;
using Siloam.System.Data;
using Siloam.System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Controllers
{
	public class UserController : BaseController
	{
		private readonly IHubContext<MessageHub> messageHubContext;

		public UserController(IUnitOfWork unitOfWork, IHubContext<MessageHub> _messageHubContext) : base(unitOfWork)
		{
			messageHubContext = _messageHubContext;
		}

        [HttpPost("getdatauserlogin")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ViewLogin>>), 200)]
        public IActionResult GetData_user_login([FromBody]ParamLogin paramLogin)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_MS_user().GetData_user_Login(paramLogin);
                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ViewLogin>>("Get Data Login", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                else
                {
                    //Exception ex = new Exception();
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no application data available", total);
                }
            }
            catch (Exception exx)
            {
                int exCode = exx.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, exx.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
                }
            }

            return HttpResponse(HttpResults);
        }
    }
}
