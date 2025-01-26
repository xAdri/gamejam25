using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform canonBulletSpawnPos;
    private float bulletSpeed = 25;

    private void Start()
    {
        Destroy(gameObject, 2);
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirectionCam = Vector3.zero;
        moveDirectionCam += Vector3.forward;
        gameObject.transform.Translate(moveDirectionCam * bulletSpeed * Time.deltaTime);
    }


}
