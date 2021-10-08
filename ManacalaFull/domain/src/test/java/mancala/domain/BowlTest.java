package mancala.domain;
import java.util.ArrayList;


import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class BowlTest {
 // Define a test starting with @Test. The test is like
 // a small main method - you need to setup everything
 // and you can write any arbitrary Java code in it.
	
@Test 
 public void aMancalaBowlStartsWith4Rocks() {
     Bowl bowl = new Bowl();
     assertEquals(4, bowl.getNumberOfRocks());
     
 }
 
@Test 
public void aBowlKnowsNextBowl() {
    Bowl bowl = new Bowl(0);
    assertEquals(1, bowl.getNextBowl());
    
}

@Test 
 public void aBowlPassesAllItsRocks() {
	Bowl bowl = new Bowl();
	assertEquals(4,bowl.getAllRocksToPass());
	assertEquals(0, bowl.getNumberOfRocks());
	
}
 
@Test 
	public void aBowlRecievesRocks() {
		Bowl bowl = new Bowl();
		assertEquals(5, bowl.recieveRocks(1));
		
	}


@Test
	public void checkIfBowlIsEmpty() {
		Bowl bowl = new Bowl();
		bowl.getAllRocksToPass();
		assertEquals(true, bowl.bowlEmpty());
	}

@Test
	public void createKalaha() {
		Kalaha playerOneKalaha = new Kalaha();
		assertEquals(true, playerOneKalaha.bowlEmpty());
	}


@Test 
	public void createMancalaBoard() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();
		assertEquals(4,boardOne.get(1).getNumberOfRocks());
		assertEquals(0,boardOne.get(6).getNumberOfRocks());
		assertEquals(14,boardOne.size());

		
	}

@Test 
	public void createPlayers() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();
		Player playerOne = new Player(1);
		playerOne.setUpBoard(boardOne);
		Player playerTwo = new Player(2);
		playerTwo.setUpBoard(boardOne);
		assertEquals(0,playerOne.boardPlayer.get(6).getNumberOfRocks());
		assertEquals(4,playerOne.boardPlayer.get(0).getNumberOfRocks());
		assertEquals(4,playerTwo.boardPlayer.get(12).getNumberOfRocks());
		assertEquals(4,playerTwo.boardPlayer.get(0).getNumberOfRocks());
	}

@Test 
	public void playRockFromFirstBowl() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();
		Player playerOne = new Player(1);
		playerOne.setUpBoard(boardOne);
		playerOne.play(5);
		Player playerTwo = new Player(2);
		playerTwo.setUpBoard(boardOne);
		playerTwo.play(12);
		assertEquals(5,playerOne.boardPlayer.get(9).getNumberOfRocks());
		assertEquals(5,playerOne.boardPlayer.get(0).getNumberOfRocks());
	}

@Test 
	public void checkIfStillIsYourTurn() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();
		Player playerOne = new Player(1);
		playerOne.setUpBoard(boardOne);
		playerOne.play(0);
		assertEquals(false,playerOne.isTurn());
		
	}

@Test 
	public void whenRockLandsInEmptyBowlSteal() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();		
		Player playerOne = new Player(1);
		playerOne.setUpBoard(boardOne);
		playerOne.play(4);
		Player playerTwo = new Player(2);
		playerTwo.setUpBoard(boardOne);
		playerTwo.play(7);		
		playerOne.play(0);
		assertEquals(0,playerOne.boardPlayer.get(4).getNumberOfRocks());
		assertEquals(0,playerTwo.boardPlayer.get(8).getNumberOfRocks());
	}

@Test 
	public void whenRockDoesntLandInKalahaSwitchTurns() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();		
		Player playerOne = new Player(1);
		playerOne.setUpBoard(boardOne);
		playerOne.play(4);
		assertEquals(false,playerOne.isTurn());
}

@Test 
public void whenRockDoesLandInKalahaStillYourTurn() {
	MancalaBoard board = new MancalaBoard(14);
	ArrayList<MainBowl> boardOne = board.createBoard();		
	Player playerOne = new Player(1);
	playerOne.setUpBoard(boardOne);
	playerOne.play(2);
	assertEquals(true,playerOne.isTurn());
}

@Test 
	public void whenBowlsAreEmptyGameIsOver() {
		MancalaBoard board = new MancalaBoard(14);
		ArrayList<MainBowl> boardOne = board.createBoard();		
		Player playerOne = new Player(1);
		playerOne.setUpBoard(boardOne);
		Player playerTwo = new Player(2);
		playerTwo.setUpBoard(boardOne);
		playerOne.play(2);
		playerOne.play(4);
		playerTwo.play(7);		
		playerOne.play(0);
		playerTwo.play(9);		
		playerOne.play(2);
		playerTwo.play(10);		
		playerOne.play(2);
		playerTwo.play(11);		
		playerOne.play(2);
		playerTwo.play(12);		
		assertEquals(true,board.isGameOver());
}
}


