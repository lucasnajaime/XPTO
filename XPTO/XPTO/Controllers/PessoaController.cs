using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XPTO.Models;
using XPTO.Repository;

namespace XPTO.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Repository<Pessoa> _pessoa;

        public PessoaController()
        {
            _pessoa = new Repository<Pessoa>();
        }
        // GET: Pessoa
        public ActionResult Index()
        {

            var teste = TempData["Sucesso"];

            //criando uma lista de pessoas
            var pessoas = _pessoa.GetAll();

            // retronando a lista para o html
            return View(pessoas);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            

            pessoa.Idade = CalcularIdade(pessoa.DataNascimento);
            pessoa.MaiorDeIdade = MaiorDeDezoito(pessoa.Idade);
            

            if(Validacoes(pessoa) == true)
            {
                return View(pessoa);
            }

            TempData["Sucesso"] = "Usuário cadastrado com sucesso !";
            _pessoa.Add(pessoa);
            return RedirectToAction("Index");
        }

        public int CalcularIdade(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);

            return idade.Year;
        }

        public bool MaiorDeDezoito(int idade)
        {
            if (idade >= 18)
                return true;
            else
                return false;
        }

        public bool Validacoes(Pessoa pessoa)
        {
            bool erro = false;
            var validacoes = "";
        

            if (_pessoa.GetAll().Where(x => x.CPF == pessoa.CPF).Count() != 0)
            {
                validacoes += " | CPF JÁ EXISTE NA BASE DE DADOS";
                erro = true;
            }
            if (_pessoa.GetAll().Count() >= 10)
            {
                validacoes += " | JÁ EXISTE 10 PESSOAS CADASTRADAS, É O MÁXIMO";
                erro = true;
            }

            TempData["Validações"] = validacoes;
            return erro;
        }
    }
}