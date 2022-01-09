using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3D
{
    internal class Vec2
    {
        #region Variables
        double _x;
        double _y;
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
        #endregion


        #region Constructors
        public Vec2(double value)
        {
            _x = value;
            _y = value;
        }
        public Vec2(double x, double y)
        {
            _x = x;
            _y = y;
        }
        #endregion

        #region Operators
        public static Vec2 operator +(Vec2 firstVector, Vec2 secondVector) => new Vec2(firstVector._x + secondVector._x, firstVector._y + secondVector._y);
        public static Vec2 operator +(Vec2 firstVector, double value) => new Vec2(firstVector._x + value, firstVector._y + value);
        public static Vec2 operator -(Vec2 firstVector, Vec2 secondVector) => new Vec2(firstVector._x - secondVector._x, firstVector._y - secondVector._y);
        public static Vec2 operator -(Vec2 firstVector, double value) => new Vec2(firstVector._x - value, firstVector._y - value);
        public static Vec2 operator *(Vec2 firstVector, Vec2 secondVector) => new Vec2(firstVector._x * secondVector._x, firstVector._y * secondVector._y);
        public static Vec2 operator *(Vec2 firstVector, double value) => new Vec2(firstVector._x *value, firstVector._y * value);
        public static Vec2 operator /(Vec2 firstVector, Vec2 secondVector) => new Vec2(firstVector._x / secondVector._x, firstVector._y / secondVector._y);
        public static Vec2 operator /(Vec2 firstVector, double value) => new Vec2(firstVector._x / value, firstVector._y / value);
        #endregion

    }
}
