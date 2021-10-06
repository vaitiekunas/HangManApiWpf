using HangManApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangManApi.Controllers
{

    [ApiController]
    [Route(template: "[controller]")]
    public class RecordsController : Controller
    {
        private IDataAccess _dataAccess;
        public RecordsController(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        [HttpPost("AddRecord")]
        public IActionResult RecordAdd([FromBody] Record record)
        {
            _dataAccess.AddRecord(record);
            return Ok();
        }

        [HttpGet("ReadRecord")]
        public IActionResult RecordGet()
        {
            var recordArray = _dataAccess.GetRecords(null);
            var records = recordArray.Select(x => x.UserPoints).ToList();
            return Ok(records);
        }
    }
}