using System.ComponentModel.DataAnnotations;
namespace ContosoPets.Api.Models{
    public record Product{

        public int Id{get; init;}

        [Required]
        public string Name{get; init;}

        [Range(0.01,9999.99)]
        public decimal Price{get; init;}
    }
}