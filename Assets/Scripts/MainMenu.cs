using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject AnyKey;
    SpriteRenderer AnyKeyRenderer;
    float lastAlpha;

    void Start()
    {
        AnyKeyRenderer = AnyKey.GetComponent<SpriteRenderer>();
        lastAlpha = AnyKeyRenderer.color.a;
    }
    void Update () {
        var newAlpha = 0f;
        if (lastAlpha == 1 || lastAlpha > AnyKeyRenderer.color.a)
        {
            newAlpha = AnyKeyRenderer.color.a - .025f;
        }
        else if (lastAlpha <= 0 || lastAlpha < AnyKeyRenderer.color.a)
        {
            newAlpha = AnyKeyRenderer.color.a + .025f;
        }
        lastAlpha = AnyKeyRenderer.color.a;
        newAlpha = Mathf.Clamp01(newAlpha);
        AnyKeyRenderer.color = new Color(AnyKeyRenderer.color.r, AnyKeyRenderer.color.g, AnyKeyRenderer.color.b, newAlpha);

        if (Input.anyKey)
        {
            SceneManager.LoadScene("Overworld");
        }
    }
}
