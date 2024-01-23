using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alunos = CriarAlunos();

            ExtrairAlunos(alunos);

        }

        static Aluno[] ExtrairAlunos(List<Aluno> alunos)
        {
            var q = from a in alunos
                    where a.Nota >= 5 && a.Nome.StartsWith("J")
                    select a;

            return q.ToArray();
        }

        public static List<Aluno> CriarAlunos()
        {
            var alunos = new List<Aluno>();
            alunos.Add(new Aluno() { Nome = "João", Nota = 9.5 });
            alunos.Add(new Aluno() { Nome = "Pedro", Nota = 4 });
            alunos.Add(new Aluno() { Nome = "Maria", Nota = 5 });
            alunos.Add(new Aluno() { Nome = "Joana", Nota = 6.5 });
            alunos.Add(new Aluno() { Nome = "Julia", Nota = 7 });

            return alunos;
        }
    }

    public class Aluno
    {
        public string Nome { get; set; }

        public double Nota { get; set; }
    }

}
