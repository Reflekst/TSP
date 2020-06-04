using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OP_TSP.Models;
using Point = OP_TSP.Models.Point;

namespace OP_TSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void findFileButton_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = fileDialog.FileName;
            }

        }

        private void startAlghoritmButton_Click(object sender, EventArgs e)
        {

        }


        private void mainAlgorithm_Click(object sender, EventArgs e)
        {
            if (filePathTextBox.Text == "")
            {
                MessageBox.Show("Nie wybrano pliku");
            }
            else
            {
                int seconds = 0;
                try
                {
                    
                    seconds = int.Parse(workTimeTextBox.Text);
                    if(seconds<1)
                    {
                        MessageBox.Show("Czas trwania musi być liczba naturalną!");
                    }
                    else
                    {
                        TspAlgorithm tspAlgorithm = new TspAlgorithm();
                        Result result = tspAlgorithm.StartMetaheuristic(filePathTextBox.Text,seconds);
                        TimeTextBox.Text = result.Time.ToString() + " ms";
                        pointsTextBox.Text = result.PointsCount.ToString();
                        distance.Text = result.Distance.ToString();
                        if (result.SortPoints != null)
                        {
                            foreach (Point point in result.SortPoints)
                            {
                                pointsList.Items.Add(string.Format("Id - {0}, X - {1}, Y - {2}", point.Id, point.X, point.Y));
                            }
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Czas trwania musi być liczba naturalną!");

                }

            }
        }

        private void startAlgorithmButton_Click(object sender, EventArgs e)
        {
            if (filePathTextBox.Text == "")
            {
                MessageBox.Show("Nie wybrano pliku");
            }
            else
            {
                TspAlgorithm tspAlgorithm = new TspAlgorithm();
                Result result = tspAlgorithm.Start(filePathTextBox.Text);
                TimeTextBox.Text = result.Time.ToString() + " ms";
                pointsTextBox.Text = result.PointsCount.ToString();
                distance.Text = result.Distance.ToString();
                if (result.SortPoints != null)
                {
                    foreach (Point point in result.SortPoints)
                    {
                        pointsList.Items.Add(string.Format("Id - {0}, X - {1}, Y - {2}", point.Id, point.X, point.Y));
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int pointsCount = int.Parse(numberP.Text);
            List < Point > points = new List<Point>();
            string path = String.Format("TSP_{0}.txt", pointsCount);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                Random random = new Random();
                file.WriteLine(pointsCount.ToString());
                int Id = 1;
                while (points.Count < pointsCount)
                {
                    int x = random.Next(0, 40000);
                    int y = random.Next(0, 40000);
                    if (points.FirstOrDefault(p => p.X == x && p.Y == y) == null)
                    {
                        Point point = new Point()
                        {
                            Id = Id.ToString(),
                            X = x,
                            Y = y
                        };
                        points.Add(point);
                        file.WriteLine(point.Id + " " + point.X + " " + point.Y);
                        Id++;
                    }
                }
            }
        }

        private void pointsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
