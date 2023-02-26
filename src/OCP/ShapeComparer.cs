namespace AgileSoftwareDevelopment.OCP.ShapeComparer;

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

/// <summary>
/// A better implementation.
/// </summary>
public class ShapeComparer : IComparer<Shape> {
    private static readonly Dictionary<Type, int> priorities = new();

    static ShapeComparer() {
        priorities.Add(typeof(Circle), 1);
        priorities.Add(typeof(Square), 2);
    }

    private static int PriorityFor(Type type) {
        if (priorities.ContainsKey(type)) {
            return priorities[type];
        } else {
            return 0;
        }
    }

    public int Compare(Shape o1, Shape o2) {
        var priority1 = PriorityFor(o1.GetType());
        var priority2 = PriorityFor(o2.GetType());
        return priority1.CompareTo(priority2);
    }
}

public class S2 {
    public static void DrawAllShapes(List<Shape> shapes) {
        shapes.Sort(new ShapeComparer());
        foreach (var shape in shapes) {
            shape.Draw();
        }
    }
}
