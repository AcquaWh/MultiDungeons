using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Talk System/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField, TextArea(3, 6)]
    string lines;

    public string Lines { get => lines; }
}

