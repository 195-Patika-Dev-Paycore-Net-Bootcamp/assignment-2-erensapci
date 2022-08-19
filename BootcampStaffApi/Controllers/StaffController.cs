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

        [HttpGet]
        public List<Staff> GetStaffs()
        {
            var staffList = StaffList.OrderBy(x => x.Id).ToList<Staff>();
            return staffList;
        }

        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            var staff = StaffList.Where(staff => staff.Id == id).SingleOrDefault();
            return staff;
        }

        [HttpPost]
        public ActionResult AddStaff([FromBody] Staff newStaff)
        {
            var staff = StaffList.SingleOrDefault(x => x.Id == newStaff.Id);

            StaffList.Add(newStaff);
            return Ok();
        }

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

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = StaffList.SingleOrDefault(x => x.Id == id);

            StaffList.Remove(staff);
            return Ok();
        }

    }
}
