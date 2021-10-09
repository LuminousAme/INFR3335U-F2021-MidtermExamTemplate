using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{

    [SerializeField] private float rate = 360f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, rate * Time.deltaTime, 0f), Space.World);
    }
}
