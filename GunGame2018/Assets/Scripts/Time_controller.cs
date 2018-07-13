using UnityEngine;
using UnityEngine.UI;

public class Time_controller : MonoBehaviour
{
    [SerializeField]
    private Text uiText;

    [SerializeField]
    private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool stop = false;

    private int displayTime;

    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !stop)
        {
            canCount = false;
            uiText.text = "0";
            timer = 0.0f;
            stop = true;
        }
    }
}