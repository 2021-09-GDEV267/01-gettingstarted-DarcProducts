using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text collectedText;
    [SerializeField] TMP_Text deathText;
    [SerializeField] TMP_Text winText;
    [SerializeField] int amountCollected = 0;
    [SerializeField] UnityEvent OnFullCollect;

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

    void OnDisable() => PlayerHealth.OnPlayerDied -= UpdateDeath;

    public void CollectObject()
    {
        amountCollected++;
        UpdateCollectText();
    }

    void UpdateCollectText() => collectedText.text = amountCollected.ToString() + "/18";

    public void UpdateDeath() => deathText.transform.parent.gameObject.SetActive(true);

    public void UpdateWin()
    {
        if (winText != null)
        {
            if (amountCollected.Equals(18))
            {
                winText.text = "YOU ARE RIGHT WHERE YOU BELONG! YOU SAVED THE EARTH! AMAZING JOB! THANK YOU FOR PLAYING THIS LONG!";
                OnFullCollect?.Invoke();
            }
            else
                winText.text = "YOU RESTORE BALANCE!\n\n\nTHANK YOU FOR PLAYING!";
        }
    }
}
