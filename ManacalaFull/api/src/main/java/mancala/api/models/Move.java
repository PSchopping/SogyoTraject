package mancala.api.models;

public class Move {

	//tring nameplayer1;
	//String nameplayer2;
    //mancala.domain.Mancala mancala;
	
    int index;
	int player;
	/*
	public String getNameplayer1() {
		return nameplayer1;
	}

	public void setNameplayer1(String nameplayer1) {
		this.nameplayer1 = nameplayer1;
	}

	public String getNameplayer2() {
		return nameplayer2;
	}

	public void setNameplayer2(String nameplayer2) {
		this.nameplayer2 = nameplayer2;
	}
    */
    public void setPlayer(int playerNum){
        this.player = playerNum;
    }
	
    public void setIndex(int indexPlay){
        this.index = indexPlay;
    }
	
    public int getPlayer() {
		return player;
	}
	
    public int getIndex(){
        return index;
    }




}