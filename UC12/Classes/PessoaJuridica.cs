using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC12.Classes
{
    internal class PessoaJuridica : Pessoa
    {
        public string? Cnpj { get; set; }
        public string Caminho { get; private set; } = "Database/PessoaJuridica.csv"; public bool ValidarCnpj(string cnpj)
        {


            if (cnpj.Length == 18)
            {
                if (cnpj.Substring(11, 4) == "0001")
                {
                    return true;
                }
            }
            else if (cnpj.Length == 14)
            {
                if (cnpj.Substring(8, 4) == "0001")
                {
                    return true;
                }
            }
            return false;
        }


        public void Inserir(PessoaJuridica pj)
        {
            Utils.VerificarPastaArquivo(Caminho);
            string[] pjStrings = { $"{pj.Nome}, {pj.Rendimento}, {pj.Cnpj}" };
            File.AppendAllLines(Caminho, pjStrings);
        }
        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
            string[] linhas = File.ReadAllLines(Caminho);
            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.Nome = atributos[0];



                cadaPj.Rendimento = float.Parse(atributos[1]);



                cadaPj.Cnpj = atributos[2];

                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
        }
}
