using UnityEngine;

public class Player : MonoBehaviour {
    private static Player _instance;
    public static Player Instance { get { return _instance; } }

    
    public Vector2 facingdirection = Vector2.zero;
    public bool interactingGameobj = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}