using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Variables/New Bool Variable")]
public class GlobalBoolVariable : ScriptableObject
{
    public UnityAction<bool> OnValueChanged;
    [Header("Value set dynamically")]
    [SerializeField] bool value;
    [Space(16)]
    [SerializeField] bool resetVaue;
    [SerializeField] bool resetTrueElseFalse;
    [SerializeField] bool resetOnEnableElseDisable;

    void OnEnable()
    {
        if (resetVaue && resetOnEnableElseDisable)
        {
            if (resetTrueElseFalse)
                this.value = true;
            else
                this.value = false;
        }
    }

    void OnDisable()
    {
        if (resetVaue && !resetOnEnableElseDisable)
        {
            if (resetTrueElseFalse)
                this.value = true;
            else
                this.value = false;
        }
    }

    public bool Value
    {
        get { return value; }
        set
        {
            this.value = value;
            OnValueChanged?.Invoke(this.value);
        }
    }
}
