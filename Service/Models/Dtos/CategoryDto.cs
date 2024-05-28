﻿using Libreria.Models.Entities;

namespace Libreria.Service.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
