namespace AgilePrinciples.PrimeGenerator;

public static class PrimeGenerator {
    private static bool[] crossedOut;
    private static int[] result;

    public static int[] GeneratePrimeNumbers(int maxValue) {
        if (maxValue < 2) {
            return Array.Empty<int>();
        } else {
            UncrossIntegersUpTo(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();
            return result;
        }
    }

    private static void UncrossIntegersUpTo(int maxValue) {
        crossedOut = new bool[maxValue + 1];
        for (var i = 2; i < crossedOut.Length; i++) {
            crossedOut[i] = false;
        }
    }

    private static void PutUncrossedIntegersIntoResult() {
        result = new int[NumberOfUncrossedIntegers()];

        for (int j = 0, i = 2; i < crossedOut.Length; i++) {
            if (NotCrossed(i)) {
                result[j] = i;
                j++;
            }
        }
    }

    private static int NumberOfUncrossedIntegers() {
        var count = 0;
        for (var i = 2; i < crossedOut.Length; i++) {
            if (NotCrossed(i)) {
                count++;
            }
        }

        return count;
    }

    private static bool NotCrossed(int i) {
        return crossedOut[i] == false;
    }

    private static void CrossOutMultiples() {
        var limit = DetermineIterationLimit();

        for (var i = 2; i <= limit; i++) {
            if (NotCrossed(i)) {
                CrossOutMultiplesOf(i);
            }
        }
    }

    private static void CrossOutMultiplesOf(int i) {
        for (var multiple = 2 * i; multiple < crossedOut.Length; multiple += i) {
            crossedOut[multiple] = true;
        }
    }

    private static int DetermineIterationLimit() {
        var iterationLimit = Math.Sqrt(crossedOut.Length);
        return (int)iterationLimit;
    }
}
