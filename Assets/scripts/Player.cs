using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour {

    Rigidbody2D rigidbodyPlayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float currentSpeed;

    public bool IsRunning { get; set; }
    public Vector2 Movement {get; set;}
    public bool IsRolling { get; set; }

    

    void Start() {
        currentSpeed = speed;
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        }

    void Update() {
        onInput();
        onRun();
        onRoll();

    }

    void FixedUpdate() {
        onMove();
    }

    #region Movement
    
    void onMove(){
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + Movement * currentSpeed * Time.fixedDeltaTime);
    }

    void onRun(){

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            currentSpeed = 7f;
            IsRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            currentSpeed = speed;
            IsRunning = false;
        }
    }

    void onRoll(){
        if (Input.GetMouseButtonDown(1)){
            Debug.Log("Rolling Down");
            currentSpeed = 7f;
            IsRolling = true;
        }
        if (Input.GetMouseButtonUp(1)){
            Debug.Log("Rolling Up");
            currentSpeed = speed;
            IsRolling = false;
            
        }
    }	

    void onInput(){
        Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    #endregion
    
}

