using System.ComponentModel.DataAnnotations;

namespace GamesApi.Models {

    public class Game {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public string Onstock { get; set; }
    }
}