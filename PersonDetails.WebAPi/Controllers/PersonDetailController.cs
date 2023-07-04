using Microsoft.AspNetCore.Mvc;
using PersonDetails.WebAPi.DataAccessLayer;
using PersonDetails.WebAPi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace PersonDetails.WebAPi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonDetailController : Controller
    {
        private readonly PersonDetailDBContext persondetailDBContext1;

        public PersonDetailController(PersonDetailDBContext persondetailDBContext1)
        {
            this.persondetailDBContext1 = persondetailDBContext1;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonDetail()
        {
            return Ok(await persondetailDBContext1.PersonDetails.ToListAsync());
        }

        [HttpGet]
        [Route("{ToFloor}")]
        public Task<IActionResult> GetPersonToFloor([FromRoute] byte ToFloor)
        {
            return Task.FromResult<IActionResult>(Ok(persondetailDBContext1.PersonDetails.Where(x => x.ToFloor.Equals(ToFloor))));
        }

        [HttpPost]
        public async Task<IActionResult> InsertPersonDetail(InsertPersonDetailRequest insertPersonDetailRequest)
        {

            if (insertPersonDetailRequest != null)
            {
                PersonDetail persondetail = new PersonDetail();

                persondetail.PersonId = new Guid();
                persondetail.Weight = insertPersonDetailRequest.Weight;
                persondetail.FromFloor = insertPersonDetailRequest.FromFloor;
                persondetail.ToFloor = insertPersonDetailRequest.ToFloor;


                await persondetailDBContext1.PersonDetails.AddAsync(persondetail);
                await persondetailDBContext1.SaveChangesAsync();

                return Ok(persondetail);
            }
            else
            {
                return BadRequest("PersonDetail is not available");
            }
        }
        [HttpPut]
        [Route("{id:guid}")] // Curly braces - Possible omission.
        public async Task<IActionResult> UpdatePersonDetail([FromRoute] Guid id, UpdatePersonDetailRequest updatePersonDetailRequest)
        {


            if (updatePersonDetailRequest != null)
            {
                var persondetailResult = await persondetailDBContext1.PersonDetails.FirstOrDefaultAsync(x => x.PersonId.Equals(id));

                if (persondetailResult != null)
                {

                    persondetailResult.Weight = updatePersonDetailRequest.Weight;
                    persondetailResult.FromFloor = updatePersonDetailRequest.FromFloor;
                    persondetailResult.ToFloor = updatePersonDetailRequest.ToFloor;

                    persondetailDBContext1.PersonDetails.Update(persondetailResult);

                    await persondetailDBContext1.SaveChangesAsync();
                }

                return Ok(persondetailResult);
            }
            else
            {
                return BadRequest("Employee is not available");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")] // Curly braces - Possible omission.
        public async Task<IActionResult> DeletePersonDetail([FromRoute] Guid id)
        {
            // LINQ Syntax to search an element from the list of items
            var persondetailResult = persondetailDBContext1.PersonDetails.FirstOrDefault(x => x.PersonId.Equals(id));

            if (persondetailResult != null)
            {
                persondetailDBContext1.PersonDetails.Remove(persondetailResult);
                await persondetailDBContext1.SaveChangesAsync();
            }

            return Ok(persondetailResult);
        }

        [HttpGet]
        [Route("/getSum")]
        public async Task<IActionResult> SumPersonWeight()
        {
            // LINQ Syntax to search an element from the list of items
            //var persondetailResult = persondetailDBContext1.PersonDetails.AsEnumerable().Sum(row => row.Field<int>("Weight")); ;

            //DataTable dt = persondetailDBContext1.PersonDetails.Tables["Customer"];


            var totalweight = await persondetailDBContext1.PersonDetails.SumAsync(x => x.Weight);
            //Console.WriteLine(totalweight.ToString());

            //var persondetailResult = Convert.ToDecimal(dt.Compute("SUM(Weight)", string.Empty));


            return Ok(totalweight);
        }

    }
}
