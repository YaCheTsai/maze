using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text wintext;
	private Rigidbody rb;
	private int count;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		wintext.text="";
	}
	
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement*speed);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PickUp")){ 
			other.gameObject.SetActive(false); 
			count=count+1;
			SetCountText();
		}
	}
	void SetCountText(){
		if(count!=0) wintext.text = "YOU WIN!!";
	}
	
}
