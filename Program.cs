using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleGithubSearch;
using System.Collections.Generic;

namespace ConsoleGithubSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string continuar = "";
            do
            {
                Console.WriteLine("Digite um usuario para buscar seus repositorios no github");
                string reposta = Console.ReadLine();
                Console.WriteLine("Buscando...");
                GetRepos(reposta);
                Console.WriteLine("Deseja fazer outra busca? (s/n)");
                continuar = Console.ReadLine();
                
            } while (continuar.ToLower().Contains('s'));
            Console.WriteLine("Obrigado por ter usado");
        }

        static void GetRepos(string user){
            string url = "https://api.github.com/users/{0}/repos";
            url = string.Format(url,user);
            Console.WriteLine("URL: {0}", url);
            WebService _service = new WebService();
            List<RootObject> repos = _service.GetService(url);
            foreach (var item in repos)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("#################");
            }
        }

    }
}
