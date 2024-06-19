using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerControls pc = other.GetComponent<PlayerControls>();
            pc.moveSpeed = speed * 2;
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

}
