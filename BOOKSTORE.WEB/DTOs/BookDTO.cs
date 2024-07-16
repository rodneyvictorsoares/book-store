using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BOOKSTORE.WEB.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public int AnoPublicacao { get; set; }
    }
}
