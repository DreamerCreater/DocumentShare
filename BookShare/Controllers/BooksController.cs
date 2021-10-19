using BookShare.Data.Models;
using BookShare.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShare.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }
        //Create/Add A NEW BOOK
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try{
                if(book !=null){
               _service.AddBook(book);
                return Ok(book);
                }
                return BadRequest("Book was not added");
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            
        }
        //Read all Books
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allBooks = _service.getAllBooks();
            return Ok(allBooks);
        }
        //Update an existing book
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book book)
        {
            _service.UpdateBook(id, book);
            return Ok(book);
        }
        //Delete a book
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }
       //get a single boook by id
       [HttpGet("SingleBook/{id}")]
       public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
    }
}
