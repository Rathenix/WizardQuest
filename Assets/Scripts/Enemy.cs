using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {

    public string Name = "Lizard";
    public int Level = 1;
    public int MaxHp = 10;
    public int CurrentHp = 10;
    public int Attack = 1;
    public int Defense = 1;
    public int Speed = 1;
    public int ExpYield = 100;

    public string DisplayHealth()
    {
        float hp = (float)CurrentHp / (float)MaxHp;
        var disp = "";
        if (hp == 1) { disp = "The " + Name + " is at full strength."; }
        else if (hp > 1) { disp = "The " + Name + " is extra healthy."; }
        else if (hp > .9) { disp = "The " + Name + " is healthy."; }
        else if (hp > .75) { disp = "The " + Name + " is looking damaged."; }
        else if (hp > .5) { disp = "The " + Name + " is injured."; }
        else if (hp > .3) { disp = "The " + Name + " has serious injuries."; }
        else if (hp > 0) { disp = "The " + Name + " is critically wounded!"; }
        else if (hp <= 0) { disp = "The " + Name + " is done for."; }
        return disp;
    }

    public string DisplayExpYield()
    {
        //Make this a variable message based on yield percent of tnl
        return "You got " + ExpYield + " EXP.";
    }
}