using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 90f;
    [SerializeField] float moveSpeed = 20f;

    [SerializeField] float highSpeed = 30;
    [SerializeField] float slowSpeed = 10;
    float currentSpeed = 20f;
    void Start()
    {
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        if (speedAmount > 0)
        {
            steerAmount *= -1;
        }
        else if (speedAmount == 0)
        {
            steerAmount = 0;
        }

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Booster")
        {
            currentSpeed = highSpeed;
            // Destroy(other.gameObject, 0.1f);
        }
        else if (other.tag == "Bumper")
        {
            currentSpeed = slowSpeed;
            // Destroy(other.gameObject, 0.1f);
        }
    }
}
