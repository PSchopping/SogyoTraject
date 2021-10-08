package mancala.domain;

public class Kalaha extends Bowl {
	
	public Kalaha() {
		rocks = 0;
	}
	
	public Kalaha(int index) {
		rocks = 0;
		
		if (index>12) {
			nextBowl=0;
		}
		else {
			nextBowl = ++index;
		}
	}
	
	public int getAllRocksToPass() {
		int rocksToPass = 0;
		return rocksToPass;
	}
}
