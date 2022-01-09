using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3D
{
    internal class Vec3
    {
        #region Variables
        double _x;
        double _y;
        double _z;
        #endregion

        #region Properties
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }
        #endregion


        #region Constructors
        public Vec3(double value)
        {
            _x = value;
            _y = value;
            _z = value;
        }
        public Vec3(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        public Vec3(double x, Vec2 vector)
        {
            _x = x;
            _y = vector.X;
            _z = vector.Y;
        }
        #endregion

        #region Operators
        public static Vec3 operator +(Vec3 firstVector, Vec3 secondVector) => new Vec3(firstVector._x + secondVector._x, firstVector._y + secondVector._y, firstVector._z + secondVector._z);
        public static Vec3 operator -(Vec3 firstVector, Vec3 secondVector) => new Vec3(firstVector._x - secondVector._x, firstVector._y - secondVector._y, firstVector._z - secondVector._z);
        public static Vec3 operator *(Vec3 firstVector, Vec3 secondVector) => new Vec3(firstVector._x * secondVector._x, firstVector._y * secondVector._y, firstVector._z * secondVector._z);
        public static Vec3 operator *(Vec3 firstVector, double value) => new Vec3(firstVector._x * value, firstVector._y * value, firstVector._z * value);
        public static Vec3 operator /(Vec3 firstVector, Vec3 secondVector) => new Vec3(firstVector._x / secondVector._x, firstVector._y / secondVector._y, firstVector._z / secondVector._z);
        public static Vec3 operator /(Vec3 firstVector, double value) => new Vec3(firstVector._x / value, firstVector._y / value, firstVector._z / value);
        public static Vec3 operator -(Vec3 vector) => new Vec3(-vector._x, -vector._y, -vector._z);


        #endregion

    }
}
