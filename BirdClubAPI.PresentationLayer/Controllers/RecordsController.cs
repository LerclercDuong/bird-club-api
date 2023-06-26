﻿
using BirdClubAPI.BusinessLayer.Services.Record;
using BirdClubAPI.Domain.DTOs.Request.Record;
using BirdClubAPI.Domain.DTOs.View.Record;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BirdClubAPI.PresentationLayer.Controllers
{
    [Route("api/v1/records")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }


        /// <summary>
        /// APi lấy list records
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<RecordViewModel>> GetRecords()
        {
            var response = _recordService.GetRecord();
            if (response.Key.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return NotFound(response.Key);
            }
            return Ok(response.Value);
        }

        /// <summary>
        /// APi lấy list records của 1 member
        /// </summary>
        /// <returns></returns>
        [HttpGet("by-member/{memberId}")]
        public ActionResult<List<RecordViewModel>> GetRecordsOfMember(int memberId)
        {
            var response = _recordService.GetRecordsOfMember(memberId);
            if (response.Key.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return NotFound(response.Key);
            }
            return Ok(response.Value);
        }

        /// <summary>
        /// API thêm chim của 1 member 
        /// </summary>
        [HttpPost]
        public IActionResult AddRecord(AddRecordRequestModel requestModel)
        {
            var result = _recordService.AddRecord(requestModel);
            if (result.Key.StatusCode.Equals(HttpStatusCode.InternalServerError))
            {
                return BadRequest(result.Key);
            }
            return CreatedAtAction("AddRecord", result.Key);
        }
    }
}
