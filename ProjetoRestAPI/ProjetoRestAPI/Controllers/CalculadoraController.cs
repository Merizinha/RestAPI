using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{valor1}/{valor2}")]
        public IActionResult Get(string valor1, string valor2)
        {
            if (IsNumeric(valor1) && IsNumeric(valor2))
            {
                var soma = ConvertToDecimal(valor1) + ConvertToDecimal(valor2);

                return Ok(soma.ToString());
            }


            return BadRequest("Valor inválido");
        }

        [HttpGet("subtracao/{valor1}/{valor2}")]
        public IActionResult GetSub(string valor1, string valor2)
        {
            if (IsNumeric(valor1) && IsNumeric(valor2))
            {
                var sub = ConvertToDecimal(valor1) - ConvertToDecimal(valor2);

                return Ok(sub.ToString());
            }


            return BadRequest("Valor inválido");
        }

        [HttpGet("multiplicacao/{valor1}/{valor2}")]
        public IActionResult GetMulti(string valor1, string valor2)
        {
            if (IsNumeric(valor1) && IsNumeric(valor2))
            {
                var multi = ConvertToDecimal(valor1) * ConvertToDecimal(valor2);

                return Ok(multi.ToString());
            }


            return BadRequest("Valor inválido");
        }

        [HttpGet("divisao/{valor1}/{valor2}")]
        public IActionResult GetDiv(string valor1, string valor2)
        {
            if (IsNumeric(valor1) && IsNumeric(valor2))
            {
                var div = ConvertToDecimal(valor1) / ConvertToDecimal(valor2);

                return Ok(div.ToString());
            }


            return BadRequest("Valor inválido");
        }

        [HttpGet("media/{valor1}/{valor2}")]
        public IActionResult GetMedia(string valor1, string valor2)
        {
            if (IsNumeric(valor1) && IsNumeric(valor2))
            {
                var media = (ConvertToDecimal(valor1) + ConvertToDecimal(valor2)) / 2;

                return Ok(media.ToString());
            }


            return BadRequest("Valor inválido");
        }




        private decimal ConvertToDecimal(string valor1)
        {
            decimal decimalValue;
            if(decimal.TryParse(valor1, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string valor1)
        {
            double number;
            bool isnumber = double.TryParse(valor1, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isnumber;
        }
    }
}
