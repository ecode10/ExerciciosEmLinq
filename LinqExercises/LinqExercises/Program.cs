using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace LinqExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayQueryString();

            QueryIntArray();

            QueryArrayList();

            Console.ReadLine();
        }

        /// <summary>
        /// Método que busca usando linq em um array de string
        /// </summary>
        static void ArrayQueryString()
        {
            string[] dogs = {"K 9", "Brian Griffin", "Scooby Doo", "Old Yeller",
                "Rin Tin Tin", "Benji","Charlie B. Barkin", "Lassie", "Snoopy"};

            //selecionar todos que contém espaço
            var dogSpaces = from dog in dogs
                            where dog.Contains("S")
                            orderby dog descending
                            select dog;

            foreach (var dog in dogSpaces)
            {
                Console.WriteLine(dog);
            }

            //quebra a linha
            Console.WriteLine();
        }

        static void QueryIntArray()
        {
            int[] numeros = { 5, 10, 24, 20, 25, 40, 35 };

            //get number bigger then 20
            var gt20 = from num in numeros
                       where num > 20
                       orderby num
                       select num;

            foreach (var numero in gt20)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine();

            //pegando o tipo do retorno
            Console.WriteLine($"Tipo: {gt20.GetType()}");

            //convertendo para array e list
            var listGT20 = gt20.ToList<int>();
            var arrayGT20 = gt20.ToArray();

            //posso alterar o array de numero que atualiza automaticamente
            numeros[0] = 50;

            foreach (var numero in gt20)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine();
        }

        static void QueryArrayList()
        {
            ArrayList arrayAnimals = new ArrayList()
            {
                new Animal
                {
                    Nome = "Heidi",
                    Altura = .9,
                    Peso = 18
                },

                new Animal
                {
                    Nome = "Shrek",
                    Altura = .3,
                    Peso = 14
                },

                new Animal
                {
                    Nome = "Congo",
                    Peso = 3.2,
                    Altura = 1.2
                }
            };

            //convert the array list para IEnumberable
            var animalsEnum = arrayAnimals.OfType<Animal>();

            var animais = from animal in animalsEnum
                          where animal.Altura <= 1
                          orderby animal.Nome descending
                          select animal;

            foreach (var animal in animais)
            {
                Console.WriteLine($"Nome do animal {animal.Nome} e o peso {animal.Peso}");
            }

            Console.WriteLine();
        }

        static void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal
                {
                    Nome = "Gernam Shepherd",
                    Altura = 1.2,
                    Peso = 90
                },

                new Animal
                {
                    Nome = "Chihuahua",
                    Altura = 1.3,
                    Peso = 80
                },

                new Animal
                {
                    Nome = "Saint Bernard",
                    Altura = 1.4,
                    Peso = 200
                }
            };


        }
    }
}
