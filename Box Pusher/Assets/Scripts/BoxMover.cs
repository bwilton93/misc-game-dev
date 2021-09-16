using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour {
    [SerializeField] float moveSpeed;
    public Vector3 targetPosition;
    public bool boxPushed = false;

    void Update() {
        if (boxPushed) {
            MoveBox();
        }
    }

    void MoveBox() {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f) {
            transform.position = targetPosition;
            boxPushed = false;
        }
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log(other.transform.position);
        Debug.Log(transform.position);

        targetPosition = other.transform.position - transform.position;
        targetPosition = transform.position + (targetPosition * -1);
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        Debug.Log(targetPosition);

        boxPushed = true;
    }

    void OnCollisionExit(Collision other) {
        boxPushed = false;
    }
}
