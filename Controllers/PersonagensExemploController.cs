using RpgApi.Models;
using RpgApi.Models.Enuns;
using Microsoft.AspNetCore.Mvc;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExemploController : ControllerBase
    {
        /* List<Personagem> personagens = new List<Personagem>();
         Personagem p1nto = new Personagem();
         p1nto.Nome = "Pintolino";

         personagens.Add(p1nto);*/
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

        public IActionResult Get()
        {
            return Ok(personagens);
        }

        [HttpPost]
        public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p)
        {
            Personagem pernsagemAlterado = personagens.Find(pers => pers.Id == p.Id);
            pernsagemAlterado.Nome = p.Nome;
            pernsagemAlterado.PontosVida = p.PontosVida;
            pernsagemAlterado.Forca = p.Forca;
            pernsagemAlterado.Defesa = p.Defesa;
            pernsagemAlterado.Inteligencia = p.Inteligencia;
            pernsagemAlterado.Classe = p.Classe;

            return Ok(personagens);
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            personagens.RemoveAll(pers => pers.Id == id);
            
            return Ok(personagens);
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Personagem> listaFinal =  personagens.OrderBy(p => p.Forca).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetContagem")]

        public IActionResult GetQuantidade()
        {
            return Ok("Quantidade de personagens: " + personagens.Count);
        }

        [HttpGet("GetSomaForca")]

        public IActionResult GetSomaForca()
        {
            return Ok(personagens.Sum(p => p.Forca));
        }

        [HttpGet("GetSemCavaleiro")]
        public IActionResult GetSemCavaleiro()
        {
            List<Personagem> listaBusca = personagens.FindAll(personagens => personagens.Class != ClasseEnum.Cavaleiro);
            return Ok(listaBusca);
        }

        [HttpGet("GetByNomeAproximado/{nome}")]
        {
            
        }
    }  
}