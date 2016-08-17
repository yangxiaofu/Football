using UnityEngine;
using System.Collections;


public enum Possession {
	Home, Away
}

public class PossessionManager {

	public Possession possession;
	
	void Start(){
		possession = Possession.Away;
	}


	public void SetPossession(string pos){
		if (pos == "Away") {
			possession = Possession.Away;
		} else {
			possession = Possession.Home;
		}
	}

	public void SetPossession(Possession pos){
		if (pos == Possession.Away) {
			this.SetPossession ("Away");
		} else {
			this.SetPossession ("Home");
		}

	}
	
	public void ChangePossession(){
		if (possession == Possession.Away) {

			possession = Possession.Home;

		} else if (possession == Possession.Home) {

			possession = Possession.Away;

		}
	}
}
