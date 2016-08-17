using UnityEngine;
using System.Collections;

public class FieldManager : MonoBehaviour {

	enum State{
		FirstDown, SecondDown, ThirdDown, FourthDown, TouchDown
	}

	enum Side{
		Left, Right
	}

	State myState;
	
	Side _side;
	private int endZoneHome = -50;
	private int endZoneAway = 50;
	private int center = 50;

	PossessionManager possessionMgr = new PossessionManager();

	public int programYardLine;
	public int realYardLine;

	void Start(){

		possessionMgr.SetPossession (Possession.Away);

		_side = Side.Right;

		SetYardLine  (40, _side);

		//Test Cases for moving the ball.
		if (myState != State.TouchDown) {
			YardsGained (Random.Range(0, 15));

			print ("Current Yardline " + this.realYardLine);
			print ("Side " + _side);
		}
		if (myState != State.TouchDown) {
			YardsGained (Random.Range(0, 15));
			print ("Current Yardline " + this.realYardLine);
			print ("Side " + _side);
		}
		if (myState != State.TouchDown) {
			YardsGained (Random.Range(0, 15));
			print ("Current Yardline " + this.realYardLine);
			print ("Side " + _side);
		}
		if (myState != State.TouchDown) {
			YardsGained (Random.Range(0, 15));
			print ("Current Yardline " + this.realYardLine);
			print ("Side " + _side);
		}
	}

	void SetYardLine(int yardline, Side _side){
		//convert to the program yardline in the background. 
		if (_side == Side.Left) {
			this.programYardLine = -(center - yardline);
		} else if (_side == Side.Right) {
			this.programYardLine = center - yardline;
		}

		this.realYardLine = yardline;
	}

	void YardsGained(int yards){

		if (possessionMgr.possession == Possession.Home) {
			AddYards(yards);
		} else if (possessionMgr.possession == Possession.Away) {
			AddYards(-yards);
		}



		if (isTouchDown()) {
			myState = State.TouchDown;
			print ("TOUCHDOWN BABY");
		}
	}

	bool isTouchDown(){
		if (this.programYardLine <= this.endZoneHome) {
			return true;
		} else if (this.programYardLine >= this.endZoneAway){
			return true;
		} else {
			return false;
		}
	}

	private void AddYards(int yards){

		CheckSide (this.programYardLine, yards);
		//Adjusts the yards
		this.programYardLine += yards;
		if (this.programYardLine < 0) {
			this.realYardLine = this.programYardLine + center;
		} else if (this.programYardLine > 0) {
			this.realYardLine = center - this.programYardLine;
		} else {
			this.realYardLine = center;
		}

	}

	private void CheckSide(int prevYards, int yards){

		int newYards = prevYards + yards;

		if ((prevYards <= 0) && (newYards >= 0)) {
			SwitchSides();
		} else if ((prevYards >= 0) && (newYards <= 0)){
			SwitchSides();
		}

	}

	private void SwitchSides(){
		if (this._side == Side.Left) {
			this._side = Side.Right;
		} else if (this._side == Side.Right){
			this._side = Side.Left;
		}
	}
}
