namespace AgilePrinciples.UML {
    public class BubbleSorter {
        public static int Operations { get; set; }

        public static int Sort(int[] array) {
            Operations = 0;
            if (array.Length <= 1) {
                return Operations;
            }

            for (var nextToLast = array.Length - 2; nextToLast >= 0; nextToLast--) {
                for (int index = 0; index <= nextToLast; index++) {
                    CompareAndSwap(array, index);
                }
            }

            return Operations;
        }

        private static void Swap(int[] array, int index) {
            var temp = array[index];
            array[index] = array[index + 1];
            array[index + 1] = temp;
        }

        private static void CompareAndSwap(int[] array, int index) {
            if (array[index] > array[index + 1]) {
                Swap(array, index);
            }
            Operations++;
        }
    }
}
