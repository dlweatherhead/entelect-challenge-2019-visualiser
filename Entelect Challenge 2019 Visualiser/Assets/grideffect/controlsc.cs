using UnityEngine;
using System.Collections;

public class controlsc : MonoBehaviour {


	GridEffect cusimg;


	public int xstep2;
	public int ystep2;

	public bool maekey;

	public float amount2;


	// Use this for initialization
	void Start () {

//		cusimg = GameObject.Find ("Main Camera").GetComponent<GridEffect> ();
		cusimg = GetComponent<GridEffect> ();


//		if(xint2==0) xint2 = 5;
//		if(yint2==0) yint2 = 5;

		xstep2 = cusimg.Xstep;
		ystep2 = cusimg.Ystep;
		amount2 = cusimg.Amount;

	
	}




	// Update is called once per frame
	void Update () {



		if(Input.GetAxisRaw("Horizontal")>0 && maekey==false)
		{
			if (xstep2 < 10)
				xstep2 += 1;

		}

		if(Input.GetAxisRaw("Horizontal")<0 && maekey==false)
		{
			if (xstep2 > 1)
				xstep2 -= 1;

		}

		if(Input.GetAxisRaw("Vertical")>0 && maekey==false)
		{
			if (ystep2 < 10)
				ystep2 += 1;

		}

		if(Input.GetAxisRaw("Vertical")<0 && maekey==false)
		{
			if (ystep2 > 1)
				ystep2 -= 1;

		}

/*
		if (Input.GetKey("escape"))
			

			{
				Application.Quit();
		}

*/




		if (Input.GetKeyDown(KeyCode.I)) {

			amount2 += 0.05f;

			if (amount2 > 1)amount2 = 1;

		}





		if (Input.GetKeyDown (KeyCode.K)) {

			amount2 -= 0.05f;

			if (amount2 < 0)
				amount2 = 0;

		}




		cusimg.Xstep = xstep2;
		cusimg.Ystep = ystep2;
		cusimg.Amount = amount2;


		if(Input.GetAxisRaw("Horizontal")==0 && Input.GetAxisRaw("Vertical")==0)
		{
			maekey=false;

		}
		else maekey=true;

	}
}
