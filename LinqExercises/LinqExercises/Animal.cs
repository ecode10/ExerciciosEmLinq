using System;
namespace LinqExercises
{
    public class Animal
    {
        public string Nome { get; set; }

        public double Peso { get; set; }

        public double Altura { get; set; }

        public int AnimalId { get; set; }

        public Animal(string nome = "Sem nome",
            double peso = 0,
            double alturar = 0)
        {
            Nome = nome;
            Peso = peso;
            Altura = alturar;
        }

        public override string ToString()
        {
            return $"{Nome} peso {Peso} e {Altura} de altura";
        }
    }
}
