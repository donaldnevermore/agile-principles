namespace AgileSoftwareDevelopment.Bowling
{
    public class Game
    {
        public int Score => ScoreForFrame(currentFrame);

        private int currentFrame = 0;
        private bool isFirstThrow = true;
        private readonly Scorer scorer = new Scorer();


        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }

        public void Add(int pins)
        {
            scorer.AddThrow(pins);
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
            {
                AdvanceFrame();
            }
            else
            {
                isFirstThrow = false;
            }
        }

        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || !isFirstThrow;
        }

        private bool Strike(int pins)
        {
            return isFirstThrow && pins == 10;
        }


        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
            {
                currentFrame = 10;
            }
        }
    }
}
