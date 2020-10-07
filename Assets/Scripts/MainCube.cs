using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCube : MonoBehaviour
{
    public GameObject gameOver;
    public MainObject mainObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw")
        {
            Destroy(this.gameObject);
            gameOver.SetActive(true);
            mainObject.pause = true;
        }
    }
}
