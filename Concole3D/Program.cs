using System;
using System.Collections.Generic;

namespace Console3D
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            int width = 240;
            int height = 60;
            Console.SetWindowSize(width, height);
            double aspect = (double)width / height;
            double pixelAspect = 11.0d / 24.0d;
            string gradient = " .:!/r(l1Z4H9W8$@";
            char[] screen = new char[width * height];


            for (int t = 0; t < 10000; t++)
            {
                Vec3 light = VectorFunc.Normalize(new Vec3(-0.5, 0.5, -1.0));
                Vec3 spherePos = new Vec3(0, 3, 0);

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Vec2 uv = new Vec2(i, j) / new Vec2(width, height) * 2.0d - 1.0d;
                        uv.X *= aspect * pixelAspect;
                        Vec3 ro = new(-5, 0, 0);
                        Vec3 rd = VectorFunc.Normalize(new Vec3(1, uv));
                        ro = VectorFunc.RotateY(ro, 0.25);
                        rd = VectorFunc.RotateY(rd, 0.25);
                        ro = VectorFunc.RotateZ(ro, t * 0.01);
                        rd = VectorFunc.RotateZ(rd, t * 0.01);
                        double diff = 1;
                        for (int reflections = 0; reflections < 5; reflections++)
                        {
                            double minItntersection = double.MaxValue;
                            Vec2 intersection = VectorFunc.Sphere(ro - spherePos, rd, 1);
                            Vec3 n = new Vec3(0);
                            double albedo = 1;
                            if (intersection.X > 0)
                            {
                                Vec3 itPoint = ro - spherePos + rd * intersection.X;
                                minItntersection = intersection.X;
                                n = VectorFunc.Normalize(itPoint);
                                //diff = 1;

                            }
                            Vec3 boxN = new Vec3(0);
                            intersection = VectorFunc.Box(ro, rd, 1, out boxN);
                            if (intersection.X > 0 && intersection.X < minItntersection)
                            {
                                minItntersection = intersection.X;
                                n = boxN;
                                //diff = 1;
                            }
                            intersection = new Vec2(VectorFunc.Plane(ro, rd, new Vec3(0, 0, -1), 1));
                            if (intersection.X > 0 && intersection.X < minItntersection)
                            {
                                minItntersection = intersection.X;
                                n = new Vec3(0, 0, -1);
                                albedo = 0.5;
                            }
                            if (minItntersection < double.MaxValue)
                            {
                                diff *= (VectorFunc.Dot(n, light) * 0.5 + 0.5) * albedo;
                                ro = ro + rd * (minItntersection - 0.01);
                                rd = VectorFunc.Reflect(rd, n);
                            }
                            else
                                break;
                        }
                        int color = (int)(diff * 20);
                        color = (int)VectorFunc.Clamp(color, 0, gradient.Length - 1);
                        char pixel = gradient[color];
                        screen[i + j * width] = pixel;
                    }
                }
                screen[width * height - 1] = '\0';
                Console.Write(screen);
                Console.SetCursorPosition(0, 0);
            }

            Console.ReadKey();
        }
    }
}
