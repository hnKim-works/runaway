using UnityEngine;

public class Pepero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Pepero.cs
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            other.transform.root.gameObject.BroadcastMessage("CatchPepero", 1);
            Destroy(gameObject);
        }
    }

}
