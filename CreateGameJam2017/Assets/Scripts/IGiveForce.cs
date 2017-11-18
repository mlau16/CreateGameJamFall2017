using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGiveForce {

    void TakeForce(Ray ray, RaycastHit hit);
}
