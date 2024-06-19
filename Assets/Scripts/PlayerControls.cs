using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public Rigidbody rb;
    public float jumpforce;
    public int score;
    public PlayerControls pc;

    public float speedTime;
    public float maxSpeedTime;
    public float originalSpeed;
    private bool isSpeedBoostActive;

    public TextMeshProUGUI showSpeed;
    public TextMeshProUGUI showScore;
    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpforce, 0));
        }
        if (isSpeedBoostActive)
        {
            speedTime += Time.deltaTime;
            if (speedTime >= maxSpeedTime)
            {
                // Reset speed to original speed
                moveSpeed = originalSpeed;
                isSpeedBoostActive = false; // Reset the flag
            }
        }
        showSpeed.text = "Speed: " + moveSpeed.ToString();
        showScore.text = "Score: " + score.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nitro"))
        {
            isSpeedBoostActive = true;
            speedTime = 0f;
        }
    }
}
