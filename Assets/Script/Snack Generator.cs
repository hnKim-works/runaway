using System;
using UnityEngine;

public class SnackGenerator : MonoBehaviour
{
    public float interval;
    public GameObject greenPeperoPrefab;
    public GameObject yellowPeperoPrefab;

    private Boolean nextIsYellow;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextIsYellow = true;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float offsx = UnityEngine.Random.Range(-14.0f, 14.0f);
            float offsz = UnityEngine.Random.Range(-9.0f, 0.0f);
            Vector3 position = transform.position + new Vector3 (offsx,12.0f, offsz);

            GameObject  prefab = nextIsYellow? greenPeperoPrefab: yellowPeperoPrefab;
            Instantiate(prefab, position, UnityEngine.Random.rotation);

            timer =interval;
            nextIsYellow= !nextIsYellow;
        }
    }
}
