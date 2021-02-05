using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Composite {
    public class CompositeShape : Shape {
        private readonly List<Shape> itsShapes = new();

        public void Add(Shape s) {
            itsShapes.Add(s);
        }

        public void Draw() {
            foreach (var shape in itsShapes) {
                shape.Draw();
            }
        }
    }
}
