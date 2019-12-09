using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //To destroy explosion animations after a set time
        Destroy(gameObject, lifeTime);
    }

}
