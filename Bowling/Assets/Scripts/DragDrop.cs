using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

	private float startTime = 0f, endTime = 0f;
	private Vector3 startDrag, endDrag;
	private Ball ball;
	private Animator pinAnimator;

	void Start(){
		ball = GetComponent<Ball>();
		pinAnimator = FindObjectOfType<PinSetter>().GetComponent<Animator>();
	}

	public void MoveStart (float amount)
	{
		float ballPosX = ball.transform.position.x;
		if (!ball.inPlay) {
			ballPosX += amount;
			ballPosX = Mathf.Clamp(ballPosX, -50, 50);
			ball.transform.position = new Vector3(ballPosX, ball.transform.position.y, ball.transform.position.z);
		}
	}

	public void DragStart(){
		startTime = Time.time;
		startDrag = Input.mousePosition;
	}

	public void DragEnd ()
	{
		endTime = Time.time;
		float duration = endTime - startTime;
		endDrag = Input.mousePosition;

		float speedX = (endDrag.x - startDrag.x) / duration / 12f;
		float speedZ = (endDrag.y - startDrag.y) / duration / 4f;

		speedZ = (speedZ > 1000f) ? 1000f : speedZ;
		//if (!ball.inPlay && pinAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
			ball.Launch(new Vector3(speedX, 0, speedZ));		
		//}
	}
}
