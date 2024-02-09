using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Color groundColor = GetObjectColor(other.gameObject);
            SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
            playerRenderer.color = groundColor;
        }
    }

    private Color GetObjectColor(GameObject gameObject)
    {
        SpriteRenderer objectRenderer = gameObject.GetComponent<SpriteRenderer>();
        return objectRenderer.color;
    }
}
