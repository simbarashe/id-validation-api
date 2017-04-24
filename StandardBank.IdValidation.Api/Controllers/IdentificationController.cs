using StandardBank.IdValidation.Api.Models;
using StandardBank.IdValidation.Core.Entities;
using StandardBank.IdValidation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace StandardBank.IdValidation.Api.Controllers
{
    /// <summary>
    /// API for Validating South African Identification Numbers
    /// </summary>
    [RoutePrefix("api/identification")]
    public class IdentificationController : ApiController
    {
        private readonly IIdentificationService _identificationService;
        public IdentificationController(IIdentificationService identificationService)
        {
            _identificationService = identificationService;
        }

        /// <summary>
        /// Action for validating a single identification number
        /// </summary>
        /// <param name="id">specific identification number to be validated</param>
        /// <returns></returns>
        [HttpGet]
        [Route("validate/{id}")]
        [ResponseType(typeof(IdentificationDto))]
        public IHttpActionResult Validate(string id)
        {
            try
            {
                string validationMessage;
                var identification = _identificationService.Validate(id, out validationMessage);
                if (!string.IsNullOrEmpty(validationMessage))
                    return BadRequest(validationMessage);
                var identificationDto = AutoMapperConfig.Map<IdentificationDto,Identification>(identification);
                return Ok(identificationDto);
            }
            catch (Exception exception)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception.Message);
                throw new HttpResponseException(response);
            }
        }

       

    }
}