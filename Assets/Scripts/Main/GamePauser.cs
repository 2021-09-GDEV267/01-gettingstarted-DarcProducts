using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GamePauser : MonoBehaviour
{
    [SerializeField] InputActionReference pauseAction;
    bool gamePaused = false;

    public UnityEvent OnGamePaused;
    public UnityEvent OnGameContinued;

    void OnEnable() => pauseAction.action.performed += GamePause;

    void OnDisable() => pauseAction.action.performed -= GamePause;

    private void GamePause(InputAction.CallbackContext obj)
    {
        switch (gamePaused)
        {
            case true:
                Time.timeScale = 1;
                OnGameContinued?.Invoke();
                gamePaused = false;
                break;

            case false:
                Time.timeScale = 0;
                OnGamePaused?.Invoke();
                gamePaused = true;
                break;
        }
    }
}