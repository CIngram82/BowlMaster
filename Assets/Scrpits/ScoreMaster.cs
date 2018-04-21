using System.Linq;
using System.Collections.Generic;

public static class ScoreMaster {

    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> CumulativeScores = new List<int>();
        int runningTotal = 0;
        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            CumulativeScores.Add(runningTotal);
        }
        return CumulativeScores;
    }

    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();
        int frameTotal = 0;
        for (int i = 0,bowlCount = 0 ; i < rolls.Count - 1; i+=2, bowlCount+=2 )
        {
            if (bowlCount >= 18 && rolls[i] == 10){
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
                return frameList;
            }else if (rolls[i] == 10){
                if(rolls.Count > i + 2){
                    frameList.Add(10 + rolls[i + 1] +rolls[i+2]);
                    i--;
                }
            }else if ((rolls[i]+rolls[i+1])==10){
                if (rolls.Count > i + 2){
                    frameList.Add(10 + rolls[i + 2]);
                }
            }else{
                frameTotal = rolls[i] + rolls[i + 1];
                frameList.Add(frameTotal);
            }
        }  
        return frameList;
    }
}
