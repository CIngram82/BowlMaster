using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour {
    public Text pinCountTextBox;
   
    void Start () {
        pinCountTextBox = GetComponent<Text>();
	}
	

	public void UpdateText (Color color, string scoreAsString) {
        pinCountTextBox.color = color;
        pinCountTextBox.text = scoreAsString;
	}
}
