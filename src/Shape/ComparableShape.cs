using System;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.ComparableShape {
    public interface Shape : IComparable<Shape> {
        void Draw();
    }

    public class Square : Shape {
        public void Draw() {
        }

        public int CompareTo(Shape o) {
            return 0;
        }
    }

    public class Circle : Shape {
        public void Draw() {
        }

        /// <summary>
        /// Not so good.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(Shape o) {
            if (o is Square) {
                return -1;
            }
            else {
                return 0;
            }
        }
    }

    public class S {
        public static void DrawAllShapes(List<Shape> shapes) {
            shapes.Sort();
            foreach (var shape in shapes) {
                shape.Draw();
            }
        }
    }
}
