using System;
using UnityEngine;

public class Controllers : MonoBehaviour
{
    public float aimSpeed;
    public Vector3 moveDirection = Vector3.zero;

    [Header("Cam")]
    public GameObject cam;
    public GameObject camTargetToAim;
    public GameObject camVisual;

    [Header("Canon")]
    public GameObject canon;
    public GameObject canonTargetToAim;

    // Update is called once per frame
    void Update()
    {
        AimCanonSystem();
        AimCamSystem();
    }

    private void AimCamSystem()
    {
        camVisual.transform.LookAt(camTargetToAim.transform);
        Vector3 moveDirectionCam = Vector3.zero;

        // Canon
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirectionCam += Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirectionCam -= Vector3.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirectionCam += Vector3.down;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirectionCam -= Vector3.right;
        }

        camTargetToAim.transform.Translate(moveDirectionCam * aimSpeed * Time.deltaTime);
    }

    private void AimCanonSystem()
    {
        Vector3 moveDirectionCanon = Vector3.zero;

        // Cam
        if (Input.GetKey(KeyCode.W))
        {
            moveDirectionCanon += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirectionCanon -= Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirectionCanon += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirectionCanon -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            print("canon dispara");
        }

        canonTargetToAim.transform.Translate(moveDirectionCanon * aimSpeed * Time.deltaTime);
    }
}
