using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Talk System/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField, TextArea(3, 6)]
    string lines;
    [SerializeField]
    Sprite ImagenAldeano;
    public string Lines { get => lines; }
}

