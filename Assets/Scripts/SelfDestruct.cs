using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destructTime = 3.0f;

    // Start is called before the first frame update
    public void Initiate()
    {
        Invoke("selfDestruct", destructTime);
    }
    private void selfDestruct()
    {
        Destroy(gameObject);
    }
}
