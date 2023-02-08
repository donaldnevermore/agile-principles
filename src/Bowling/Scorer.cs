namespace AgileSoftwareDevelopment.Bowling;

public class Scorer {
    private int ball;
    private int currentThrow;
    private readonly int[] throws = new int[21];

    public void AddThrow(int pins) {
        throws[currentThrow] = pins;
        currentThrow++;
    }

    public int ScoreForFrame(int theFrame) {
        ball = 0;
        var score = 0;
        for (var currentFrame = 0; currentFrame < theFrame; currentFrame++) {
            if (Strike()) {
                score += 10 + NextTwoBallsForStrike();
                ball++;
            }
            else if (Spare()) {
                score += 10 + NextBallForSpare();
                ball += 2;
            }
            else {
                score += TwoBallsInFrame();
                ball += 2;
            }
        }

        return score;
    }

    private bool Strike() => throws[ball] == 10;

    private bool Spare() => throws[ball] + throws[ball + 1] == 10;

    private int NextTwoBallsForStrike() => throws[ball + 1] + throws[ball + 2];

    private int TwoBallsInFrame() => throws[ball] + throws[ball + 1];

    private int NextBallForSpare() => throws[ball + 2];
}
