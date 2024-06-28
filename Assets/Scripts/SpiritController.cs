using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    public GameObject Spirit;
    public string CurrentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Spirit = this.gameObject;
        CurrentPlayer = "Flitter";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
