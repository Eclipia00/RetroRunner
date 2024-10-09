using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] public Transform player;

    public float parallaxSpeed0 = 2f;
    public float parallaxSpeed1 = 2f;
    public float parallaxSpeed2 = 2f;
    public float parallaxSpeed3 = 2f;
    public float parallaxSpeed4 = 2f;
    public float parallaxSpeed5 = 2f;
    public float parallaxSpeed6 = 2f;

    [SerializeField] private Transform layer0;
    [SerializeField] private Transform layer1;
    [SerializeField] private Transform layer2;
    [SerializeField] private Transform layer3;
    [SerializeField] private Transform layer4;
    [SerializeField] private Transform layer5;
    [SerializeField] private Transform layer6;

    private Vector3 previousPlayerPosition;

    private void Start()
    {
        previousPlayerPosition = player.position;
    }

    private void FixedUpdate()
    {
        float deltaMovement = player.position.x - previousPlayerPosition.x;

        Vector3 backgroundPosition0 = layer0.transform.position;
        Vector3 backgroundPosition1 = layer1.transform.position;
        Vector3 backgroundPosition2 = layer2.transform.position;
        Vector3 backgroundPosition3 = layer3.transform.position;
        Vector3 backgroundPosition4 = layer4.transform.position;
        Vector3 backgroundPosition5 = layer5.transform.position;
        Vector3 backgroundPosition6 = layer6.transform.position;

        backgroundPosition0.x += deltaMovement * parallaxSpeed0 * Time.deltaTime;
        backgroundPosition1.x += deltaMovement * parallaxSpeed1 * Time.deltaTime;
        backgroundPosition2.x += deltaMovement * parallaxSpeed2 * Time.deltaTime;
        backgroundPosition3.x += deltaMovement * parallaxSpeed3 * Time.deltaTime;
        backgroundPosition4.x += deltaMovement * parallaxSpeed4 * Time.deltaTime;
        backgroundPosition5.x += deltaMovement * parallaxSpeed5 * Time.deltaTime;
        backgroundPosition6.x += deltaMovement * parallaxSpeed6 * Time.deltaTime;



        layer0.transform.position = backgroundPosition0;
        layer1.transform.position = backgroundPosition1;
        layer2.transform.position = backgroundPosition2;
        layer3.transform.position = backgroundPosition3;
        layer4.transform.position = backgroundPosition4;
        layer5.transform.position = backgroundPosition5;
        layer6.transform.position = backgroundPosition6;


        previousPlayerPosition = player.position;
    }
}
