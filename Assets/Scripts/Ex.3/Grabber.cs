using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grabber : MonoBehaviour {
    public float grabRange;
    Handle handle;

    void FixedUpdate() {
        var colliders = Physics.OverlapSphere(transform.position, grabRange);
        if (handle == null) {
            // try to find a new handle to grab
            foreach (var c in colliders) {
                var hnd = c.GetComponent<Handle>();
                if (hnd) {
                    handle = hnd;
                    // tell the handle to track this object
                    handle.Track(transform);
                    break;
                }
            }
        } else {
            // we currently have a grab active - check if the current handle
            // is still in range
            if (!System.Array.Exists(colliders, c => c.GetComponent<Handle>() == handle)) {
                // it's not - stop grabbing
                handle.Track(null);
                handle = null;
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = handle ? Color.yellow : Color.grey;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
