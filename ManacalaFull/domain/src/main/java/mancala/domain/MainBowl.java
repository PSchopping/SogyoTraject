package mancala.domain;

public class MainBowl {
	protected int rocks;
	protected int nextBowl;
	

	public int getNumberOfRocks() {
		return rocks;
	}
	
	
	public int recieveRocks(int rocksToGet) {
		rocks = rocks + rocksToGet;
		return rocks;
	}
	
	public boolean bowlEmpty() {
		return rocks == 0;
		
	}
	
	public int getAllRocksToPass() {
		int rocksToPass = rocks;
		makeBowlEmpty();
		return rocksToPass;
	}
	
	public void makeBowlEmpty() {
		rocks = 0;
	}
	
	public int getNextBowl() {
		return nextBowl;
	}
	
	public void setNextBowl() {
		nextBowl++;
	}
	
}

