
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCar : MonoBehaviour
{
    [Header("Movement")]


    [SerializeField] private int moveSpeed = 10;
    [SerializeField] private int turnSpeed = 50;

    [Header("Bounds")]

    [SerializeField] private Vector2 bound = new Vector2(33 , 16);


    void Start(){
    transform.position = new Vector2(21,-8);}
    


    void Update()
    {
        var keys = Keyboard.current;

        if (keys == null) return;

        float drive = 0f;
        float turn = 0f;

        // Forward and backward

        if (keys.wKey.isPressed || keys.upArrowKey.isPressed)
        {
            drive = 1f;
        }

        if (keys.sKey.isPressed || keys.downArrowKey.isPressed)
        {
            drive = -1f;
        }

        //turn to left
        if (keys.aKey.isPressed || keys.leftArrowKey.isPressed)
        {
            turn = 1f;
        }
        
        //turn to right
        if (keys.dKey.isPressed || keys.rightArrowKey.isPressed)
        {
            turn = -1f;
        }

      
        // Move the car
        transform.Translate(Vector3.up * drive * moveSpeed * Time.deltaTime);

        // Rotate the car
         transform.Rotate(0f, 0f, turn * turnSpeed * Time.deltaTime);

         //if two keys press together
         Vector3 direction = new Vector3(0f, drive, 0f).normalized;

        
   
    //bounds

    Vector2 position = transform.position;

        position.x = Mathf.Clamp(position.x, -bound.x , bound.x);
        position.y = Mathf.Clamp(position.y, -bound.y , bound.y);


        transform.position = position;
      }   
}

