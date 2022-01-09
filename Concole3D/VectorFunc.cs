using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3D
{
    internal static class VectorFunc
    {
        public static double Clamp(double value, double min, double max)
        {
            return Math.Max(Math.Min(value, max), min);
        }
        public static double Sign(double a)
        {
            return a < 0 ? -1 : 1;
        }
        public static Vec3 Sign(Vec3 v)
        {
            return new Vec3(Sign(v.X), Sign(v.Y), Sign(v.Z));
        }
        public static double Step(double edge, double x)
        {
            return x > edge ? 0.0 : 1.0; // мб поменять местами
        }

        public static Vec3 Step(Vec3 edge, Vec3 v)
        {
            return new Vec3(Step(edge.X, v.X), Step(edge.Y, v.Y), Step(edge.Z, v.Z));
        }

        public static double Length(Vec2 v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }
        public static double Length(Vec3 v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static Vec3 Normalize(Vec3 v)
        {
            return v / Length(v);
        }
        public static double Dot(Vec3 a, Vec3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        public static Vec3 Abs(Vec3 v)
        {
            return new Vec3(Math.Abs(v.X), Math.Abs(v.Y), Math.Abs(v.Z));
        }
        public static Vec3 Reflect(Vec3 rd, Vec3 n) 
        { 
            return rd - n * (2 * Dot(n, rd)); 
        }

        public static Vec3 RotateX(Vec3 a, double angle)
        {
            Vec3 b = a;
            b.Z = a.Z * Math.Cos(angle) - a.Y * Math.Sin(angle);
            b.Y = a.Z * Math.Sin(angle) + a.Y * Math.Cos(angle);
            return b;
        }

        public static Vec3 RotateY(Vec3 a, double angle)
        {
            Vec3 b = a;
            b.X = a.X * Math.Cos(angle) - a.Z * Math.Sin(angle);
            b.Z = a.X * Math.Sin(angle) + a.Z * Math.Cos(angle);
            return b;
        }

        public static Vec3 RotateZ(Vec3 a, double angle)
        {
            Vec3 b = a;
            b.X = a.X * Math.Cos(angle) - a.Y * Math.Sin(angle);
            b.Y = a.X * Math.Sin(angle) + a.Y * Math.Cos(angle);
            return b;
        }

        public static Vec2 Sphere(Vec3 ro, Vec3 rd, float r)
        {
            double b = Dot(ro, rd);
            double c = Dot(ro, ro) - r * r;
            double h = b * b - c;
            if (h < 0.0) return new Vec2(-1.0);
            h = Math.Sqrt(h);
            return new Vec2(-b - h, -b + h);
        }

        public static Vec2 Box(Vec3 ro, Vec3 rd, double boxSize, out Vec3? outNormal)
        {
            outNormal = null;
            Vec3 m = new Vec3(1.0) / rd;
            Vec3 n = m * ro;
            Vec3 k = m * boxSize;
            Vec3 t1 = -n - k;
            Vec3 t2 = -n + k;
            double tN = Math.Max(Math.Max(t1.X, t1.Y), t1.Z);
            double tF = Math.Min(Math.Min(t2.X, t2.Y), t2.Z);
            if (tN > tF || tF < 0.0) return new Vec2(-1.0);
            Vec3 yzx = new Vec3(t1.Y, t1.Z, t1.X);
            Vec3 zxy = new Vec3(t1.Z, t1.X, t1.Y);
            outNormal = -Sign(rd) * Step(yzx, t1) * Step(zxy, t1);
            return new Vec2(tN, tF);
        }

        public static double Plane(Vec3 ro, Vec3 rd, Vec3 p, double w)
        {
            return -(Dot(ro, p) + w) / Dot(rd, p);
        }
    }
}

