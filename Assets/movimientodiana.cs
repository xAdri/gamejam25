using UnityEngine;

public class movimientodiana : MonoBehaviour
{
    public float horizontalMove;
    public float verticallMove;
    public CharacterController diana;

    public float dianaSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diana = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        diana.Move(new Vector3(horizontalMove, 0, verticallMove) * Time.deltaTime);
    }
}
