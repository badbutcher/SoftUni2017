using Exam.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Dtos
{
    public class ImportPeopleDto
    {
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
