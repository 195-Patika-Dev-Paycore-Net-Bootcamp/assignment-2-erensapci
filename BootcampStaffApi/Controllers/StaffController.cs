using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootcampStaffApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private static List<Staff> StaffList = new List<Staff>()
        {
            new Staff()
            {
                Id = 1,
                Name = "Deny",
                Surname = "Sellen",
                DateOfBirth = new DateTime(1989,1, 1),
                Email = "deny@gmail.com",
                PhoneNumber = "+905554443366",
                Salary = 4450

            }
        };

        //Where the get method is executed
        [HttpGet]
        public List<Staff> GetStaffs()
        {
            var staffList = StaffList.OrderBy(x => x.Id).ToList<Staff>();
            return staffList;
        }

        //Where the Get method is executed according to the Id data
        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            var staff = StaffList.Where(staff => staff.Id == id).SingleOrDefault();
            return staff;
        }

        //The part where the data is added with the post method
        [HttpPost]
        public ActionResult AddStaff([FromBody] Staff newStaff)
        {
            var staff = StaffList.SingleOrDefault(x => x.Id == newStaff.Id);

            StaffList.Add(newStaff);
            return Ok();
        }
        //Method to update the old data
        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, [FromBody] Staff updatedStaff)
        {
            if (updatedStaff is null)
            {
                throw new ArgumentNullException(nameof(updatedStaff));
            }

            var staff = StaffList.SingleOrDefault(x => x.Id == id);

            return Ok(staff);
        }
        //the method we use to delete data
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = StaffList.SingleOrDefault(x => x.Id == id);

            StaffList.Remove(staff);
            return Ok();
        }

    }
}
