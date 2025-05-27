using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ap2.Models.Dtos
{
    public class TutorDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}