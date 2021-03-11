using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fistNumber}/{secondNumber}")]
        public IActionResult sum(string fistNumber, string secondNumber)
        {
            if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Impult");
        }
               
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isnumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isnumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue)) 
            {
                return decimalValue;
            }
            return 0;
        }   

    }
}
