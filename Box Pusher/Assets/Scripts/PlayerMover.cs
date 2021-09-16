using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    [SerializeField] float playerSpeed = 5f;

    public Rigidbody rb;

    void FixedUpdate() {
        MovePlayer();
        rotatePlayer();
    }

    void MovePlayer() {
        float horizontalTranslation = Input.GetAxis("Horizontal") * playerSpeed;
        float verticalTranslation = Input.GetAxis("Vertical") * playerSpeed;

        rb.AddRelativeForce(Vector3.forward * verticalTranslation);
        rb.AddRelativeForce(Vector3.right * horizontalTranslation);
    }

    void rotatePlayer() {
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.up * -100f * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "perimeter") {
            transform.position = new Vector3(transform.position.x, transform.position.y + (other.transform.position.y * 2), transform.position.z);
        }
    }
}
