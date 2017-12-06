using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemy : MonoBehaviour {

    public Enemy Enemy;

    void Start()
    {
        Enemy = new Enemy();    
    }
}
