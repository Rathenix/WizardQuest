using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int PlayerMoveSpeed;
    public bool PlayerHasControl = false;
    SpriteRenderer Renderer;
    public int CameraHalfHeight;
    public int CameraHalfWidth;
    public OverworldController OverworldController;
    Camera MainCamera;

    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        MainCamera = Camera.main;
    }

    void Update () {
        if (PlayerHasControl)
        {
            UseKeysToMove();
            MoveCamera();
        }
    }

    void UseKeysToMove()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, PlayerMoveSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -PlayerMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Renderer.flipX = true;
            transform.position += new Vector3(PlayerMoveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Renderer.flipX = false;
            transform.position += new Vector3(-PlayerMoveSpeed, 0);
        }
    }

    void MoveCamera()
    {
        if (transform.position.x > MainCamera.transform.position.x + CameraHalfWidth)
        {
            var newpos = MainCamera.transform.position.x + CameraHalfWidth * 2;
            MainCamera.transform.position = new Vector3(newpos, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        if (transform.position.x < MainCamera.transform.position.x - CameraHalfWidth)
        {
            var newpos = MainCamera.transform.position.x - CameraHalfWidth * 2;
            MainCamera.transform.position = new Vector3(newpos, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        if (transform.position.y > MainCamera.transform.position.y + CameraHalfHeight)
        {
            var newpos = MainCamera.transform.position.y + CameraHalfHeight * 2;
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, newpos, MainCamera.transform.position.z);
        }
        if (transform.position.y < MainCamera.transform.position.y - CameraHalfHeight)
        {
            var newpos = MainCamera.transform.position.y - CameraHalfHeight * 2;
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, newpos, MainCamera.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lizard"))
        {
            OverworldController.TriggerEncounter(collision.gameObject);
        }
    }
}
