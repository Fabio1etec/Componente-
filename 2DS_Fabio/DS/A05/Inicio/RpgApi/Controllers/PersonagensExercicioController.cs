using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };


        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome.Contains(nome));
            if (listaBusca.Count == 0)
            {
                return BadRequest("Personagem não encontrado");
            }
            return Ok(listaBusca);

        }
        
        [HttpPost("PostValidacao")]
        public ActionResult<Personagem> PostValidacao(Personagem personagem)
        {
        if (personagem.Defesa < 10 || personagem.Inteligencia > 30)
            {
                return BadRequest("Os valores de defesa devem ser maiores ou iguais a 10 e a inteligência deve ser menor ou igual a 30.");
            }

            personagens.Add(personagem);

            return CreatedAtAction(nameof(PostValidacao), personagem);
        }

         [HttpPost("PostValidacaoMago")]
        public ActionResult<Personagem> PostValidacaoMago(Personagem personagem)
        {
        if (personagem.Inteligencia < 35)
            {
                return BadRequest("A inteligñecia de um mago deve ser superior ou igual a 35.");
            }

            personagens.Add(personagem);

            return CreatedAtAction(nameof(PostValidacaoMago), personagem);
        }

    }
}