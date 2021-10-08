package mancala.domain;
import java.util.ArrayList;
import java.util.Scanner; 

public class MancalaBoard {

	ArrayList<MainBowl> board = new ArrayList<MainBowl>();
	int kalahOne;
	int kalahTwo;
	Scanner sch = new Scanner(System.in);
	int size;
	
	public MancalaBoard(int input) {
		size = input;
		kalahOne = (size/2)-1;
		kalahTwo = size-1;
		for (int i = 0; i< size; i++) {
			if (i == kalahOne || i==kalahTwo) {
				board.add(new Kalaha(i));
			} else {
			board.add(new Bowl(i));
			}
		}

	}
	
	public MancalaBoard() {
		this(14);
		
	}
	
	public MancalaBoard(String input) {
		try {
			size = Integer.parseInt(input);
		}
		catch (Exception e) {
			size = 14;
			System.out.println("Unreadable value, size is set to 14");
		}
		kalahOne = (size/2)-1;
		kalahTwo = size-1;
		for (int i = 0; i< size; i++) {
			if (i == kalahOne || i==kalahTwo) {
				board.add(new Kalaha(i));
			} else {
			board.add(new Bowl(i));
			}
		}
		
		
	}
	
		
		
	public ArrayList<MainBowl> createBoard(){
		return board;
	}
	
	public boolean isGameOver() {
		boolean gameOverOne = true;
		boolean gameOverTwo = true;
		
		// Check player one side of board
		for (int u = 0; u < kalahOne; u++) {
			if (!board.get(u).bowlEmpty()) {
				gameOverOne = false;
			}
		}
		// Check player two side of board
		for (int v = kalahOne+1; v < kalahTwo; v++) {
			if (!board.get(v).bowlEmpty()) {
				gameOverTwo = false;
			}
		}
		
		if (gameOverOne == true || gameOverTwo == true) {
			return true;
		} else {
			return false;
		}
		
	}

	public void showBoard() {

		System.out.print("   ");
		for (int o =kalahTwo-1; o>kalahOne; o--) {
			System.out.print("("+board.get(o).getNumberOfRocks()+")");
		}
		System.out.println();
		System.out.print("["+ board.get(kalahTwo).getNumberOfRocks() +"]");
		
		for (int o =kalahTwo-1; o>kalahOne; o--) {
			System.out.print("---");
		}
		System.out.println("["+ board.get(kalahOne).getNumberOfRocks() +"]" );
		
		System.out.print("   ");
		for (int t =0; t<kalahOne; t++) {
			System.out.print("("+board.get(t).getNumberOfRocks()+")");
		}
		System.out.println();
	}
	
	public void clearBoard() {
		// Clear board side player one
		for (int r = 0; r< kalahOne;r++) {
			board.get(kalahOne).recieveRocks(board.get(r).getAllRocksToPass());
		}
		// Clear board side player two
		for (int r = kalahOne+1; r< kalahTwo;r++) {
			board.get(kalahTwo).recieveRocks(board.get(r).getAllRocksToPass());
		}
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
		int sizeBoard;
		if (!checkInput(input)) {
			System.out.println("That is not number, please try again: ");
			while (!sch.hasNextInt()) {
				input = sch.next();
				System.out.println("That is not number, please try again: ");
			}
			sizeBoard = sch.nextInt();
		} else {
			sizeBoard=Integer.parseInt(input);  
		}
		return sizeBoard;
	}
	
}
