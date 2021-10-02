using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal.Internal;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Vector3 mapMiddlePoint;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float scaleSpeed;
    public SpriteChangeScript spriteChange;
    public UnityEngine.Experimental.Rendering.Universal.Light2D ourLight;
    public GameObject gameOverPanel;
    public GameObject gameOverText;

    private CameraFollow cameraFollow;

    void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
    }

    void Update()
    {
        if (spriteChange.lightsIsReady == true)
        {
            cameraFollow.enabled = false;
            transform.position = Vector3.Lerp(transform.position, mapMiddlePoint, moveSpeed * Time.deltaTime);
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, 13, scaleSpeed * Time.deltaTime);

            ourLight.intensity = 1f;
            gameOverPanel.SetActive(true);
            gameOverText.SetActive(true);
            
        }
    }
}
