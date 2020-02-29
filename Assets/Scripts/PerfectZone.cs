using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectZone : MonoBehaviour
{
    private float growSpeed = 3f;
    private bool activate;
    private float progress;

    private void Update()
    {
        if (activate)
        {
            progress += Time.deltaTime * growSpeed;
            if (progress <= 1)
            {
                transform.localScale = Vector3.Lerp(new Vector3(0.75f, 0.7f, 0.75f), new Vector3(3, 0.7f, 3), progress);                
            }
            else
            {
                activate = false;
                DeactivateSelf();
            }            
        }
    }
    public void ActivateSelf()
    {
        if (!activate)
        {
            progress = 0;
            activate = true;
        }
    }

    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
        transform.localScale = new Vector3(0.75f, 0.7f, 0.75f);
    }
}
