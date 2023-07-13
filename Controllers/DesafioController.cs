using DesafioPorter.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DesafioPorter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DesafioController : ControllerBase
    {

        /* Implemente uma função que recebe um número inteiro e retorne uma string
         * com a representação por extenso desse número.
         * Exemplo: 123 -> "cento e vinte e três".
         */
        [HttpGet(Name = "NumberToWords")]
        public ActionResult<string> NumberToWords(int number)
        {
            throw new NotImplementedException();
        }

        /* Implemente uma função que recebe um array de inteiros e retorne a soma
         * desses números. O array pode ter até 1 milhão de números.
         */
        [HttpPost(Name = "ArraySum")]
        public ActionResult<string> ArraySum(int[] numbers)
        {
            // Easy way, not optimal
            // var sum = numbers.Sum();

            // My way
            var sum = new Calculator().SumArray(numbers);

            return sum.ToString();
        }

        /* Implemente uma função que recebe uma string contendo uma expressão
         * matemática simples (sem parênteses) e retorne o resultado dessa expressão.
         * Exemplo: "2 + 3 * 5" -> 17.
         */
        [HttpGet(Name = "EvaluateExpression")]
        public ActionResult<int> EvaluateExpression(string expression)
        {
            throw new NotImplementedException();
        }

        /* Implemente uma função que recebe uma lista de objetos e retorne uma
         * nova lista apenas com os objetos únicos, ou seja, sem repetições.
         */
        [HttpPost(Name = "UniqueList")]
        public ActionResult<List<object>> UniqueList(List<object> objects)
        {
            //Probably a simple HashSet would do, but the object list gets converted from a JSON, and thats chage the HashCode. 
            //to resolve this it was created an EqualityComparer for serializing the object and then get the hashCode from the string

            var ec = new ObjectSerializedEqualityComparer();
            var hash = new HashSet<object>(ec);
            foreach (var obj in objects) {
                hash.Add(obj);
            }

            return hash.ToList();
        }

    }

  
}
