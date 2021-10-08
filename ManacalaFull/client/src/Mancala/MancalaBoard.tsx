import React from "react";
import "./MancalaBoard.css";
import type { GameState } from "../gameState";

type MancalaBoard= {
    gameState: GameState;
    setGameState(newGameState: GameState): void;
}



export function MancalaBoard({ gameState, setGameState }: MancalaBoard){
    
    console.log(gameState.players[0].hasTurn)
    console.log(gameState.players[1].hasTurn)
    
    async function clickHandler(index : number ,playerNum : number, turn : boolean){
        
        if (playerNum == 1){
            var bowlfill = gameState.players[1].pits[index-7].nrOfStones;
        }else {
        var bowlfill = gameState.players[0].pits[index].nrOfStones;
        }

     
        if(!turn){
            alert("Not your turn");
        }else{
            if (bowlfill<1){
                alert("No rocks to pass");
            }else{ 
            try {
                const response = await fetch('mancala/api/playmove', {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({index: index, player : playerNum})
                });
            
                if (response.ok) {
                    const gameState = await response.json();
                    setGameState(gameState);
                } else {
                    console.error(response.statusText);
                }
            } catch (error) {
                console.error(error.toString());
            }
        }
        }
       if(gameState.gameStatus.endOfGame){
           alert("There is a winner");
       }
    }
    
            
    return (    
        
        <div className="board">
            <div className="section endsection">
                 <div className="pot" id="mb">{gameState.players[1].pits[6].nrOfStones}</div> 
            </div>
            <div className="section midsection">
                <div className="midrow topmid">
                    <div className="pot" id="pt25" onClick={() => clickHandler(12,1,gameState.players[1].hasTurn)}>{gameState.players[1].pits[5].nrOfStones}</div>
                    <div className="pot" id="pt24" onClick={() => clickHandler(11,1,gameState.players[1].hasTurn)}>{gameState.players[1].pits[4].nrOfStones}</div>
                    <div className="pot" id="pt23" onClick={() => clickHandler(10,1,gameState.players[1].hasTurn)}>{gameState.players[1].pits[3].nrOfStones}</div>
                    <div className="pot" id="pt22" onClick={() => clickHandler(9,1,gameState.players[1].hasTurn)}>{gameState.players[1].pits[2].nrOfStones}</div>
                    <div className="pot" id="pt21" onClick={() => clickHandler(8,1,gameState.players[1].hasTurn)}>{gameState.players[1].pits[1].nrOfStones}</div>
                    <div className="pot" id="pt21" onClick={() => clickHandler(7,1,gameState.players[1].hasTurn)}>{gameState.players[1].pits[0].nrOfStones}</div>
                </div>
                <div className="midrow botmid">
                    <div className="pot" id="pt11" onClick={() => clickHandler(0,0,gameState.players[0].hasTurn)}>{gameState.players[0].pits[0].nrOfStones}</div>
                    <div className="pot" id="pt12" onClick={() => clickHandler(1,0,gameState.players[0].hasTurn)}>{gameState.players[0].pits[1].nrOfStones}</div>
                    <div className="pot" id="pt13" onClick={() => clickHandler(2,0,gameState.players[0].hasTurn)}>{gameState.players[0].pits[2].nrOfStones}</div>
                    <div className="pot" id="pt14" onClick={() => clickHandler(3,0,gameState.players[0].hasTurn)}>{gameState.players[0].pits[3].nrOfStones}</div>
                    <div className="pot" id="pt15" onClick={() => clickHandler(4,0,gameState.players[0].hasTurn)}>{gameState.players[0].pits[4].nrOfStones}</div>
                    <div className="pot" id="pt16" onClick={() => clickHandler(5,0,gameState.players[0].hasTurn)}>{gameState.players[0].pits[5].nrOfStones}</div>
                </div>
            </div>
             <div className="section endsection">
                 <div className="pot" id="mt">{gameState.players[0].pits[6].nrOfStones}</div>        
             </div>
        </div>
    )
}
/*
function PitBoard(any){
    const id = index;
    return (
    <div className="pot" id={id}>{gameState.players[0].pits[6].nrOfStones}</div>
    )
}
*/




