// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using Checkpoint;
using Checkpoint.Model;


//Carga inicial,para que as opções do menu funcionem sem a necessidade de cadastrar funcionários
Clt clt4 = new(1, "Amelie", Genero.Outros, 2300, false);
Clt.listaClt.Add(clt4);
Clt clt3 = new(3, "Ricardo", Genero.Masculino, 4500, true);

Clt.listaClt.Add(clt3);
Funcionario.listaFuncionarios.Add(clt4);
Funcionario.listaFuncionarios.Add(clt3);

Pj pj4 = new(123, "Bernardo", Genero.Masculino, 80, 70, "12385734242");
Pj pj3 = new(765, "Geovana", Genero.Feminino, 150, 50, "078564547785546");
Pj.listaPj.Add(pj3);
Pj.listaPj.Add(pj4);
Funcionario.listaFuncionarios.Add(pj3);
Funcionario.listaFuncionarios.Add(pj4);


void CadastroFuncionario()
{
    Console.WriteLine("CADASTRO DE FUNCIONÁRIOS");
    //Funcionarios
    string tipoFuncionario;
    int codigoFuncionario;
    String nomeFuncionario;
    String generoFuncionario;
    Genero genero;

    //CLT
    double salarioFuncionario;
    String cargoConfiança;
    bool confianca;

    //PJ
    String cnpj;
    int quantidadeHoras;
    double valorHoras;
    do
    {
        Console.Write("O funcionário se trata de um CLT OU PJ? ");
        tipoFuncionario = Console.ReadLine().ToUpper();
    } while (!Verificacoes.ValidacaoTipoFuncionario(tipoFuncionario));


    do
    {
        Console.Write("Informe o código do funcionário: ");
        codigoFuncionario = int.Parse(Console.ReadLine());
    } while (!Verificacoes.CampoValores(codigoFuncionario));

    do
    {
        Console.Write("Informe o nome do funcionário: ");
        nomeFuncionario = Console.ReadLine();
    } while (!Verificacoes.CampoVazio(nomeFuncionario));

    do
    {
        Console.Write("Informe o gênero do funcionário : [M]-masculino , [F]-feminino " +
            ", [O]-Outros: ");
        generoFuncionario = Console.ReadLine().ToUpper();
    } while (!Verificacoes.ValidacaoGenero(generoFuncionario));
    if (generoFuncionario == "M")
    {
        genero = Genero.Masculino;
    }
    else if (generoFuncionario == "F")
    {
        genero = Genero.Feminino;
    }
    else
    {
        genero = Genero.Outros;
    }

    if (tipoFuncionario == "CLT")
    {
        do
        {
            Console.Write("Informe o salário do funcionário: R$");
            salarioFuncionario = int.Parse(Console.ReadLine());
        } while (!Verificacoes.CampoValores(salarioFuncionario));

        do
        {
            Console.Write("O funcionário possui cargo de confiança? [S]-sim [N]-não: ");
            cargoConfiança = Console.ReadLine().ToUpper();
        } while (!Verificacoes.ValidacaoTipoCargo(cargoConfiança));
        if (cargoConfiança == "N")
        {
            confianca = false;
        }
        else
        {
            confianca = true;
        }

        Clt clt2 = new(codigoFuncionario, nomeFuncionario, genero, salarioFuncionario, confianca);
        Clt.listaClt.Add(clt2);
        Funcionario.listaFuncionarios.Add(clt2);
        Console.WriteLine("Cadastro realizado com sucesso!");
    }

    else
    {
        do
        {
            Console.Write("Informe o CNPJ: ");
            cnpj = Console.ReadLine();
        } while (!Verificacoes.CnpjValido(cnpj));

        do
        {
            Console.Write("Informe o total de horas trabalhadas: ");
            quantidadeHoras = int.Parse(Console.ReadLine());
        } while (!Verificacoes.CampoValores(quantidadeHoras));
        do
        {
            Console.Write("Informe o valor por hora: R$");
            valorHoras = int.Parse(Console.ReadLine());
        } while (!Verificacoes.CampoValores(valorHoras));

        Console.WriteLine("Cadastro realizado com sucesso!");
        Pj pj = new(codigoFuncionario, nomeFuncionario, genero, valorHoras, quantidadeHoras, cnpj);
        Pj.listaPj.Add(pj);
        Funcionario.listaFuncionarios.Add(pj);

    }

}

void ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("MENU DE FUNCIONÁRIOS");
    Console.WriteLine("-------------------");
    Console.WriteLine("1-Cadastro de funcionários");
    Console.WriteLine("2-Funcionários CLT");
    Console.WriteLine("3-Funcionários PJ");
    Console.WriteLine("4-Exibir todos os gastos mensais de funcionários ");
    Console.WriteLine("5-Aumentar salário de funcionário CLT ");
    Console.WriteLine("6-Aumentar salário do funcionário PJ ");
    Console.WriteLine("7-Pesquisar funcionário por registro");
    Console.WriteLine("8-Custo mensal de funcionário");
    Console.WriteLine("9-Inserir hora extra de funcionário PJ");
    Console.WriteLine("10-SAIR");
    Console.WriteLine("-----------------");
    Console.Write("Digite a opção escolhida : ");
    int opcaoEscolhida = int.Parse(Console.ReadLine());

    Console.Clear();
    switch (opcaoEscolhida)
    {
        case 1:
            CadastroFuncionario();
            Thread.Sleep(2000);
            Console.Clear();
            ExibirMenu();
            break;

        case 2:
            Console.WriteLine("FUNCIONÁRIOS CLT");
            try
            {
                foreach (var item in Clt.listaClt)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu();
            break;

        case 3:
            Console.WriteLine("FUNCIONÁRIOS PJ");
            try
            {
                foreach (var item in Pj.listaPj)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu();
            break;

        case 4:
            Console.WriteLine($"Gastos mensais de funcionários:");
            Funcionario.GastoTotalEmpresa();
            Thread.Sleep(5000);
            Console.Clear();
            ExibirMenu();
            break;

        case 5:
            int registroPesquisa = Verificacoes.RegistroValido();
            Funcionario funcionario = Funcionario.PesquisarCodigo(registroPesquisa);
            if (funcionario == null)
            {
                Thread.Sleep(2000);
                ExibirMenu();
                break;
            }
            Console.Write("Informe a porcentagem de aumento do salário desse funcionário: ");
            int porcentagemAumento = int.Parse(Console.ReadLine());
            try
            {
                Clt.AumentoSalario(funcionario, porcentagemAumento);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(2000);
            ExibirMenu();
            break;

        case 6:

            registroPesquisa = Verificacoes.RegistroValido();
            funcionario = Funcionario.PesquisarCodigo(registroPesquisa);
            if (funcionario == null)
            {
                Thread.Sleep(2000);
                ExibirMenu();
                break;
            }
            Console.Write("Informe o aumento do valor hora desse funcionário: R$");
            int valorHoraNovo = int.Parse(Console.ReadLine());
            try
            {
                Pj.AumentoValorHora(funcionario, registroPesquisa, valorHoraNovo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Thread.Sleep(2000);
            ExibirMenu();
            break;
        case 7:
            registroPesquisa = Verificacoes.RegistroValido();
            Funcionario.PesquisarFuncCodigo(registroPesquisa);
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu();
            break;
        case 8:
            registroPesquisa = Verificacoes.RegistroValido();
            try
            {
                Funcionario.PesquisarCustoMensal(registroPesquisa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            ExibirMenu();
            break;

        case 9:
            registroPesquisa = Verificacoes.RegistroValido();
            funcionario = Funcionario.PesquisarCodigo(registroPesquisa);
            if (funcionario == null)
            {
                Thread.Sleep(2000);
                ExibirMenu();
                break;
            }
            Console.Write("Informe o total de horas extras feitas pelo funcionário: ");
            int horaExtra = int.Parse(Console.ReadLine());
            try
            {
                Pj.AumentoValorHora(funcionario, registroPesquisa, horaExtra);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
            }
            ExibirMenu();
            break;


        case 10:
            Console.WriteLine("Volte sempre :)");
            break;



    }

}



//Main
ExibirMenu();
