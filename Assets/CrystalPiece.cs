using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalPiece : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Other.gameobjent.name"+other.gameObject.name);
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerHealthController>().crystalCount++;
            this.gameObject.SetActive(false);
        }
    }
}
