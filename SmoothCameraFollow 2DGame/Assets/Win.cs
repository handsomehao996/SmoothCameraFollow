using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject winEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            winEffect.SetActive(true);
        }
    }
}
