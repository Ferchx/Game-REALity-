using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    //variables
    [SerializeField]bool houseMode = true;
    Rigidbody2D MCcontroller;
    Vector2 movement;
    Vector3 scaleX;
    float movementX  = 0, movementY = 0;
    [SerializeField] float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        MCcontroller =  this.GetComponent<Rigidbody2D>();
        scaleX = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        Vector2 moveInput;
        if (houseMode)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"),0f);
            if (Input.GetAxis("Horizontal")> 0)
            {
                scaleX.x = 1;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                scaleX.x = -1;
            }
        }
        else
        {
             moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        movement = moveInput * speed;
        if(movement != Vector2.zero)
        {
            MCcontroller.MovePosition(MCcontroller.position + movement * Time.fixedDeltaTime);
            transform.localScale = scaleX;
        }
    
    }
}
