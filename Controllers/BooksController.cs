using Sample.API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Sample.API.Controllers
{
    public class BooksController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Rahul()
        {
            var response = new ResponseDto
            {
                BookId = 1,
                Title = "Sample book",
                Description = "Description",
                Authors = new List<Author> {
                    new Author {
                        AuthorId = 1,
                        FirstName = "Rahul",
                        LastName = "Sen",
                        Email = "rsen253@gmail.com",
                        DOB = new DateTime(1980,01,01)
                    },
                    new Author {
                        AuthorId = 2,
                        FirstName = "Rahul2",
                        LastName = "Sen2",
                        Email = "rsen2523@gmail.com",
                        DOB = new DateTime(1980,01,01)
                    }
                },
                Tags = new List<Tags>
                {
                    new Tags
                    {
                        Name = "Test1",
                        TagId = 1,
                    },
                    new Tags
                    {
                        Name = "Test2",
                        TagId = 2,
                    }
                }
            };

            return Ok(response);
        }
    }
}
