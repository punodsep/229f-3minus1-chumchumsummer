using UnityEngine;

public class JudgeSystem : MonoBehaviour
{
    private void Awake()
    {
        GameObject cupPosObj = GameObject.Find("CupOrderScenePos");

        if (cupPosObj == null) return;

        GameObject cup = GameObject.Find("CupManager(Clone)");

        if (cup != null)
        {
            cup.transform.position = cupPosObj.transform.position;
        }
    }
    int IceJudgeValue(int player, int target)
    {
        int diff = Mathf.Abs(player - target);

        if (diff >= 0 && diff <= 10) return 10;
        if (diff >= 11 && diff <= 20) return 8;
        if (diff >= 21 && diff <= 30) return 5;
        return 0;
    }

    int SyrupJudgeValue(int player, int target)
    {
        int diff = Mathf.Abs(player - target);

        if (diff >= 0 && diff <= 5) return 10;
        if (diff >= 6 && diff <= 10) return 8;
        if (diff >= 11 && diff <= 15) return 5;
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
        if (score >= 27) return "เริ่ดเลยล่ะคับ!!";
        if (score >= 18) return "ก็พอกินได้ฮะ";
        return "ไม่เหมือน\nที่สั่งหนิลุง";
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

        GameObject customer = GameManager.Instance.GetCurrentCustomer();

        if (customer != null)
        {
            CustomerVisual visual = customer.GetComponent<CustomerVisual>();

            if (visual != null && score >= 18)
            {
                visual.SetHappy();
            }
        }

        GameManager.Instance.ServeSuccess(score);
    }
}