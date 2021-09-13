using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text collectedText;
    [SerializeField] TMP_Text deathText;
    [SerializeField] TMP_Text winText;
    [SerializeField] int amountCollected = 0;
    [SerializeField] int winAmount = 15;
    [SerializeField] UnityEvent OnWin;
    [SerializeField] UnityEvent OnFullCollect;
    [SerializeField] float afterWinDelay;
    [SerializeField] UnityEvent AfterWinDelayedEvents;

    private void Start()
    {
        if (collectedText != null)
            UpdateCollectText();
        if (winText != null)
            winText.transform.parent.gameObject.SetActive(false);
        if (deathText != null)
            deathText.transform.parent.gameObject.SetActive(false);
    }

    void OnEnable() => PlayerHealth.OnPlayerDied += UpdateDeath;

    void OnDisable()
    {
        CancelInvoke(nameof(InvokeDelayedWinEvent));
        PlayerHealth.OnPlayerDied -= UpdateDeath;
    }

    public void CollectObject()
    {
        amountCollected++;
        UpdateCollectText();
    }

    void UpdateCollectText() => collectedText.text = $"{amountCollected}/{winAmount}";

    public void UpdateDeath() => deathText.transform.parent.gameObject.SetActive(true);

    public void UpdateWin()
    {
        if (winText != null)
        {
            winText.transform.parent.gameObject.SetActive(true);
            OnWin?.Invoke();
            if (amountCollected.Equals(winAmount))
            {
                winText.text = "YOU ARE RIGHT WHERE YOU BELONG! YOU SAVED THE EARTH! AMAZING JOB! THANK YOU FOR PLAYING THIS LONG!";
                OnFullCollect?.Invoke();
            }
            else
                winText.text = "YOU RESTORE BALANCE!\n\n\nTHANK YOU FOR PLAYING!";
            Invoke(nameof(InvokeDelayedWinEvent), afterWinDelay);
        }
    }

    public void InvokeDelayedWinEvent() => AfterWinDelayedEvents?.Invoke();
}
