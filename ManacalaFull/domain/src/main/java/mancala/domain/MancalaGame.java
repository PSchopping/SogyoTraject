package mancala.domain;

import java.util.ArrayList;
import java.util.Scanner;

	public class MancalaGame {
		
		public void playGame() {
			Scanner sc = new Scanner(System.in);
			
			// Create the board
			System.out.print("What is the size of the board? : ");
			MancalaBoard board = new MancalaBoard(sc.next());
			ArrayList<MainBowl> boardOne = board.createBoard();
			board.showBoard();
			
			// Crate the players
			Player playerOne = new Player(1);
			playerOne.setUpBoard(boardOne);
			Player playerTwo = new Player(2);
			playerTwo.setUpBoard(boardOne);
			
			// Set conditions for the game
			boolean GameIsOver = false;
			boolean turn = true;
			
			// Play game
			while (GameIsOver != true ) {
				while (turn) {
					System.out.print("Player 1, which bowl to play? : ");
					playerOne.play(sc.next());
					turn = playerOne.isTurn();
					GameIsOver = board.isGameOver();
					board.showBoard();
				}
				
				turn = true;
				while (turn) {
					System.out.print("Player 2, which bowl to play? : ");
					playerTwo.play(sc.next());
					turn = playerTwo.isTurn();
					GameIsOver = board.isGameOver();
					board.showBoard();
				}
				turn = true;
				
				
			}
			sc.close();
			board.clearBoard();
			board.showBoard();

		}
}
