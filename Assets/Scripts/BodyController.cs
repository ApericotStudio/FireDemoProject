using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public GameObject Body;
    public string CurrentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Body = this.gameObject;
        CurrentPlayer = "Battric";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
