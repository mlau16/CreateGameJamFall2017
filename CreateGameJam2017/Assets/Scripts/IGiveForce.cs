using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGiveForce {

    void TakeForce(Vector3 direction, RaycastHit hit);
}
