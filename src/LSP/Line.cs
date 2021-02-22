namespace AgileSoftwareDevelopment.LSP {
    public abstract class LinearObject {
        private Point p1;
        private Point p2;

        public double Slope { get; }
        public double YIntercept { get; }

        public LinearObject(Point p1, Point p2) {
            this.p1 = p1;
            this.p2 = p2;
        }

        public virtual bool IsOn(Point p) {
            return false;
        }
    }

    public class Line : LinearObject {
        public Line(Point p1, Point p2) : base(p1, p2) { }

        public override bool IsOn(Point p) {
            return false;
        }
    }

    public class LineSegment : LinearObject {
        public LineSegment(Point p1, Point p2) : base(p1, p2) { }

        public double GetLength() {
            return 0.0;
        }

        public override bool IsOn(Point p) {
            return false;
        }
    }

    public class Ray : LinearObject {
        public Ray(Point p1, Point p2) : base(p1, p2) { }

        public override bool IsOn(Point p) {
            return false;
        }
    }

    public class Base {
        public virtual void f() { }
    }

    public class Derived : Base {
        public override void f() { }
    }
}
