using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu : MonoBehaviour {

    public GameObject Pointer;
    public Vector3 WandPosition;
    public Vector3 SpellPosition;
    public Vector3 ItemPosition;
    public Vector3 FleePosition;
    public GameObject Wand;
    Animator WandAnimator;
    public GameObject Spell;
    Animator SpellAnimator;
    public GameObject Item;
    Animator ItemAnimator;
    public GameObject Flee;
    Animator FleeAnimator;
    string curPos;
    public BattleController BattleController;
    public bool PlayerHasControl = false;

    void Start () {
        WandAnimator = Wand.GetComponent<Animator>();
        SpellAnimator = Spell.GetComponent<Animator>();
        ItemAnimator = Item.GetComponent<Animator>();
        FleeAnimator = Flee.GetComponent<Animator>();
        Pointer.transform.localPosition = WandPosition;
        curPos = "wand";
        WandAnimator.Play("Glowing");
    }
	
	void Update () {
        if (PlayerHasControl)
        {
            Pointer.SetActive(true);
            switch (curPos)
            {
                case "wand":
                    WandAnimator.Play("Glowing");
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        WandAnimator.Play("Stopped");
                        Pointer.transform.localPosition = ItemPosition;
                        curPos = "item";
                        ItemAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        WandAnimator.Play("Stopped");
                        Pointer.transform.localPosition = SpellPosition;
                        curPos = "spell";
                        SpellAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        BattleController.UseWand();
                    }
                    break;
                case "spell":
                    SpellAnimator.Play("Glowing");
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        SpellAnimator.Play("Stopped");
                        Pointer.transform.localPosition = WandPosition;
                        curPos = "wand";
                        WandAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        SpellAnimator.Play("Stopped");
                        Pointer.transform.localPosition = FleePosition;
                        curPos = "flee";
                        FleeAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        BattleController.UseSpell();
                    }
                    break;
                case "item":
                    ItemAnimator.Play("Glowing");
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        ItemAnimator.Play("Stopped");
                        Pointer.transform.localPosition = WandPosition;
                        curPos = "wand";
                        WandAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        ItemAnimator.Play("Stopped");
                        Pointer.transform.localPosition = FleePosition;
                        curPos = "flee";
                        FleeAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        BattleController.UseItem();
                    }
                    break;
                case "flee":
                    FleeAnimator.Play("Glowing");
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        FleeAnimator.Play("Stopped");
                        Pointer.transform.localPosition = SpellPosition;
                        curPos = "spell";
                        SpellAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        FleeAnimator.Play("Stopped");
                        Pointer.transform.localPosition = ItemPosition;
                        curPos = "item";
                        ItemAnimator.Play("Glowing");
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        BattleController.Flee();
                    }
                    break;
            }
        }
        else
        {
            Pointer.SetActive(false);
            WandAnimator.Play("Stopped");
            SpellAnimator.Play("Stopped");
            ItemAnimator.Play("Stopped");
            FleeAnimator.Play("Stopped");
        }
	}
}
