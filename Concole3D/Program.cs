using System;
using System.Collections.Generic;

namespace Console3D
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            int width = 120;
            int height = 30;
            double aspect = (double)width / height;
            double pixelAspect = 11.0d / 24.0d;
            string gradient = " .:!/r(l1Z4H9W8$@";
            char[] screen = new char[width * height + 1];
            screen[width * height] = '\0';

            for (int t = 0; t < 10000; t++)
            {
                Vec3 spherePos = new Vec3(0, 3, 0);
                Vec3 light = VectorFunc.Normalize(new Vec3(Math.Sin(t * 0.001), Math.Cos(t * 0.001),1));
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Vec2 uv = new Vec2(i, j) / new Vec2(width, height) * 2.0d - 1.0d;
                        uv.X *= aspect * pixelAspect;
                        Vec3 ro = new Vec3(-2, 0, 0);
                        Vec3 rd = VectorFunc.Normalize(new Vec3(1, uv));

                        char pixel;
                        int color = 0;
                        //double minIt = 99999;
                        Vec2 intersection = VectorFunc.Sphere(ro, rd, 1);
                        Vec3 n;
                        if (intersection.X > 0)
                        {
                            Vec3 itPoint = ro + rd * intersection.X;
                            //minIt = intersection.X;
                            n = VectorFunc.Normalize(itPoint);
                            double diff = VectorFunc.Dot(n, light) * 0.5 + 0.5;
                            //ro = ro + rd * (minIt - 0.01);
                            color = (int)(diff * 20);

                        }
                        
                        color = (int)VectorFunc.Clamp(color, 0, gradient.Length - 1);
                        pixel = gradient[color];
                        screen[i + j * width] = pixel;
                    }
                }
                Console.Write(screen);
                Console.SetCursorPosition(0, 0);
            }

            Console.ReadKey();
        }
    }
}
