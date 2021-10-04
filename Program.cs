using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indeceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno(); //ou var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                        aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indeceAluno] = aluno;
                        indeceAluno++;
                        //podia ser assim sem o tryparse mas dessa forma, se ele tentar converter e só tiver letras e não números, teremos um erro: aluno.Nota = decimal.Parse(Console.ReadLine());
                        break;
                    case "2":
                        foreach (var a in alunos) //"a" equivale a aluno
                        {
                            if (!string.IsNullOrEmpty(a.Nome)) //podia ser (a != null), mas o a está como struct, e só pode ser mulo se for um tipo por referencia como uma claase, array, etc.
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (var i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        
                        if (mediaGeral <= 2 ) //menor ou igual a 2
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <= 4 )
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6 )
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8 )
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}