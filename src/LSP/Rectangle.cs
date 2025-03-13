namespace AgilePrinciples.LSP {
    public struct Point {
        double x;
        double y;
    }

    public class Rectangle {
        private Point topLeft;
        private double width;
        private double height;

        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
    }

    public class Square : Rectangle {
        public override double Width {
            set {
                base.Width = value;
                base.Height = value;
            }
        }

        public override double Height {
            set {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
