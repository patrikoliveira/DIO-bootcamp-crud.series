using System;
using CrudSeries.Src.Domain.Entities;
using CrudSeries.Src.Domain.Enums;
using CrudSeries.Src.Domain.Repositories;
using CrudSeries.Src.Infraestructure.Repositories;

namespace CrudSeries
{
    class Program
    {
        static ISerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "x")
            {
              switch (opcaoUsuario)
              {
                  case "1":
                    ListarSeries();
                    break;
                  case "2":
                    InserirSerie();
                    break;
                  case "3":
                    AtualizarSerie();
                    break;
                  case "4":
                    ExcluirSerie();
                    break;
                  case "5":
                    VisualizarSerie();
                    break;
                  case "C":
                    Console.Clear();
                    break;
                  default:
                    throw new ArgumentOutOfRangeException();
              }

              opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Didite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            System.Console.WriteLine(repositorio.RetornaPorId(indiceSerie));
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Didite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Didite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            System.Console.WriteLine("Digite o gênero: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de início: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a Descricao: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie serie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio.Atualizar(indiceSerie, serie);
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }

            System.Console.WriteLine("Digite o gênero: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.WriteLine("Digite o Ano de início: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a Descricao: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie serie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio.Insere(serie);
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");
            var list = repositorio.Lista();

            if (list.Count == 0)
            {
                System.Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach (var serie in list)
            {
                System.Console.WriteLine($"#ID {serie.RetornaId()}: {serie.RetornaTitulo()}");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
