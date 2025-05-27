using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ap2.Models.Dtos
{
    public class PetDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Specie { get; set; }
        public required string Race { get; set; }
        public int TutorId { get; set; }
        public TutorDto? Tutor { get; set; }
    }
}