﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {
    public enum Action { Tidy, Reset, EndTurn, Endgame}

    public Action Bowl(int pins)
    {
        if(pins < 0 || pins > 10) throw new UnityException("Invalid Number of pins");
        
        if (pins == 10)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return");
       
    }

}