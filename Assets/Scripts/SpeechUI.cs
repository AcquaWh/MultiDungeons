using UnityEngine;
using UnityEngine.UI;

public class SpeechUI : MonoBehaviour
{
    [SerializeField]
    Image img_profile;
    [SerializeField]
    Text txt_Box;

    public Sprite profile { set => img_profile.sprite = value; }
    public string message { set => txt_Box.text = value; }
}

