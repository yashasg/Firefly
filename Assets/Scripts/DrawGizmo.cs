using UnityEngine;
using System.Collections;

public class DrawGizmo : MonoBehaviour {

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
