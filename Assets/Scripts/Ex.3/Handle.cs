using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    public void Track(Transform t) {
        // Note the assumption here that the Lever is in the direct parent.
        // Could instead use a reference set in editor, search all parents, etc.
        transform.parent.GetComponent<Lever>().Track(t);
    }
}
