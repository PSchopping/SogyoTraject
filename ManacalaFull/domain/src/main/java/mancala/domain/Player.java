package mancala.domain;

import java.util.ArrayList;
import java.util.Scanner; 

public class Player {
	
	ArrayList<MainBowl> boardPlayer = new ArrayList<MainBowl>();
	private int player;
	private boolean turn = true;
	private int opposingKalah;
	private int kalah;
	private int firstBowl;
	Scanner sch = new Scanner(System.in);
	
	public Player(int play) {
		player = play;
		opposingKalah = 13 - (player-1)*7;
		kalah = play * 6  + (play-1);
		firstBowl = kalah-6;
	}
	
	public void setUpBoard(ArrayList<MainBowl> board) {
		
		boardPlayer = board;
		
		
	}
	public void play(String input) {
		int bowlNum =getIntInput(input);
		play(bowlNum);
	}
	
	public void play(int bowlNum) {
		
		String input;
		
		int rocksToPassAround;
		while (bowlNum<firstBowl || bowlNum>(kalah-1) || boardPlayer.get(bowlNum).getNumberOfRocks()<1 ) {
			
			System.out.println("That is not a valid bowl number, please try again: ");
			input = sch.next();
			bowlNum =getIntInput(input);
			
			
		}
		rocksToPassAround = boardPlayer.get(bowlNum).getAllRocksToPass();
		
		turn = true;
		int nextBowlIndex = boardPlayer.get(bowlNum).getNextBowl();
		
		while (rocksToPassAround > 0) {
			if (nextBowlIndex==opposingKalah) {
				nextBowlIndex=boardPlayer.get(nextBowlIndex).getNextBowl();
			}
			boardPlayer.get(nextBowlIndex).recieveRocks(1);
			
			nextBowlIndex = boardPlayer.get(nextBowlIndex).getNextBowl();
			rocksToPassAround--;

		}
		
		int currentBowl = nextBowlIndex - 1;
		
		if (boardPlayer.get(currentBowl).getNumberOfRocks()==1 && currentBowl >= firstBowl && currentBowl < kalah ) {
			
			steal(currentBowl);
		}
		
		if (currentBowl != kalah) {
			turn = false;
		}
		
		
	}
	
	public boolean isTurn() {
		return turn;
	}
	
	private void steal(int currentBowl) {
		int oppositeBowlIndex = (boardPlayer.size()-2) - currentBowl;
		int rocksStolen = boardPlayer.get(oppositeBowlIndex).getAllRocksToPass();
		int rocksToKalah = boardPlayer.get(currentBowl).getAllRocksToPass();
		rocksStolen = rocksStolen + rocksToKalah;
		boardPlayer.get(kalah).recieveRocks(rocksStolen);
	}
	
	private boolean checkInput(String input) {
		try {
		    int Value = Integer.parseInt(input);
		    return true;
		} catch (NumberFormatException e) {
		    return false;
		} 
	}
	
	private int getIntInput(String input) {
		int bowlNumb;
		if (!checkInput(input)) {
			System.out.println("That is not number, please try again: ");
			while (!sch.hasNextInt()) {
				input = sch.next();
				System.out.println("That is not number, please try again: ");
			}
			bowlNumb = sch.nextInt();
		} else {
			bowlNumb=Integer.parseInt(input);  
		}
		return bowlNumb;
	}
	
	
	
}
