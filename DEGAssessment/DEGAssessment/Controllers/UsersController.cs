using DEGAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DEGAssessment.Controllers
{
    public class UsersController : ApiController
    {
        
        List<Users> user = new List<Users>
        {
            new Users { id = 1, firstName = "Mark",  lastName= "Greyson"},
            new Users { id = 2, firstName = "Nolan", lastName = "Greyson" },
            new Users { id = 3, firstName = "sam", lastName = "Thompson"},
            new Users { id = 4, firstName = "Ahmed", lastName = "hussain"},
            new Users { id = 5, firstName = "Alex", lastName = "furguson"},
            new Users { id = 6, firstName = "Patrick", lastName = "samson"},
            new Users { id = 7, firstName = "joshua", lastName = "johnson"},
            new Users { id = 8, firstName = "Hassan", lastName = "turk"},
            new Users { id = 9, firstName = "Patrick", lastName = "samson"},
            new Users { id = 10, firstName = "Mohamed", lastName = "Ali"},

        };

        public IHttpActionResult Get(string sort = "id")
        {
            // Convert data source into IQueryable
            // ApplySort method needs IQueryable data source hence we need to convert it
            // Or we can create ApplySort to work on list itself
            var data = user.AsQueryable();

            // Apply sorting
            data = data.ApplySort(sort);

            // Return response
            return Ok(data);
        }

        public IHttpActionResult Get(int Id)
        {
            try
            {
                var match = user.FirstOrDefault(e => e.id == Id);
                if (match != null)
                {
                    return Ok(match);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        


    }
}
