package mancala.domain;
import java.util.ArrayList;


public class MancalaImpl implements Mancala {
    
    MancalaBoard board = new MancalaBoard(14);
    ArrayList<MainBowl> boardOne = board.createBoard();
    
    // Crate the players
    Player playerOne = new Player(1);
    Player playerTwo = new Player(2);
   
    
    // Set conditions for the game
    boolean GameIsOver = false;
    boolean turnOne = true;
    boolean turnTwo = false;     
    
    
    
    public MancalaImpl() {
        playerOne.setUpBoard(boardOne);
        playerTwo.setUpBoard(boardOne);
    }

   
    public int bowl =0;
    @Override
    public boolean isPlayersTurn(int player) {
        if (player == 1){
            
            return turnOne;
        }else{
            return turnTwo;
        }
        
    }

    @Override
	public String playPit(int index, int player){
        String terug = "geslaagd";
        
        if (player == 0){
            playerOne.play(index);
            turnOne = playerOne.isTurn();
            if (turnOne== false){
                turnTwo = true;
            }
        } else {
            playerTwo.play(index);
            turnTwo = playerTwo.isTurn();
            if (turnTwo == false){
                turnOne = true;
            }
        }
        return terug;
    }
	
	@Override
	public int getStonesForPit(int index) {
        // Make a sane implementation.
        if(((index + 1) % 7) == 0) return playerOne.boardPlayer.get(index).getNumberOfRocks();
        return playerOne.boardPlayer.get(index).getNumberOfRocks();
    }

	@Override
	public boolean isEndOfGame() {
        return board.isGameOver();
    }

	@Override
	public int getWinner() {
        return Mancala.NO_PLAYERS;
    }
}