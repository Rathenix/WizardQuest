using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public GameObject Text;
    Text text;
    public BattleMenu BattleControls;
    public GameObject TextArrow;
    List<Action> Output = new List<Action>();
    string prompt = "What will you do?";

    void Start()
    {
        text = Text.GetComponent<Text>();
        Output.Add(() => text.text = "Lizard appeared!");
        prompt = Wizard.DisplayHealth() + " " + Wizard.LevelComparison();
    }

    void Update()
    {
        BattleControls.PlayerHasControl = Output.Count == 0;
        ShowOutput();
    }

    public void UseWand()
    {
        Output.Add(() => text.text = "Used wand.");
        Output.Add(() => text.text = "Zapped the lizard for 1 damage.");
        Wizard.Enemy.CurrentHp -= 1;
        Output.Add(() => text.text = "He doesn't seem happy about it.");
        CheckBattle();
    }

    public void UseSpell()
    {
        Output.Add(() => text.text = "Used spell.");
        Output.Add(() => text.text = "Fire falls from the sky and blasts");
        Output.Add(() => text.text = "the lizard for 6 damage.");
        Wizard.Enemy.CurrentHp -= 6;
        CheckBattle();
    }

    public void UseItem()
    {
        Output.Add(() => text.text = "Used item.");
        Output.Add(() => text.text = "A potion envigorates your spirit.");
        Wizard.CurrentHp += 1;
        CheckBattle();
    }

    public void Flee()
    {
        Output.Add(() => text.text = "Fled...");
        Output.Add(() => SceneManager.LoadScene("Overworld"));
    }

    void ShowOutput()
    {
        if (Output.Count > 0)
        {
            TextArrow.SetActive(true);
            Output[0]();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Output.RemoveAt(0);
            }
        }
        else
        {
            TextArrow.SetActive(false);
            text.text = prompt;
        }
    }

    void CheckBattle()
    {
        if (Wizard.CurrentHp <= 0)
        {
            // Game Over
            Output.Add(() => text.text = "And so ends your journey...");
            Output.Add(() => SceneManager.LoadScene("Title"));
        }
        else if (Wizard.Enemy.CurrentHp <= 0)
        {
            Output.Add(() => text.text = "You've slain the " + Wizard.Enemy.Name + "!");
            Output.Add(() => text.text = Wizard.Enemy.DisplayExpYield());
            var lvl = Wizard.CurrentLevel;
            Wizard.GainExp(Wizard.Enemy.ExpYield);
            if (lvl < Wizard.CurrentLevel)
            {
                Output.Add(() => text.text = "You've gained enough battle expereince to grow even stronger!");
            }
            Output.Add(() => SceneManager.LoadScene("Overworld"));
        }
        else
        {
            prompt = Wizard.DisplayHealth() + " " + Wizard.Enemy.DisplayHealth();
        }
    }
}
