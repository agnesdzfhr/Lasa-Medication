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
	public class LasaController : BaseController
	{
		private readonly IHubContext<MessageHub> messageHubContext;

		public LasaController(IUnitOfWork unitOfWork, IHubContext<MessageHub> _messageHubContext) : base(unitOfWork)
		{
			messageHubContext = _messageHubContext;
		}

        [HttpGet("getalldatalasa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ViewLasa>>), 200)]
        public IActionResult GetAllData_Lasa()
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_lasa().GetAllData_lasa();
                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ViewLasa>>("Get All Data Lasa", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
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

        [HttpGet("getdatalasabyId/{salesitemid}")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ViewLasa>>), 200)]
        public IActionResult GetData_lasa_byID([FromRoute]Int64 SalesItemId)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_lasa().GetData_lasa_byID(SalesItemId);

                if (data != null)
                {
                    HttpResults = new ResponseData<IEnumerable<ViewLasa>>("Get Data Lasa By ID", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                else
                {
                    //Exception ex = new Exception();
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no data lasa available", total);
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

        [HttpPost("postlasa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ResponseLasa>>), 200)]
        public IActionResult PostDataLasa([FromBody]ParamLasa paramLasa)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_lasa().PostData_lasa(paramLasa);
                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ResponseLasa>>("Get Data Login", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
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
