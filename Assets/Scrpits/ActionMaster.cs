using UnityEngine;
using System.Collections.Generic;

public class ActionMaster {
    public enum Action { Tidy, Reset, EndTurn, Endgame}

    public int[] bowls = new int[21];
    public int ballThrow = 1;

    //TODO make Bowl privite
    public Action Bowl(int pins)
    {
        if(pins < 0 || pins > 10) throw new UnityException("Invalid Number of pins");
        bowls[ballThrow - 1] = pins;

        //Deal with last frame
        if(ballThrow == 21)
        {
            return Action.Endgame;
        }
        if (ballThrow == 20 && !Bowl21Awarded())
        {
            ballThrow++;
            return Action.Endgame;
        }
        else if (ballThrow == 20 && Bowl21Awarded() && bowls[19-1] == 10 && pins <10 )
        {
            ballThrow++;
            return Action.Tidy;
        }
        if (ballThrow >= 19 && Bowl21Awarded())
        {
            ballThrow++;
            return Action.Reset;
        }
        //Deal with frames 1 to 9
        if (ballThrow % 2 != 0 && pins == 10) // strike
        {
            ballThrow += 2;
            return Action.EndTurn;
        }
        if (ballThrow % 2 == 0 && pins == 10) // 0/10 spare
        {
            ballThrow++;
            return Action.EndTurn;
        }
        if (ballThrow % 2 != 0) //first throw of the frame
        {
            ballThrow++;
            return Action.Tidy;
        }
        if (ballThrow % 2 == 0) //2nd throw of the frame
        {
            ballThrow++;
            return Action.EndTurn;
        }
        throw new UnityException("Not sure what action to return");
    } 

    private bool Bowl21Awarded()
    {
        return (bowls[19-1] + bowls[20-1] >= 10);
    }

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster actionMaster = new ActionMaster();
        Action currentAction = new Action();
        foreach(int pinFall in pinFalls)
        {
            currentAction = actionMaster.Bowl(pinFall);
        }
        return currentAction;
    }
}
