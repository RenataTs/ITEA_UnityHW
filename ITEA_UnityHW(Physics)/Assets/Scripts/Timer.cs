using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject catapult;
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    private int duration = 3;
    private int remainingDuration;

    private bool Pause;

    public void Being()
    {
        remainingDuration = duration;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            
            yield return null;
        }

        OnEnd();
    }

    private void OnEnd()
    {
        catapult.GetComponent<Fling>().Explode();
    }
}