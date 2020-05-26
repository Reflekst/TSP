using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OP_TSP.Models;

namespace OP_TSP
{
    public class TspAlgorithm
    {
        public Result Start(string filePath)
        {
            Result result = new Result();
            List<Point> points = new List<Point>();
            List<Point> usedPoints = new List<Point>();
            bool firstLine = true;

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            foreach (string line in lines)
            {
                if (firstLine)
                {
                    result.PointsCount = int.Parse(line);
                    firstLine = false;
                }
                else
                {
                    var splitLine = line.Split(' ');
                    points.Add(new Point()
                    {
                        Id = splitLine[0],
                        X = int.Parse(splitLine[1]),
                        Y = int.Parse(splitLine[2])
                    });
                }
            }

            Stopwatch stopwatch = new Stopwatch();

            double distance = 0;
            if (points.Count != 0)
            {
                stopwatch.Start();

                Point selectedPoint;
                selectedPoint = points.FirstOrDefault();
                usedPoints.Add(selectedPoint);
                points.Remove(selectedPoint);
                while (points.Count != 0)
                {
                    foreach (Point point in points)
                    {
                        point.Distance = CountDistance(selectedPoint.X, selectedPoint.Y, point.X, point.Y);
                    }

                    double minDistance = points.Min(p => p.Distance);
                    selectedPoint = points.First(p => p.Distance == minDistance);

                    distance += minDistance;
                    usedPoints.Add(selectedPoint);
                    points.Remove(selectedPoint);

                }
                stopwatch.Stop();
            }

            distance += CountDistance(usedPoints.LastOrDefault().X, usedPoints.LastOrDefault().Y,
                usedPoints.FirstOrDefault().X, usedPoints.FirstOrDefault().Y);
            result.Time = stopwatch.ElapsedMilliseconds;
            result.SortPoints = usedPoints;
            result.Distance = distance;
            return result;
        }



