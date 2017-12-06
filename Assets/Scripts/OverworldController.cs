using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour {

    public GameObject Player;
    PlayerMovement playerControls;
    public float EncounterChance;
    public SpriteRenderer Overlay;

    bool encounter = false;

    void Start()
    {
        playerControls = Player.GetComponent<PlayerMovement>();
    }

    void Update ()
    {
        playerControls.PlayerHasControl = !encounter;
        if (encounter)
        {
            FadeIntoBattle();
        }
	}

    public void TriggerEncounter(GameObject target)
    {
        encounter = true;
        var spr = target.GetComponent<SpriteRenderer>();
        spr.color = new Color(0,0,0);
        Wizard.Enemy = target.GetComponent<MapEnemy>().Enemy;
    }

    void FadeIntoBattle()
    {
        if (Overlay.color.a < 1)
        {
            var newAlpha = Overlay.color.a + .01f;
            Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, newAlpha);
        }
        else
        {
            SceneManager.LoadScene("Battle");
        }
    }
}
