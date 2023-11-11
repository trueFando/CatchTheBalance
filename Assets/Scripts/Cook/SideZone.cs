using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideZone : MonoBehaviour
{
    [SerializeField] private CookEmotions _emotionsDispatcher;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Food>() != null)
        {
            _emotionsDispatcher.IsAfraid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Food>() != null)
        {
            _emotionsDispatcher.IsAfraid = false;
        }
    }
}
