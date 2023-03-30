namespace AgileSoftwareDevelopment.SingletonAndMonostate;

public sealed class Singleton {
    public static readonly Singleton Instance = new Singleton();

    private Singleton() {
    }
}

/// <summary>
/// Lazy initialization.
/// </summary>
public sealed class Singleton5 {
    public static readonly Singleton5 Instance = Nested.Instance;

    private Singleton5() {
    }

    class Nested {
        internal static readonly Singleton5 Instance = new Singleton5();

        static Nested() {
        }
    }
}
