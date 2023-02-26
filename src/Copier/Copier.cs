namespace AgileSoftwareDevelopment.Copier;

public interface Reader {
    int Read();
}

public class Keyboard {
    public static int Read() {
        return 0;
    }
}

public class Printer {
    public static void Write(int c) {
    }
}

public class KeyboardReader : Reader {
    public int Read() {
        return Keyboard.Read();
    }
}

public class Copier {
    private static readonly Reader reader = new KeyboardReader();

    public static void Copy() {
        int c;
        while ((c = reader.Read()) != -1) {
            Printer.Write(c);
        }
    }
}
