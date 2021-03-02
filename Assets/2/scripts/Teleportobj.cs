using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportobj : MonoBehaviour
{
    public static bool Allclear;
  
    private void OnEnable()
    {
        Allclear = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("col");
        Allclear = false;
        gameObject.SetActive(false);
    }

}
