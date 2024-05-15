using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamousPokemonApi.Entities
{
    public class Pokemon
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("type")]
        [Required]
        public string Type { get; set; }
        [Column("image_url")]
        [Required]
        public string ImageUrl { get; set; }
        [Column("height")]
        [Required]
        public int Height { get; set; }
        [Column("weight")]
        [Required]
        public int Weight { get; set; }
        [Column("searchs")]
        [Required]
        public int Searchs { get; set; }
    }
}