        public Result StartGeneticAlghoritm(string filePath)
        {
            Result result = new Result();
            
            List<Point> points = new List<Point>();
            
            bool firstLine = true;
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            foreach (string line in lines)
            {
                if (firstLine)
                {
                    result.PointsCount = int.Parse(line);
                    firstLine = false;
                }
                else
                {
                    var splitLine = line.Split(' ');
                    points.Add(new Point()
                    {
                        Id = splitLine[0],
                        X = int.Parse(splitLine[1]),
                        Y = int.Parse(splitLine[2])
                    });
                }
            }

            double[,] pointsDistances = new double[points.Count + 1, points.Count + 1]; // tworzymy tablice dwuwymiarową połączeń między punktami

            for (int i = 1; i <= points.Count; i++)
            {
                for (int j = 1; j < points.Count; j++)
                {
                    if (i != j)
                    {
                        if (pointsDistances[i, j] == 0) //punkt nie może wychodzić i wchodzić sam do siebie
                        {
                            Point iPoint = points.FirstOrDefault(p => p.Id == i.ToString());
                            Point jPoint = points.FirstOrDefault(p => p.Id == j.ToString());

                            double distance = CountDistance(iPoint.X, iPoint.Y, jPoint.X, jPoint.Y); // obliczamy odległośc między punktam i zapisujemy w tablicy dla obu możliwości

                            pointsDistances[i, j] = distance;
                            pointsDistances[j, i] = distance;

                        }
                    }
                }
            }
            Stopwatch stopwatch = new Stopwatch();


            List<GeneticModel> geneticModels = new List<GeneticModel>(); // tworzymy listę ścieżek do algoyrtmu genetycznego
            Random random = new Random();
           
            int selectedPoint = int.Parse(points.FirstOrDefault().Id);
            for (int i = 0; i < 50; i++) // będzie ich 50
            {
                GeneticModel geneticModel = new GeneticModel();
                geneticModel.Path = new List<int>();
                geneticModel.Distance = 0;
                while (geneticModel.Path.Count < points.Count - 1)
                {
                    int randomId = random.Next(2, points.Count + 1);
                    if (!geneticModel.Path.Contains(randomId)) // jeżeli nie ma na ścieżce danej ścieżki, zapisujemy ją do listy
                    {
                        geneticModel.Path.Add(randomId);
                        geneticModel.Distance += pointsDistances[selectedPoint, randomId]; // szybka opcja dostania dystansu między punktami
                        selectedPoint = randomId;
                    }
                }
                geneticModel.Distance += pointsDistances[int.Parse(points.FirstOrDefault().Id), selectedPoint];
                geneticModels.Add(geneticModel);// dodajemy do listy
            }



            for (int i = 1; i <=2; i++) // ALGORYTM GENETYCZNY
            {
                int firstIndex = 0;
                int secondIndex = 0;
                for (int j = 0; j < 15; j++)
                {
                    while (firstIndex == secondIndex) // wybieramy dwie różne ścieżki
                    {
                        firstIndex = random.Next(1, geneticModels.Count);
                        secondIndex = random.Next(1, geneticModels.Count);
                    }

                    GeneticModel firstGeneticModel = geneticModels[firstIndex];
                    GeneticModel secondGeneticModel = geneticModels[secondIndex];
                    List<int> newPath = new List<int>();

                    for (int k = 0; k <= 59; k++) // bierzemy 60 punktów z pierwszego
                    {
                        newPath.Add(firstGeneticModel.Path[k]);
                    }

                    for (int k = 0; k < secondGeneticModel.Path.Count; k++) // z drugiego dopisujemy po kolei te, których nie ma
                    {
                        if (!newPath.Contains(secondGeneticModel.Path[k]))
                        {
                            newPath.Add(secondGeneticModel.Path[k]);
                        }
                    }

                    double distance = 0;
                    // oblcizamy dystans nowej ścieżki
                    int index = 1;

                    foreach (int pathIndex in newPath)
                    {
                        distance += pointsDistances[index, pathIndex];
                        index = pathIndex;
                    }

                    distance += pointsDistances[1, index]; 
                    //dodajemy tak 15 razy
                    geneticModels.Add(new GeneticModel()
                    {
                        Path = newPath,
                        Distance = distance
                    });

                }

                for (int l = 1; l < 30; l++) // Mutacja 
                {
                    GeneticModel mutationModel = geneticModels[geneticModels.Count - l];
                    for (int j = 0; j < 2; j++)
                    {
                        firstIndex = 0;
                        secondIndex = 0;
                        while (firstIndex == secondIndex)
                        {
                            firstIndex = random.Next(1, geneticModels.Count);
                            secondIndex = random.Next(1, geneticModels.Count);
                        }
                        int temp = mutationModel.Path[firstIndex]; // zamiana miejscami dwóch punktów
                        mutationModel.Path[firstIndex] = mutationModel.Path[secondIndex];
                        mutationModel.Path[secondIndex] = temp;

                        double distance = 0;
                        //znowu oblicza odległość
                        int index = 1;

                        foreach (int pathIndex in mutationModel.Path)
                        {
                            distance += pointsDistances[index, pathIndex];
                            index = pathIndex;
                        }

                        distance += pointsDistances[1, index];
                        mutationModel.Distance = distance;
                    }
                }

                // sortujemy po dystansie i usuwamy 15 najgorszych
                geneticModels = geneticModels.OrderBy(g => g.Distance).ToList();
                for (int j = 64; j > 49; j--)
                {
                    geneticModels.RemoveAt(j);
                }

            }

            List<GeneticModel> tests = new List<GeneticModel>();
            result.Distance = geneticModels.Min(g => g.Distance);
            //przeprowadzamy badanie dla igm ilosci modeli i potem wybieramy najlepszy
            for (int igm = 0; igm < 2;igm++)
            {
                var existingPath1 = geneticModels[igm];
                var existingPath = new GeneticModel();

                existingPath.Path = new List<int>();
                existingPath.Path.Add(1);
                existingPath.Path.AddRange(existingPath1.Path);
                existingPath.Path.Add(1);
                //obliczamy dystans
                double bestDistance = CalculateTotalDistance(existingPath, pointsDistances);

                Stopwatch stopwatch2 = new Stopwatch(); // stopwatch liczący czas pracy
                stopwatch2.Start();
                //while ((stopwatch2.ElapsedMilliseconds/1000) < 180)
                //ALGORYTM 2-OPT
                bool isTrying = true;
                while (isTrying)
                    // jak długo ma działać i tu jest myk, że jak znajdzie mozliwie najlepszy to ciągle bez zastanowienia leci przez funkcje FOR, dlatego mozęmy zrobic na kilku co ulepszy algorytm
                {
                    startagain:
                    for (int i = 1; i <= existingPath.Path.Count - 1; i++)
                    {
                        for (int k = i + 1; k <= existingPath.Path.Count - 2; k++)
                        {
                            GeneticModel new_route = optSwap(existingPath, i, k);
                                // pobieramy indexy, między którymi ma nastąpic odwrócenie ścieżki i obracamy, potem obliczamy dystans
                            new_route.Distance = CalculateTotalDistance(new_route, pointsDistances);
                            if (new_route.Distance < bestDistance)
                                // jeżeli nowy dystans jest lepszy to zapisujemy go i zaczynamy wszystko od nowa skacząc do startAgain:, jak nie leci przez iterację dalej
                            {
                                existingPath = new_route;
                                 bestDistance = new_route.Distance;
                                result.Distance = bestDistance;
                                result.PointsCount = new_route.Path.Count;
                                goto startagain;

                            }
                        }
                        //trzeba zrobić, że jak nie znajduje lepszego, to kończy ale to zorbimy przy następnej próbie razem
                        //dlatego jak zobaczy,y czasochłonność będzie można dostosować ilośc przerabianych ścieżek do mocyh obliczeniowej kompa
                    }
                    tests.Add(existingPath);
                    isTrying = false;
                }
            }

            // zwracamy wynik
            var min = tests.Min(t => t.Distance);
            var bestPath = tests.FirstOrDefault(g => g.Distance == min);
            result.SortPoints = new List<Point>();
            for (int i = 0; i < bestPath.Path.Count - 1; i++)
            {
                result.SortPoints.Add(points.FirstOrDefault(p => p.Id == bestPath.Path[i].ToString()));
            }
            result.PointsCount = bestPath.Path.Count - 1;
            result.Distance = min;
            return result;
        }


        private GeneticModel optSwap(GeneticModel geneticModel, int ic, int kc)
        {
            GeneticModel newGeneticModel = new GeneticModel()
            {
                Path = new List<int>()
            };

            for (int i = 0; i <= ic - 1; i++)
            {
                newGeneticModel.Path.Add(geneticModel.Path[i]);
            }

            for (int i = kc; i > ic - 1; i--)
            {
                newGeneticModel.Path.Add(geneticModel.Path[i]);
            }

            for (int i = kc + 1; i < geneticModel.Path.Count; i++)
            {
                newGeneticModel.Path.Add(geneticModel.Path[i]);
            }

            return newGeneticModel;
        }

        private double CalculateTotalDistance(GeneticModel geneticModel, double[,] pointsDistances)
        {
            double distance = 0;
            for (int i = 0; i < geneticModel.Path.Count - 1; i++)
            {
                distance += pointsDistances[geneticModel.Path[i], geneticModel.Path[i + 1]];
            }

            return distance;
        }

        private double CountDistance(int x1, int y1, int x2, int y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return Math.Round(distance, 2);
        }


    }
}
