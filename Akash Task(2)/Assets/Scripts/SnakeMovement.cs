using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";

    public float snakespeed;

    
    

    void Update()
    {
        transform.Translate(0, 0, snakespeed * Time.deltaTime * 5f);

        inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        inputVertical = SimpleInput.GetAxis(verticalAxis);

        transform.Rotate(0, inputHorizontal * 5f, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("Collected");
        }
    }
}
