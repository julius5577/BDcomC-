using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFtemp46
{
    internal class Program
    {


        static void Main(string[] args)
        {


            string op;

            do
            {
                Console.WriteLine("Seja Bem Vindos \n");
                Console.WriteLine("Escolha uma Opção \n");
                Console.WriteLine("1.Incluir");
                Console.WriteLine("2.Alterar");
                Console.WriteLine("3.Deletar");
                Console.WriteLine("4.Select");

                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)


                {

                    case 1:
                        incluir();
                        break;


                    case 2:
                        alterar();
                        break;


                    case 3:
                        deletar();
                        break;

                    //case 4:
                        //lista4.menu04();
                        //break;

                    default:
                        Console.WriteLine("Operação inválida.");

                        break;
                }

                Console.WriteLine("Deseja continuar \n");
                op = Console.ReadLine().ToLower();

            } while (op == "s");


        }

        private static void deletar()
        {

            using (var contexto = new BDtemp46Entities())
            {
                Console.WriteLine("Digite ID que deseja apagar: ");
                var busca = contexto.Agenda.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Voçê esta prestes a apagar o usuario:  {busca.Nome}");
                Console.WriteLine("Tem certeza que deseja apagar, digite S para apagar ou qualquer tecla para anular ");
                var apaga = Console.ReadLine();

                if (apaga == "S")

                {

                    contexto.Agenda.Remove(busca);
                    contexto.SaveChanges();
                    Console.WriteLine("Usuario excluido com sucesso");
                }

                else
                {
                    Console.WriteLine("Operação anulada");


                }

            }


        }

        private static void alterar()
        {
            using (var contexto = new BDtemp46Entities())
            {

                Console.WriteLine("Digite o ID que deseja alterar: ");
                var busca = contexto.Agenda.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine(busca.Nome);
                Console.WriteLine(busca.Celular);
                Console.WriteLine("Entre com a corrreção do nome: ");
                busca.Nome = Console.ReadLine();
                Console.WriteLine("Entre com a correção do celular: ");
                busca.Celular = Console.ReadLine();

                contexto.SaveChanges();
                Console.WriteLine("Usuario alterado com sucesso!!");




            }





        }

        private static void incluir()
        {
            string vNome, vCelular;

            Console.WriteLine("Digite se nome : ");
            vNome = Console.ReadLine();
            Console.WriteLine("Digite sem Celular ");
            vCelular = Console.ReadLine();



            using (var contexto = new BDtemp46Entities())
            {
                contexto.Agenda.Add(new Agenda()
                {

                    Nome = vNome,
                    Celular = vCelular,
                });
                contexto.SaveChanges();
                Console.WriteLine("Usuario adicionado ");


            }

            Console.ReadKey();


        }

    }
}
