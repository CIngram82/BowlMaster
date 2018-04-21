using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay3 : MonoBehaviour {
    public Text[] rollTexts;
    public Text[] frameTexts;
    public Text pinCountTextBox;
   
    void Start () {
        pinCountTextBox = GetComponent<Text>();
    }

	public void UpdateText (Color color, string scoreAsString) {
        pinCountTextBox.color = color;
        pinCountTextBox.text = scoreAsString;
	}

    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);

        for(int i = 0; i < scoresString.Length;i++)
        {
            rollTexts[i].text = scoresString[i].ToString();
        }

    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++){
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string bowlsAsString = "";

        for (int i = 0, bowlCount = 0; i < rolls.Count; i++, bowlCount++)
        {
            if (bowlCount >= 18 && rolls[i] == 10)  //10th Frame Strike
            {
                bowlsAsString += "X";
            }else if (rolls[i] == 0)
            {
                bowlsAsString += "-";
            }
            else if (rolls[i] == 10) //Strike
            { 
                bowlsAsString += "X ";
                bowlCount++;
            }
            else if (bowlCount % 2 == 1 && (rolls[i] + rolls[i - 1]) == 10) //Spaire
            { 
                bowlsAsString += "/";
            }
            else // 1st and 2nd on non strike/spaire
            { 
                bowlsAsString += rolls[i].ToString();
            }
        }
        return bowlsAsString;
    }
}
