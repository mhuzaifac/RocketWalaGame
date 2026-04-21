using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;




    float startTimerCount;

    private void Start()
    {
        startTimerCount = GameManager.Instance.GetLevelTime();
    }



    private void LateUpdate()
    {
        CountDown();
    }

    private void CountDown()
    {
        startTimerCount -= Time.deltaTime;
        timerText.text = startTimerCount.ToString()[0..4];
        if (startTimerCount < 0)
        {
            GameManager.Instance.LoadCurrentLevel();
            Debug.Log("game over");
        }
    }
}
