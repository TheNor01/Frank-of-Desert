using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ikillable<T>   //interfaccia
{
    void Death();
    void TakeDamage(T value);
}
