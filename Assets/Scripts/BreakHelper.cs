using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakHelper : MonoBehaviour
{
    public void SpawnBreak()
    {
        //OmnicatLabs.Managers.AudioManager.Instance.Play("Break", transform.position);
        GameObject effect = Instantiate(Resources.Load("Prefabs/BreakSoundEffect") as GameObject, transform.position, Quaternion.identity);
            effect.GetComponent<AudioSource>().Play();
    }
}
