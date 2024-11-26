using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente
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
                Console.WriteLine("1.Incluir Novo Cliente");
                Console.WriteLine("2.Alterar Dados Do Cliente");
                Console.WriteLine("3.Deletar Cliente");
                Console.WriteLine("4.Select (selecionar a tabela)");

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

                    case 4:
                        select();
                    break;

                    default:
                        Console.WriteLine("Operação inválida.");

                        break;
                }

                Console.WriteLine("Deseja continuar \n");
                op = Console.ReadLine().ToLower();

            } while (op == "s");








        }

        private static void select()
        {
            using (var contexto = new CadastroClientesEntities())
            {
                // Exemplo de consulta simples para selecionar todos os usuários da agenda
                var cadastros = contexto.CadastroClientes.ToList();

                foreach (var listacadastro in cadastros)
                {
                    Console.WriteLine($"ID: {listacadastro.Id}, Nome: {listacadastro.NomeCliente}," +
                        $" Endereço: {listacadastro.Endereco}, Cidade: {listacadastro.Cidade}, Telefone: {listacadastro.TelefoneContato}");
                }
            }
            Console.ReadKey();
        }

        private static void deletar()
        {
            using (var contexto = new CadastroClientesEntities())
            {
                Console.WriteLine("Digite ID que deseja apagar: ");
                var busca = contexto.CadastroClientes.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Voçê esta prestes a apagar o usuario:  {busca.NomeCliente}");
                Console.WriteLine("Tem certeza que deseja apagar, digite S para apagar ou qualquer tecla para anular ");
                var apaga = Console.ReadLine();

                if (apaga == "S")

                {

                    contexto.CadastroClientes.Remove(busca);
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
            using (var contexto = new CadastroClientesEntities())
            {

                Console.WriteLine("Digite o ID que deseja alterar: ");
                var busca = contexto.CadastroClientes.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine(busca.NomeCliente);
                Console.WriteLine(busca.TelefoneContato);
                Console.WriteLine("Entre com a corrreção do nome: ");
                busca.NomeCliente = Console.ReadLine();
                Console.WriteLine("Entre com a correção do celular: ");
                busca.TelefoneContato = Console.ReadLine();

                contexto.SaveChanges();
                Console.WriteLine("Usuario alterado com sucesso!!");




            }

        }

        private static void incluir()
        {
            string vNome, vEndereco , vCidade ,vTelefone;

            Console.WriteLine("Digite seu nome: ");
            vNome = Console.ReadLine();
            Console.WriteLine("Digite seu Endereço: ");
            vEndereco = Console.ReadLine();
            Console.WriteLine("Digite sua Cidade:");
            vCidade = Console.ReadLine();
            Console.WriteLine("Digite seu telefone:");
            vTelefone = Console.ReadLine();

            using (var contexto = new CadastroClientesEntities())
            {
                contexto.CadastroClientes.Add(new CadastroClientes()
                {

                    NomeCliente = vNome,
                    Endereco = vEndereco,
                    Cidade = vCidade,
                    TelefoneContato = vTelefone
                });
                contexto.SaveChanges();
                Console.WriteLine("Usuario adicionado ");


            }

            Console.ReadKey();



        }
    }
}
