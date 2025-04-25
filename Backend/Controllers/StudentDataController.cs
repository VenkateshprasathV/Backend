using Backend.DB;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        private readonly ApplicationDbContext _db; //we have to update in db that why we using this
        public StudentDataController(ApplicationDbContext db)
        {
            _db = db; //this will use for db updation and deletion without this it will not happen
        }
        [HttpPost]
        [Route("Create")] 
        public IActionResult Create([FromBody]Student s1) //this IActionresult used for Multiple datas it will Return #basically its return type "String - Int - Float"
            //Create,update [frombody] pass
        {
            _db.Add(s1);
            _db.SaveChanges();
            return Ok(s1);
        }
        [HttpGet]
        [Route("GetAllStudDetails")]

        public IActionResult GetAll()
        {
            List<Student> students = new List<Student>();
            students = _db.StudentDatabase.ToList();
            return Ok(students);
        }

        [HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int id)
        {
            Student s1 = _db.StudentDatabase.FirstOrDefault(x => x.Id == id);
            return Ok(s1);
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody]Student s1)
        {
            _db.Update(s1);
            _db.SaveChanges();
            return Ok(s1);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteById(int id)
        {
            Student s1 = _db.StudentDatabase.FirstOrDefault(x => x.Id == id); //id check and then delete
            if(s1 == null)
            {
                return NotFound(new { message = $"s1 with Id {id} not found." });
            }

            _db.Remove(s1);
            _db.SaveChanges();
            return Ok(s1);
        }
    }
}
