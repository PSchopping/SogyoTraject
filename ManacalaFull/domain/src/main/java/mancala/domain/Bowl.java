package mancala.domain;

public class Bowl extends MainBowl {
	
	public Bowl() {
		rocks = 4;
	}
	
	public Bowl(int index) {
		rocks = 4;
		nextBowl = ++index;
	}	
	
}
