namespace AgileSoftwareDevelopment.OCP.Shape;

public interface Shape {
    void Draw();
}

public class Square : Shape {
    public void Draw() {
    }
}

public class Circle : Shape {
    public void Draw() {
    }
}

public class S {
    public static void DrawAllShapes(IList<Shape> shapes) {
        foreach (var shape in shapes) {
            shape.Draw();
        }
    }
}
