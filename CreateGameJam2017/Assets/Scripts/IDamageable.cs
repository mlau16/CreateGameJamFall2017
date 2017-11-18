using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //Method that gets called when object gets hit
    //Overridden within player + enemy class
    void TakeHit(float damage, RaycastHit hit);

}