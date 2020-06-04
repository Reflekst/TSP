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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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
                    var splitLine = line.Split(' ').Where(v=>v!="").ToList();
                    points.Add(new Point()
                    {
                        Id = splitLine[0],
                        X = int.Parse(splitLine[1]),
                        Y = int.Parse(splitLine[2])
                    });
                }
            }


            double distance = 0;
            if (points.Count != 0)
            {

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



        public Result StartMetaheuristic(string filePath, int limitSeconds)
        {
            Stopwatch stopwatch = new Stopwatch(); // stopwatch liczący czas pracy
            stopwatch.Start();
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
                    var splitLine = line.Split(' ').Where(v => v != "").ToList();
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
                for (int j = 1; j <= points.Count; j++)
                {
                    if (i != j)
                    {
                        if (pointsDistances[i, j] == 0) //punkt nie może wychodzić i wchodzić sam do siebie
                        {
                            Point iPoint = points.FirstOrDefault(p => p.Id == i.ToString());
                            Point jPoint = points.FirstOrDefault(p => p.Id == j.ToString());

                            double distance = CountDistance(iPoint.X, iPoint.Y, jPoint.X, jPoint.Y); // obliczamy odległośc między punktami i zapisujemy w tablicy dla obu możliwości

                            pointsDistances[i, j] = distance;
                            pointsDistances[j, i] = distance;

                        }
                    }
                }
            }


            Result greedyResult = Start(filePath);


            AlgorithmModel workingPath = new AlgorithmModel()
            {
                Path = new List<int>()
            };

            foreach (Point point in greedyResult.SortPoints)
            {
                workingPath.Path.Add(int.Parse(point.Id));
            }

            workingPath.Path.Add(1);
            workingPath.Distance = CalculateTotalDistance(workingPath, pointsDistances);

            AlgorithmModel bestPath = new AlgorithmModel()
            {
                Path = new List<int>(),
                Distance = workingPath.Distance
            };
            bestPath.Path.AddRange(workingPath.Path);

            
            //ALGORYTM 2-OPT
            double bestDistance = workingPath.Distance;
            int workSeconds = 0;
            while (workSeconds <= limitSeconds)
            {
            startagain:
                for (int i = 1; i <= workingPath.Path.Count - 1; i++)
                {
                    for (int k = i + 1; k <= workingPath.Path.Count - 2; k++)
                    {
                        AlgorithmModel new_route = optSwap(workingPath, i, k);
                        // pobieramy indexy, między którymi ma nastąpic odwrócenie ścieżki i obracamy, potem obliczamy dystans
                        new_route.Distance = CalculateTotalDistance(new_route, pointsDistances);
                        if (new_route.Distance < bestDistance)
                        // jeżeli nowy dystans jest lepszy to zapisujemy go i zaczynamy wszystko od nowa skacząc do startAgain:, jak nie leci przez iterację dalej
                        {
                            workingPath = new_route;
                            bestDistance = new_route.Distance;
                            goto startagain;
                        }
                    }
                    //koniec czasu - zakończ pracę
                    workSeconds = (int)stopwatch.ElapsedMilliseconds / 1000;
                    if (workSeconds >= limitSeconds)
                    {
                        break;
                    }
                }
                if (workSeconds >= limitSeconds)
                {
                    break;
                }
                if (workingPath.Distance < bestPath.Distance)
                {
                    bestPath.Distance = workingPath.Distance;
                    bestPath.Path.Clear();
                    bestPath.Path.AddRange(workingPath.Path);
                }

                Random random = new Random();
                int firstIndex = 0;
                List<int> indexInts = new List<int>();
                while (indexInts.Count != 4)
                {
                    firstIndex = random.Next(1, workingPath.Path.Count - 1);
                    if (!indexInts.Contains(firstIndex))
                    {
                        indexInts.Add(firstIndex);
                    }
                }
                workingPath.Path.Clear();
                workingPath.Path.AddRange(bestPath.Path);

                //MUTACJA

                int temp1 = workingPath.Path[indexInts[0]];
                int temp2 = workingPath.Path[indexInts[1]];
                int temp3 = workingPath.Path[indexInts[2]];
                int temp4 = workingPath.Path[indexInts[3]];

                workingPath.Path[indexInts[0]] = temp3;
                workingPath.Path[indexInts[2]] = temp1;
                workingPath.Path[indexInts[1]] = temp4;
                workingPath.Path[indexInts[3]] = temp2;

                workingPath.Distance = CalculateTotalDistance(workingPath, pointsDistances);
                bestDistance = workingPath.Distance;
                //Zaczynamy od początku
                goto startagain;
            }

            //Zapisujemy do Result najlepszy wynik
            result.Distance = bestPath.Distance;
            result.Time = stopwatch.ElapsedMilliseconds;
            result.SortPoints = new List<Point>();
            //result.PointsCount = bestPath.Path.Count - 1;


            foreach (int id in bestPath.Path)
            {
                result.SortPoints.Add(points.FirstOrDefault(p => p.Id == id.ToString()));
            }

            return result;
        }


        private AlgorithmModel optSwap(AlgorithmModel geneticModel, int ic, int kc)
        {
            AlgorithmModel newGeneticModel = new AlgorithmModel()
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

        private double CalculateTotalDistance(AlgorithmModel geneticModel, double[,] pointsDistances)
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
