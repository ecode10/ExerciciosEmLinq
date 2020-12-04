using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace LinqExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayQueryString();

            QueryIntArray();

            QueryArrayList();

            QueryCollection();

            QueryAnimalData();

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

            //selecionar os animais com peso maior de 90 e autura maior que 1
            var animais = from animal in animalList
                          where (animal.Peso >= 90) && (animal.Altura >= 1)
                          orderby animal.Nome
                          select animal;

            foreach (var animal in animais)
            {
                Console.WriteLine($"Nome: {animal.Nome} e altura {animal.Altura}");
            }

            Console.WriteLine();
        }

        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal
                {
                    Nome = "German Shepherd",
                    Altura = 25,
                    Peso = 120,
                    AnimalId = 1
                },

                new Animal
                {
                    Nome = "Chihuahua",
                    Altura = 14,
                    Peso = 12.3,
                    AnimalId = 2
                },

                new Animal
                {
                    Nome = "Saint Bernard",
                    Altura = 30,
                    Peso = 40,
                    AnimalId = 3
                },

                new Animal
                {
                    Nome = "Pug",
                    Altura = 12,
                    Peso = 144,
                    AnimalId = 4
                }
            };

            Dono[] donos = new[]
            {
                new Dono
                {
                    Nome = "Mauricio Junior",
                    DonoId = 1
                },

                new Dono
                {
                    Nome = "Sally",
                    DonoId = 2
                },

                new Dono
                {
                    Nome = "Marcos",
                    DonoId = 3
                },

                new Dono
                {
                    Nome = "Junior",
                    DonoId = 4
                }
            };

            //remover o peso
            var animalMenosPeso = from animal in animals
                                  select new
                                  {
                                      animal.Nome,
                                      animal.Altura
                                  };

            //convertendo em um array
            Array animalMenosPesoArray = animalMenosPeso.ToArray();

            foreach (var i in animalMenosPesoArray)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine();

            //create a inner join in donos e animais usando
            //id de animais e id de donos
            var innerJoin = from animal in animals
                            join dono in donos
                                on animal.AnimalId equals dono.DonoId
                            orderby dono.Nome
                            select new
                            {
                                NomeDono = dono.Nome,
                                dono.DonoId,
                                NomeAnimal = animal.Nome,
                                animal.Peso,
                                animal.AnimalId
                            };

            foreach (var join in innerJoin)
            {
                Console.WriteLine($"Dono: {join.NomeDono} Animal: {join.NomeAnimal}");
            }

            Console.WriteLine();
        }
    }
}
