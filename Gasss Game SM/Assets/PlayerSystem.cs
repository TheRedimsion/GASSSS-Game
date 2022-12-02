using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField] Vector2 PlayerCheckPoint;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checkpoint
        if (collision.CompareTag("CheckPoint"))
        {
            PlayerCheckPoint = new Vector2(collision.transform.position.x, collision.transform.position.y);
        }

        // Finish
        if(collision.CompareTag("Finish"))
        {
            // TODO : code to lanjut stage berikutnya
            Debug.Log("Stage Finished!");
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Arena"))
        {
            Debug.Log("Anda keluar arena");
            gameObject.transform.position = PlayerCheckPoint;
        }
    }


}
