using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            platform(-10, 0, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-15, 2, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-20, 4, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-25, 6, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-30, 8, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-35, 10, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-40, 12, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-45, 14, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-50, 16, 3, 5, 1, 5, Colors.Beige, mainViewport);
            platform(-55, 18, 3, 5, 1, 5, Colors.Beige, mainViewport);
            ball(-6, 3, 5.3, 1, Colors.MistyRose, mainViewport);
            cube_sparkle(-20, 4, -15, 1, Colors.Red, mainViewport);
            cube_sparkle(-30, 2, -5, 1, Colors.Red, mainViewport);
            cube_sparkle(-40, 15, -10, 2, Colors.Red, mainViewport);
            cube_sparkle(-50, 3, -11, 1, Colors.Red, mainViewport);
            cube_sparkle(-60, 10, -15, 1, Colors.Red, mainViewport);
            cube_sparkle(-20, 4, 15, 1, Colors.Red, mainViewport);
            cube_sparkle(-30, 2, 5, 1, Colors.Red, mainViewport);
            cube_sparkle(-40, 15, 10, 2, Colors.Red, mainViewport);
            cube_sparkle(-50, 3, 11, 1, Colors.Red, mainViewport);
            cube_sparkle(-60, 10, 15, 1, Colors.Red, mainViewport);
        }


        public static void drawTriangle(Point3D p0, Point3D p1, Point3D p2, Color color, Viewport3D viewport)
        {
            // функция рисования тругольника
            MeshGeometry3D mesh = new MeshGeometry3D();

            // добавляем координаты вершин треугольника
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);

            // настраиваем правило буравчика
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            // закрашиваем треугольник и делаем его материал матовым - DiffuseMaterial
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color;
            Material material = new DiffuseMaterial(brush);
            // при желании можно сделать материал блестящим - SpecularMaterial(кисть, степень искристости(double)) или светящимся - EmissiveMaterial

            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            ModelUIElement3D model = new ModelUIElement3D();
            model.Model = geometry;

            viewport.Children.Add(model);
        }

        public static void drawTriangle_sparkle(Point3D p0, Point3D p1, Point3D p2, Color color, Viewport3D viewport)
        {
            // функция рисования тругольника
            MeshGeometry3D mesh = new MeshGeometry3D();

            // добавляем координаты вершин треугольника
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);

            // настраиваем правило буравчика
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            // закрашиваем треугольник и делаем его материал матовым - DiffuseMaterial
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color;
            Material material = new SpecularMaterial(brush,0.098);
            // при желании можно сделать материал блестящим - SpecularMaterial(кисть, степень искристости(double)) или светящимся - EmissiveMaterial

            GeometryModel3D geometry = new GeometryModel3D(mesh, material);
            ModelUIElement3D model = new ModelUIElement3D();
            model.Model = geometry;

            viewport.Children.Add(model);
        }

        // создание вершин треугольника и его отрисовка
        private void Tri(double x1, double y1, double z1,
                         double x2, double y2, double z2,
                         double x3, double y3, double z3, Color color, Viewport3D viewport)
        {
            Point3D[] p = new Point3D[3];
            p[0] = new Point3D(x1, y1, z1);
            p[1] = new Point3D(x2, y2, z2);
            p[2] = new Point3D(x3, y3, z3);
            drawTriangle(p[0], p[1], p[2], color, viewport);
        }


        private void Tri_sparkle(double x1, double y1, double z1,
                         double x2, double y2, double z2,
                         double x3, double y3, double z3, Color color, Viewport3D viewport)
        {
            Point3D[] p = new Point3D[3];
            p[0] = new Point3D(x1, y1, z1);
            p[1] = new Point3D(x2, y2, z2);
            p[2] = new Point3D(x3, y3, z3);
            drawTriangle_sparkle(p[0], p[1], p[2], color, viewport);
        }

        // отрисовка квадрата как двух треугольников
        private void Quad(double x1, double y1, double z1,
                          double x2, double y2, double z2,
                          double x3, double y3, double z3,
                          double x4, double y4, double z4, Color color, Viewport3D viewport)
        {

            Tri(x1, y1, z1, x2, y2, z2, x4, y4, z4, color, viewport);
            Tri(x2, y2, z2, x3, y3, z3, x4, y4, z4, color, viewport);

        }

        private void Quad_sparkle(double x1, double y1, double z1,
                          double x2, double y2, double z2,
                          double x3, double y3, double z3,
                          double x4, double y4, double z4, Color color, Viewport3D viewport)
        {

            Tri_sparkle(x1, y1, z1, x2, y2, z2, x4, y4, z4, color, viewport);
            Tri_sparkle(x2, y2, z2, x3, y3, z3, x4, y4, z4, color, viewport);

        }

        public double x = 11;
        public double y = 10;
        public double z = 9;

        public void redro()
        {
            cam.Position = new Point3D(x, y, z);
        }
        private void cube(double xx, double yx, double zx, double a, Color color, Viewport3D viewport)
        {
            double x1 = xx;
            double y1 = yx;
            double z1 = zx;

            double x2 = xx + a;
            double y2 = yx;
            double z2 = zx;

            double x3 = xx + a;
            double y3 = yx + a;
            double z3 = zx;

            double x4 = xx;
            double y4 = yx + a;
            double z4 = zx;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1 + a;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2 + a;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3 + a;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4 + a;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);
            /*Quad(x1, y1 + r, z1, x1, y1, z1, x1 + r, y1, z1, x1 + r, y1 + r, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1 + r, z1, x1, y1 + r, z1 + r, x1, y1, z1 + r, color, viewport);
            Quad(x1, y1 + r, z1, x1, y1 + r, z1 + r, x1 + r, y1 + r, z1 + r, x1 + r, y1 + r, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1, z1, color, viewport);
            Quad(x1, y1 + r, z1 + r, x1, y1, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1 + r, z1 + r, color, viewport);
            Quad(x1 + r, y1 + r, z1, x1 + r, y1 + r, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1, z1, color, viewport);*/
        }

        private void cube_sparkle(double xx, double yx, double zx, double a, Color color, Viewport3D viewport)
        {
            double x1 = xx;
            double y1 = yx;
            double z1 = zx;

            double x2 = xx + a;
            double y2 = yx;
            double z2 = zx;

            double x3 = xx + a;
            double y3 = yx + a;
            double z3 = zx;

            double x4 = xx;
            double y4 = yx + a;
            double z4 = zx;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1 + a;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2 + a;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3 + a;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4 + a;

            Quad_sparkle(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad_sparkle(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad_sparkle(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad_sparkle(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad_sparkle(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad_sparkle(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);
            /*Quad(x1, y1 + r, z1, x1, y1, z1, x1 + r, y1, z1, x1 + r, y1 + r, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1 + r, z1, x1, y1 + r, z1 + r, x1, y1, z1 + r, color, viewport);
            Quad(x1, y1 + r, z1, x1, y1 + r, z1 + r, x1 + r, y1 + r, z1 + r, x1 + r, y1 + r, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1, z1, color, viewport);
            Quad(x1, y1 + r, z1 + r, x1, y1, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1 + r, z1 + r, color, viewport);
            Quad(x1 + r, y1 + r, z1, x1 + r, y1 + r, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1, z1, color, viewport);*/
        }

        private void platform(double xx, double yx, double zx, double a, double b, double c, Color color, Viewport3D viewport)
        {
            double x1 = xx;
            double y1 = yx;
            double z1 = zx;

            double x2 = xx + a;
            double y2 = yx;
            double z2 = zx;

            double x3 = xx + a;
            double y3 = yx + b;
            double z3 = zx;

            double x4 = xx;
            double y4 = yx + b;
            double z4 = zx;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1 + c;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2 + c;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3 + c;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4 +c;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);
            /*Quad(x1, y1 + r, z1, x1, y1, z1, x1 + r, y1, z1, x1 + r, y1 + r, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1 + r, z1, x1, y1 + r, z1 + r, x1, y1, z1 + r, color, viewport);
            Quad(x1, y1 + r, z1, x1, y1 + r, z1 + r, x1 + r, y1 + r, z1 + r, x1 + r, y1 + r, z1, color, viewport);
            Quad(x1, y1, z1, x1, y1, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1, z1, color, viewport);
            Quad(x1, y1 + r, z1 + r, x1, y1, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1 + r, z1 + r, color, viewport);
            Quad(x1 + r, y1 + r, z1, x1 + r, y1 + r, z1 + r, x1 + r, y1, z1 + r, x1 + r, y1, z1, color, viewport);*/
        }

        private void ball(double xx, double yy, double zz, double r, Color color, Viewport3D viewport)
        {
            Quad(xx + r, yy + r / 2, zz - r / 2, xx + r, yy + r / 2, zz + r / 2, xx + r, yy - r / 2, zz + r / 2, xx + r, yy - r / 2, zz - r / 2, color, viewport);
            Quad(xx + r, yy + r / 2, zz + r / 2, xx + r / 2, yy + r / 2, zz + r, xx + r / 2, yy - r / 2, zz + r, xx + r, yy - r / 2, zz + r / 2, color, viewport);
            Quad(xx + r / 2, yy + r / 2, zz + r, xx - r / 2, yy + r / 2, zz + r, xx - r / 2, yy - r / 2, zz + r, xx + r / 2, yy - r / 2, zz + r, color, viewport);
            Quad(xx + r / 2, yy + r / 2, zz + r, xx + r / 2, yy - r / 2, zz + r, xx - r / 2, yy - r / 2, zz + r, xx - r / 2, yy + r / 2, zz + r, color, viewport);
            //Quad(xx - r / 2, yy + r / 2, zz + r, xx + r / 2, yy + r / 2, zz + r, xx + r / 2, yy - r / 2, zz + r, xx - r / 2, yy - r / 2, zz + r, color, viewport);
            //Quad(xx - r / 2, yy + r / 2, zz + r, xx - r, yy + r / 2, zz + r / 2, xx - r, yy - r / 2, zz + r / 2, xx - r / 2, yy - r / 2, zz + r, color, viewport);
            Quad(xx - r, yy + r / 2, zz + r / 2, xx - r / 2, yy + r / 2, zz + r, xx - r / 2, yy - r / 2, zz + r, xx - r, yy - r / 2, zz + r / 2, color, viewport);
            Quad(xx - r, yy + r / 2, zz - r / 2, xx - r, yy + r / 2, zz + r / 2, xx - r, yy - r / 2, zz + r / 2, xx - r, yy - r / 2, zz - r / 2, color, viewport);
            Quad(xx + r / 2, yy + r / 2, zz - r, xx - r / 2, yy + r / 2, zz - r, xx - r / 2, yy - r / 2, zz - r, xx + r / 2, yy - r / 2, zz - r, color, viewport);
            Quad(xx - r / 2, yy + r / 2, zz - r, xx + r / 2, yy + r / 2, zz - r, xx + r / 2, yy - r / 2, zz - r, xx - r / 2, yy - r / 2, zz - r, color, viewport);
            //Quad(xx - r, yy + r / 2, zz - r / 2, xx - r / 2, yy + r / 2, zz - r, xx - r / 2, yy - r / 2, zz - r, xx - r, yy - r / 2, zz - r / 2, color, viewport);
            Quad(xx - r / 2, yy + r / 2, zz - r, xx - r, yy + r / 2, zz - r / 2, xx - r , yy - r / 2, zz - r/2, xx - r/2, yy - r / 2, zz - r, color,viewport);
            //Quad(xx + r, yy + r / 2, zz - r / 2, xx + r / 2, yy + r / 2, zz - r, xx + r / 2, yy - r / 2, zz - r, xx + r, yy - r / 2, zz - r / 2, color, viewport);
            Quad(xx + r / 2, yy + r / 2, zz - r, xx + r, yy + r / 2, zz - r / 2, xx + r, yy - r / 2, zz - r / 2, xx + r / 2, yy - r / 2, zz - r, color, viewport);
            Vosmiugolnik(xx, yy + r, zz, r / 2, color, viewport);
            Vosmiugolnik(xx, yy - r, zz, r / 2, color, viewport);
            Tri(xx + r, yy + r / 2, zz - r / 2, xx + r / 2, yy + r, zz - r / 4, xx + r, yy + r / 2, zz + r / 2, color, viewport);
            Tri(xx + r, yy + r / 2, zz + r / 2, xx + r / 2, yy + r, zz - r / 4, xx + r / 2, yy + r, zz + r / 4,  color, viewport);
            Tri(xx + r, yy - r / 2, zz - r / 2, xx + r, yy - r / 2, zz + r / 2, xx + r / 2, yy - r, zz - r / 4, color, viewport);
            Tri(xx + r, yy - r / 2, zz + r / 2, xx + r / 2, yy - r, zz + r / 4, xx + r / 2, yy - r, zz - r / 4, color, viewport);

            Tri(xx - r, yy - r / 2, zz + r / 2, xx - r / 2, yy - r, zz + r / 4, xx - r, yy - r / 2, zz - r / 2, color, viewport);
            Tri(xx - r, yy - r / 2, zz - r / 2, xx - r / 2, yy - r, zz + r / 4, xx - r / 2, yy - r, zz - r / 4,  color, viewport);
            Tri(xx - r, yy + r / 2, zz + r / 2, xx - r / 2, yy + r, zz + r / 4, xx - r, yy + r / 2, zz - r / 2, color, viewport);
            Tri(xx - r, yy + r / 2, zz - r / 2, xx - r / 2, yy + r, zz + r / 4, xx - r / 2, yy + r, zz - r / 4, color, viewport);
            Tri(xx - r, yy + r / 2, zz + r / 2, xx - r, yy + r / 2, zz - r / 2, xx - r / 2, yy + r, zz + r / 4, color, viewport);
            Tri(xx - r, yy + r / 2, zz - r / 2, xx - r / 2, yy + r, zz - r / 4, xx - r / 2, yy + r, zz + r / 4, color, viewport);

            Tri(xx - r, yy + r / 2, zz + r / 2, xx - r / 2, yy + r, zz + r / 4, xx - r / 2, yy + r / 2, zz + r, color, viewport);
            Tri(xx - r / 2, yy + r, zz + r / 4, xx - r / 4, yy + r, zz + r / 2, xx - r / 2, yy + r / 2, zz + r, color,viewport);
            Tri(xx - r, yy - r / 2, zz + r / 2, xx - r / 2, yy - r / 2, zz + r, xx - r / 2, yy - r, zz + r / 4, color, viewport);
            Tri(xx - r / 2, yy - r, zz + r / 4, xx - r / 2, yy - r / 2, zz + r, xx - r / 4, yy - r, zz + r / 2, color, viewport);

            Tri(xx - r, yy + r / 2, zz - r / 2, xx - r / 2, yy + r / 2, zz - r, xx - r / 2, yy + r, zz - r / 4, color, viewport);
            Tri(xx - r / 2, yy + r, zz - r / 4, xx - r / 2, yy + r / 2, zz - r, xx - r / 4, yy + r, zz - r / 2, color, viewport);
            Tri(xx - r, yy - r / 2, zz - r / 2, xx - r / 2, yy - r, zz - r / 4, xx - r / 2, yy - r / 2, zz - r, color, viewport);
            Tri(xx - r / 2, yy - r, zz - r / 4, xx - r / 4, yy - r, zz - r / 2, xx - r / 2, yy - r / 2, zz - r, color, viewport);

            Tri(xx + r / 2, yy + r / 2, zz + r, xx - r / 4, yy + r, zz + r / 2, xx - r / 2, yy + r / 2, zz + r, color, viewport);
            Tri(xx + r / 2, yy + r / 2, zz + r, xx + r / 4, yy + r, zz + r / 2, xx - r / 4, yy + r, zz + r/2, color, viewport);
            Tri(xx + r / 2, yy + r / 2, zz + r, xx - r / 4, yy + r, zz + r / 2, xx + r / 4, yy + r, zz + r / 2, color, viewport);
            Tri(xx + r / 2, yy + r / 2, zz + r, xx - r / 2, yy + r / 2, zz + r, xx - r / 4, yy + r, zz + r / 2,color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz + r, xx - r / 4, yy - r, zz + r / 2, xx - r / 2, yy - r / 2, zz + r, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz + r, xx + r / 4, yy - r, zz + r / 2, xx - r / 4, yy - r, zz + r / 2, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz + r, xx - r / 4, yy - r, zz + r / 2, xx + r / 4, yy - r, zz + r / 2, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz + r, xx - r / 2, yy - r / 2, zz + r, xx - r / 4, yy - r, zz + r / 2, color, viewport);

            Tri(xx + r, yy + r / 2, zz + r / 2, xx + r / 2, yy + r, zz + r / 4, xx + r / 2, yy + r / 2, zz + r, color, viewport);
            Tri(xx + r / 2, yy + r, zz + r / 4, xx + r / 4, yy + r, zz + r / 2, xx + r / 2, yy + r / 2, zz + r, color, viewport);
            Tri(xx + r, yy - r / 2, zz + r / 2, xx + r / 2, yy - r / 2, zz + r, xx + r / 2, yy - r, zz + r / 4, color, viewport);
            Tri(xx + r / 2, yy - r, zz + r / 4, xx + r / 2, yy - r / 2, zz + r, xx + r / 4, yy - r, zz + r / 2, color, viewport);

            Tri(xx + r / 2, yy + r / 2, zz - r, xx - r / 4, yy + r, zz - r / 2, xx - r / 2, yy + r / 2, zz - r, color, viewport);
            Tri(xx + r / 2, yy + r / 2, zz - r, xx + r / 4, yy + r, zz - r / 2, xx - r / 4, yy + r, zz - r / 2, color, viewport);
            Tri(xx + r / 2, yy + r / 2, zz - r, xx - r / 4, yy + r, zz - r / 2, xx + r / 4, yy + r, zz - r / 2, color, viewport);
            Tri(xx + r / 2, yy + r / 2, zz - r, xx - r / 2, yy + r / 2, zz - r, xx - r / 4, yy + r, zz - r / 2, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz - r, xx - r / 4, yy - r, zz - r / 2, xx - r / 2, yy - r / 2, zz - r, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz - r, xx + r / 4, yy - r, zz - r / 2, xx - r / 4, yy - r, zz - r / 2, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz - r, xx - r / 4, yy - r, zz - r / 2, xx + r / 4, yy - r, zz - r / 2, color, viewport);
            Tri(xx + r / 2, yy - r / 2, zz - r, xx - r / 2, yy - r / 2, zz - r, xx - r / 4, yy - r, zz - r / 2, color, viewport);

            Tri(xx + r, yy + r / 2, zz - r / 2, xx + r / 2, yy + r / 2, zz - r, xx + r / 2, yy + r, zz - r / 4, color, viewport);
            Tri(xx + r / 2, yy + r, zz - r / 4, xx + r / 2, yy + r / 2, zz - r, xx + r / 4, yy + r, zz - r / 2, color, viewport);
            Tri(xx + r, yy - r / 2, zz - r / 2, xx + r / 2, yy - r, zz - r / 4, xx + r / 2, yy - r / 2, zz - r, color, viewport);
            Tri(xx + r / 2, yy - r, zz - r / 4, xx + r / 4, yy - r, zz - r / 2, xx + r / 2, yy - r / 2, zz - r, color, viewport);

        }

        private void Vosmiugolnik(double xx, double yy, double zz, double r, Color color, Viewport3D viewport)
        {
            Tri(xx, yy, zz, xx + r, yy, zz - r/2, xx + r, yy, zz + r/2, color, viewport);
            Tri(xx, yy, zz,  xx + r, yy, zz + r / 2, xx + r, yy, zz - r / 2, color, viewport);
            Tri(xx, yy, zz, xx + r, yy, zz + r / 2, xx + r / 2, yy, zz + r, color, viewport);
            Tri(xx, yy, zz, xx + r / 2, yy, zz + r, xx + r, yy, zz + r / 2, color, viewport);
            Tri(xx, yy, zz, xx + r / 2, yy, zz + r, xx - r / 2, yy, zz + r, color, viewport);
            Tri(xx, yy, zz, xx - r / 2, yy, zz + r, xx + r / 2, yy, zz + r, color, viewport);
            Tri(xx, yy, zz, xx - r / 2, yy, zz + r, xx - r, yy, zz + r / 2, color, viewport);
            Tri(xx, yy, zz, xx - r, yy, zz + r / 2, xx - r / 2, yy, zz + r, color, viewport);
            Tri(xx, yy, zz, xx - r, yy, zz + r / 2, xx - r, yy, zz - r / 2, color, viewport);
            Tri(xx, yy, zz, xx - r, yy, zz - r / 2, xx - r, yy, zz + r / 2, color, viewport);
            Tri(xx, yy, zz, xx - r, yy, zz - r / 2, xx - r / 2, yy, zz - r, color, viewport);
            Tri(xx, yy, zz, xx - r / 2, yy, zz - r, xx - r, yy, zz - r / 2, color, viewport);
            Tri(xx, yy, zz, xx - r / 2, yy, zz - r, xx + r / 2, yy, zz - r, color, viewport);
            Tri(xx, yy, zz, xx + r / 2, yy, zz - r, xx - r / 2, yy, zz - r, color, viewport);
            Tri(xx, yy, zz, xx + r / 2, yy, zz - r, xx + r, yy, zz - r / 2, color, viewport);
            Tri(xx, yy, zz, xx + r, yy, zz - r / 2, xx + r / 2, yy, zz - r, color, viewport);
        }

        private void piramida(double x, double y, double z, double a, Color color, Viewport3D viewport)
        {
            double x1 = x;
            double y1 = y;
            double z1 = z;

            double x2 = x + a;
            double y2 = y;
            double z2 = z;

            double x3 = x + a / 2;
            double y3 = y + a;
            double z3 = z + a / 2;

            double x4 = x + a / 2;
            double y4 = y + a;
            double z4 = z + a / 2;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1 + a;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2 + a;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);



        }

        private void r_piramida(double x, double y, double z, double a, Color color, Viewport3D viewport)
        {
            double x1 = x + a / 2;
            double y1 = y;
            double z1 = z + a / 2;

            double x2 = x + a / 2;
            double y2 = y;
            double z2 = z + a / 2;

            double x3 = x + a;
            double y3 = y + a;
            double z3 = z;

            double x4 = x;
            double y4 = y + a;
            double z4 = z;

            double x5 = x1;
            double y5 = y1;
            double z5 = z1;

            double x6 = x2;
            double y6 = y2;
            double z6 = z2;

            double x7 = x3;
            double y7 = y3;
            double z7 = z3 + a;

            double x8 = x4;
            double y8 = y4;
            double z8 = z4 + a;

            Quad(x5, y5, z5, x8, y8, z8, x4, y4, z4, x1, y1, z1, color, viewport);
            Quad(x6, y6, z6, x5, y5, z5, x1, y1, z1, x2, y2, z2, color, viewport);
            Quad(x3, y3, z3, x2, y2, z2, x1, y1, z1, x4, y4, z4, color, viewport);
            Quad(x7, y7, z7, x6, y6, z6, x2, y2, z2, x3, y3, z3, color, viewport);
            Quad(x8, y8, z8, x7, y7, z7, x3, y3, z3, x4, y4, z4, color, viewport);
            Quad(x5, y5, z5, x6, y6, z6, x7, y7, z7, x8, y8, z8, color, viewport);



        }
        private void sx_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            x = -sx.Value;
            redro();
        }

        private void sx1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            z = -sx1.Value;
            redro();
        }

        private void sy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            y = -sy.Value;
            redro();
        }
    }
}
