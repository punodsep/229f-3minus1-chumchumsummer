using UnityEngine;

public class JudgeSystem : MonoBehaviour
{
    int IceJudgeValue(int player, int target)
    {
        int diff = Mathf.Abs(player - target);

        if (diff >= 0 && diff <= 10) return 10;
        if (diff >= 11 && diff <= 20) return 8;
        if (diff >= 21) return 5;
        return 0;
    }

    int SyrupJudgeValue(int player, int target)
    {
        int diff = Mathf.Abs(player - target);

        if (diff >= 0 && diff <= 5) return 10;
        if (diff >= 6 && diff <= 10) return 8;
        if (diff >= 11) return 5;
        return 0;
    }

    int ToppingJudgeValue(int player, int target)
    {
        int diff = Mathf.Abs(player - target);

        if (diff == 0) return 10;
        if (diff == 1) return 8;
        if (diff == 2) return 5;
        return 0;
    }

    string GetGrade(int score)
    {
        if (score >= 27) return "Perfect";
        if (score >= 18) return "Good";
        return "OK";
    }

    public void Serve()
    {
        var order = GameManager.Instance.currentOrder;
        var cup = GameManager.Instance.currentCup;

        int score = 0;

        score += IceJudgeValue(cup.iceAmount, order.iceAmount);
        score += SyrupJudgeValue(cup.syrupAmount, order.syrupAmount);
        score += ToppingJudgeValue(cup.toppingCount, order.toppingCount);

        string grade = GetGrade(score);

        GameManager.Instance.lastScore = score;
        GameManager.Instance.lastGrade = grade;
        GameManager.Instance.showResult = true;

        GameManager.Instance.ServeSuccess(score);
    }
}