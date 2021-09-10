using UnityEngine;

[CreateAssetMenu(menuName = "Variables/New Vector2 Variable")]
public class GlobalVector2Variable : ScriptableObject
{
    [Header("Value Changes Dynamically")]
    [SerializeField] Vector2 value;

    [Space(16)]
    [SerializeField] bool reset;

    [SerializeField] bool resetOnEnableElseDisable;

    void OnEnable()
    {
        if (reset && resetOnEnableElseDisable)
            value = Vector2.zero;
    }

    void OnDisable()
    {
        if (reset && !resetOnEnableElseDisable)
            value = Vector2.zero;
    }

    public Vector2 Value
    {
        get { return value; }
        set { this.value = value; }
    }
}