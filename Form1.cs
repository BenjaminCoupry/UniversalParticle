using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace UniversalParticle
{
    public partial class Form1 : Form
    {
        
        public static double zoom =1.0;
        public static double Xoffset = 0;
        public static double Yoffset = 0;
        public static int Frame = 0;
        Coord[,] Data = simulate();
        public Form1()
        {
            InitializeComponent();
            Bitmap Frm = new Bitmap(screen.Width, screen.Height);
            screen.Image = (Image)Frm;
        }
        
        
        public static Bitmap GenerateBitmap(int xd, int yd, int frame, double zoom, double Xo, double Yo, Coord[,] datas,bool lg)
        {
            Bitmap Frm = new Bitmap(xd, yd);
            for (int Part = 0; Part < datas.GetLength(1); Part++)
            {
                double xa = (zoom*(datas[frame,Part].X));
                int Xaff;
                double ya = (zoom * (datas[frame, Part].Y ));
                int Yaff;
                double za = zoom * datas[frame, Part].Z;
                double Zaff;
                if (lg)
                {
                    double dist = Math.Sqrt(xa * xa + ya * ya);
                    double LogDist = Math.Log10(1.0 + dist);
                    double Teta = Math.Sign(ya)*Math.Acos(xa/dist);
                    Xaff = (int)(LogDist*Math.Cos(Teta) - Xo);
                    Yaff = yd - (int)(LogDist*Math.Sin(Teta) - Yo);
                    Zaff = 1.0 / (1.0 + Math.Exp(za/10));
                }
                else
                {
                    Xaff = (int)(xa-Xo);
                    Yaff = yd - (int)(ya-Yo);
                    Zaff = 1.0 / (1.0 + Math.Exp(za));
                }
                
                if(((Xaff>=0)&&(Xaff<xd))&&((Yaff>=0)&&(Yaff<yd)))
                {
                Frm.SetPixel(Xaff, Yaff, Color.FromArgb((int)(100+154.0 * Zaff), 0, 0));
                }
            }
            
            return Frm;
        }
        public static Coord[,] simulate()
        {
            
            int timeFrames = 100;
            int Types = 5;
            int partNum = 100;
            double dt=0.005;
            int MaxDegree = 5;
            bool allowPositiveDegree = false;
            bool ReciprocalInteractions = true;
            Coord[,] Out = new Coord[timeFrames,partNum];
            Random rand = new Random();
            Interaction[,] interactionsList = GenerateInteractions(Types,rand,MaxDegree,allowPositiveDegree,ReciprocalInteractions);
            Particle[] ParticleList=GenerateParticleList(partNum,Types,rand);
            for (int T = 0; T < timeFrames; T++)
            {
                double t = T * dt;
                Console.WriteLine("Time : " + t + "  Frame : " + T);
                Coord[] ExtractedGraphData = Graphics(ParticleList);
                for (int q = 0; q < partNum; q++)
                {
                    Out[T, q] = ExtractedGraphData[q];
                }
                for (int Concernd = 0; Concernd < ParticleList.Length; Concernd++)  
                {
                    Particle concerned = ParticleList[Concernd];
                    for (int Dest = 0; Dest < ParticleList.Length; Dest++)
                    {
                        
                        if(Concernd!= Dest)
                        {
                            Particle dest = ParticleList[Dest];
                            double distX = dest.x-concerned.x;
                            double distY = dest.y-concerned.y;
                            double distZ = dest.z-concerned.z;
                            double Dist = Math.Sqrt(Math.Pow((distX), 2) + Math.Pow(distY, 2) + Math.Pow(distZ, 2));
                            double Intensity = interactionsList[concerned.type, dest.type].GetIntensity(dest.charge, concerned.charge, Dist);
                            ParticleList[Concernd].Moove(dt, distX / Dist * Intensity, distY / Dist * Intensity, distZ / Dist * Intensity);
                        }
                    }
                }
                for (int Concernd = 0; Concernd < ParticleList.Length; Concernd++)
                {
                    ParticleList[Concernd].ApplyMoove(dt);
                }
                
            }
            
            return Out;
        }
        public static Interaction[,] GenerateInteractions(int TypesNum, Random rand, int degreeRang, bool AllowPosPow, bool Simmetry)
        {
            Interaction[,] interactionList = new Interaction[TypesNum, TypesNum];
            for (int i = 0; i < TypesNum; i++)
            {
                for (int j = 0; j < TypesNum; j++)
                {
                    
                        Interaction Local = new Interaction();
                        if (Simmetry)
                        {
                            if (i <= j)
                            {
                                Local.GenerateRandom(rand, degreeRang, AllowPosPow);

                            }
                            else
                            {
                                Local = interactionList[j, i];
                            }
                        }
                        else
                        {
                            Local.GenerateRandom(rand, degreeRang, AllowPosPow);
                        }
                        
                        interactionList[i, j] = Local;
                    
                }
            }
            return interactionList;
        }
        public static Particle[] GenerateParticleList(int N, int TypesNum, Random rand)
        {
            
            Particle[] Particles = new Particle[N];
            for (int i = 0; i < N; i++)
            {
                double x = rand.NextDouble() * 2.0 - 1.0;
                double y = rand.NextDouble() * 2.0 - 1.0;
                double z = rand.NextDouble() * 2.0 - 1.0;
                double mass = rand.NextDouble();
                double Charge = rand.NextDouble() * 2.0 - 1.0;
                int type = rand.Next(0, TypesNum);
                Particles[i] = new Particle(x,y,z,mass,Charge,type);
            }
            return Particles;
        }
        public static Coord[] Graphics(Particle[] Inputs)
        {
            int l= Inputs.Length;
            Coord[] TimeData = new Coord[l];
            for (int i = 0; i <l ; i++)
            {
                Coord Local = new Coord();
                Local.X= Inputs[i].x;
                Local.Y = Inputs[i].y;
                Local.Z = Inputs[i].z;
                TimeData[i] = Local;
            }
            return TimeData;
        }

        
        
        private void OfUp_Click(object sender, EventArgs e)
        {
            Yoffset += MoveScale.Value;
            Yoff.Text = "Yoffset : " + Yoffset;
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data,LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void OfLeft_Click(object sender, EventArgs e)
        {
            Xoffset -= MoveScale.Value;
            Xoff.Text = "Xoffset : " + Xoffset;
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void OfDown_Click(object sender, EventArgs e)
        {
            Yoffset -=  MoveScale.Value;
            Yoff.Text = "Yoffset : " + Yoffset;
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void OfRight_Click(object sender, EventArgs e)
        {
            Xoffset += MoveScale.Value;
            Xoff.Text = "Xoffset : " + Xoffset;
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            zoom *= 1.5;
            if (zoom >= 1)
            {
                zm.Text = "Zoom : " + (int)zoom + "x";
            }
            else
            {
                zm.Text = "Zoom : " + ((float)((int)(10000.0*zoom)))/10000.0 + "x";
            }
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            zoom *= 0.5;
            if (zoom >= 1)
            {
                zm.Text = "Zoom : " + (int)zoom + "x";
            }
            else
            {
                zm.Text = "Zoom : " + ((float)((int)(10000.0 * zoom))) / 10000.0 + "x";
            }
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void LstFrm_Click(object sender, EventArgs e)
        {
            Frame -= 1;
            if (Frame < 0)
            {
                Frame = 0;
            }
            TimeReal.Text = "Time : " + Frame;
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void NxtFrm_Click(object sender, EventArgs e)
        {
            Frame += 1;
            Frame = Frame % Data.GetLength(0);
            TimeReal.Text = "Time : " + Frame;
            Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, Frame, zoom, Xoffset, Yoffset, Data, LogView.Checked);
            screen.Image = (Image)Frm;
        }

        private void ply_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                
                Bitmap Frm = GenerateBitmap(screen.Width, screen.Height, i, zoom, Xoffset, Yoffset, Data, LogView.Checked);
                System.Threading.Thread.Sleep(10);
                TimeReal.Text = "Time : " + i;
                TimeReal.Refresh();
                screen.Image = (Image)Frm;
                screen.Refresh();
                
            }
        }
    }
    
    
    public class Particle
    {
        public double x;
        public double y;
        public double z;
        double dx = 0;
        double dy = 0;
        double dz = 0;
        public double mass;
        public double charge;
        public int type;
        public Particle(double x_, double y_, double z_, double mass_, double charge_, int type_)
        {
            x = x_;
            y = y_;
            z = z_;
            mass = mass_;
            charge = charge_;
            type = type_;
        }
        public void Moove (double dt,double ddx, double ddy,double ddz)
        {
            if ((!double.IsNaN(ddx)) && (!double.IsNaN(ddy)) && (!double.IsNaN(ddz)))
            {
                dx += dt * ddx / mass;
                dy += dt * ddy / mass;
                dz += dt * ddz / mass;
            }
            

        }
        public void ApplyMoove(double dt)
        {
            if ((!double.IsNaN(dx)) && (!double.IsNaN(dy)) && (!double.IsNaN(dz)))
            {
                x += dx * dt;
                y += dy * dt;
                z += dz * dt;
            }
        }
    }
    public class Interaction
    {
        List<double> Coeffs = new List<double>();
        List<int> Degrees = new List<int>();
        public double GetIntensity(double charge1, double charge2, double dist)
        {
            double intensity = 0;
            if (dist != 0)
            {
               
                for (int i = 0; i < Coeffs.Count; i++)
                {
                    intensity += Coeffs.ElementAt(i) * Math.Pow(dist, Degrees.ElementAt(i));
                }
                intensity = intensity * charge1 * charge2;
                
            }
            return intensity;
        }
        public void GenerateRandom(Random rand, int degreeRange, bool AllowPositiveDegree)
        {
            int DegreeNum = rand.Next(1, 10);
            int MaxDegree;
            if (AllowPositiveDegree)
            { 
                MaxDegree=rand.Next(1, degreeRange);
            }
            else
            {
                MaxDegree = 0;
            }
            int MinDegree = -1*rand.Next(1, degreeRange);
            for (int i = 0; i < DegreeNum; i++)
            {
                Coeffs.Add(rand.NextDouble() * 2.0 - 1);
                Degrees.Add(rand.Next(MinDegree,MaxDegree));
            }
        }
    }
    public class Coord
    {
        public double X;
        public double Y;
        public double Z;
    }
    
}
