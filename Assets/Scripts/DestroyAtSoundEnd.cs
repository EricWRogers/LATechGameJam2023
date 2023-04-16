using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtSoundEnd : MonoBehaviour
{
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
