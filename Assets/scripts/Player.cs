using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rigidbodyPlayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedRun = 8f;
    private Vector2 _movement;

    public Vector2 movement {
        get => _movement;
        set => _movement = value;
    }

    void Start() {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    
    void Update() {
        onInput();
        if (Input.GetKey(KeyCode.LeftShift)){
            onRun();
        }
    }


    void FixedUpdate() {
        onMove();
    }

    #region Movement
    
    void onMove(){
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + _movement * speed * Time.fixedDeltaTime);
    }

    void onRun(){
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + _movement * speedRun * Time.fixedDeltaTime);
    }

    void onInput(){
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    #endregion
    
}
