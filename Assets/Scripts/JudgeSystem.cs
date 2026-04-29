using UnityEngine;

public class JudgeSystem : MonoBehaviour
{
    int JudgeValue(int player, int target)
    {
        int diff = Mathf.Abs(player - target);

        if (diff == 0) return 100;
        if (diff == 1) return 70;
        if (diff == 2) return 40;
        return 0;
    }

    public void Serve()
    {
        var order = GameManager.Instance.currentOrder;
        var cup = GameManager.Instance.currentCup;

        int score = 0;

        score += JudgeValue(cup.iceAmount, order.iceAmount);
        score += JudgeValue(cup.syrupAmount, order.syrupAmount);
        score += JudgeValue(cup.toppingCount, order.toppingCount);

        GameManager.Instance.ServeSuccess(score);
    }
}