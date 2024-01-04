using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidMovement : MonoBehaviour
{
    public float donmeHizi = 100.0f; // Dönme hızı (derece/saat cinsinden)

    void Update()
    {
        // Resmi kendi etrafında döndürme
        transform.Rotate(Vector3.forward, donmeHizi * Time.deltaTime);
    }
}
