using UnityEngine;

public class Door : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Renderer.enabled = false;
    }
    void OpenTheDoor()
    {
        m_Renderer.enabled =true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
