using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Wizard {

    public static string Name = "Wizard";
    public static int CurrentLevel = 1;
    public static int MaxHp = 10;
    public static int CurrentHp = 10;
    public static int Attack = 1;
    public static int Defense = 1;
    public static int Speed = 1;
    public static List<Spell> Spellbook;
    public static List<Item> Inventory;
    public static int CurrentExp = 0;
    public static int ExpThreshold = 100;
    public static Enemy Enemy;

    public static string DisplayHealth()
    {
        float hp = (float)CurrentHp / (float)MaxHp;
        var disp = "";
        if (hp == 1) { disp = "You're perfectly healthy."; }
        else if (hp > 1) { disp = "You're bursting with energy!"; }
        else if (hp > .9) { disp = "You're doing fine."; }
        else if (hp > .75) { disp = "You are getting beat up a bit."; }
        else if (hp > .5) { disp = "You are injured."; }
        else if (hp > .3) { disp = "You have serious injuries."; }
        else if (hp > 0) { disp = "You are critically wounded!"; }
        else if (hp <= 0) { disp = "You're done for."; }
        return disp;
    }

    public static string LevelComparison()
    {
        var disp = "";
        if (CurrentLevel == Enemy.Level) { disp = "This " + Enemy.Name + " is evenly matched with you."; }
        else if (CurrentLevel > Enemy.Level) { disp = "The enemy looks weaker than you."; }
        else if (CurrentLevel < Enemy.Level) { disp = "It looks really tough!"; }
        return disp;
    }

    public static void GainExp(int amount)
    {
        CurrentExp += amount;
        if (CurrentExp >= ExpThreshold)
        {
            LevelUp();
        }
    }

    public static void LevelUp()
    {
        CurrentLevel += 1;
        if (CurrentExp < ExpThreshold)
        {
            CurrentExp = ExpThreshold;
        }
        ExpThreshold += CurrentLevel * 100;
        MaxHp += 2;
        CurrentHp = MaxHp;
        Attack += 1;
        Defense += 1;
        Speed += 1;
        //Learn spells
    }
}
