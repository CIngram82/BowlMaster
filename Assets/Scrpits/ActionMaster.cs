using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
    public enum Action { Tidy, Reset, EndTurn, Endgame}

    public int[] bowls = new int[21];
    public int[] frames = new int[10];
    private int ballThrow = 1;

    public Action Bowl(int pins)
    {
        if(pins < 0 || pins > 10) throw new UnityException("Invalid Number of pins");
        bowls[ballThrow - 1] = pins;
        if (pins == 10) // strike
        {
            frames[ballThrow / 2] = 10;
            ballThrow += 2;
            return Action.EndTurn;
        }

        if (ballThrow % 2 != 0) //first throw of the frame
        {
            ballThrow++;
            return Action.Tidy;
        } else if (ballThrow % 2 == 0) //2nd throw of the frame
        {
            frames[(ballThrow / 2)-1] = pins + bowls[ballThrow-2];
            ballThrow++;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return");
       
    }

}
