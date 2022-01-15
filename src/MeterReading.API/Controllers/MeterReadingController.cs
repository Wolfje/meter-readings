using MeterReading.Application.Common.Exceptions;
using MeterReading.Application.Features.Readings.Commands.CreateReading;
using MeterReading.Application.Features.Readings.Commands.UploadReadings;
using MeterReading.Application.Features.Readings.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MeterReading.API.Controllers
{
    [ApiController]
    public class MeterReadingController : ApiControllerBase
    {

        [HttpPost("/meter-reading-upload")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<MeterReadingsVM>> Post(IFormFile uploadedFile)
        {

            var results = new MeterReadingsVM();


            var fileContent = await Mediator.Send(new UploadReadingCommand { File = uploadedFile }).ConfigureAwait(false);


            foreach (var meterReading in fileContent)
            {
                try
                {
                    var meterReadingId = await Mediator.Send(new CreateReadingCommand { Reading = meterReading }).ConfigureAwait(false);

                    results.Success++;
                    results.Results.Add(meterReading);
                }
                catch (AlreadySubmittedException)
                {
                    results.AlreadySubmittedRecords++;
                }
                catch
                {
                    results.InvalidRecords++;
                }
            }

            return Ok(results);
        }

    }
}
