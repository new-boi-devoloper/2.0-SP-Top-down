using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float PlayerSpeed { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }
    
    public Rigidbody2D Rb { get; private set; }

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
}