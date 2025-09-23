using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    bool tieneLlave = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            tieneLlave = true;
            Debug.Log("Tiene llave");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Finish") && tieneLlave == true)
        {
            SceneManager.LoadScene("Victory");
        }
        else if (other.gameObject.CompareTag("Finish") && tieneLlave == false)
        {
            Debug.Log("No tiene llave");
        }
    }
}
