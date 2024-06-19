using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerControls pc = other.GetComponent<PlayerControls>();
            pc.score++;
        }
    }
    void Update()
    {
 
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
