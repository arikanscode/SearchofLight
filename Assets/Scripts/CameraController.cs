using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator camAnimator;
    // Start is called before the first frame update
    void Start()
    {
        introCamAnim();
        camAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator introCamAnim()
    {
        yield return new WaitForSeconds(5);
    }
}
