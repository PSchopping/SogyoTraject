import React from "react";
import type { GameState } from "../gameState";
import "./Play.css";
import { MancalaBoard } from "./MancalaBoard";

type PlayProps = {
    gameState: GameState;
    setGameState(newGameState: GameState): void;
}

export function Play({ gameState, setGameState }: PlayProps) {
    return (
        <div>
            <p>{gameState.players[0].name} vs {gameState.players[1].name}</p>
            <MancalaBoard gameState = {gameState} setGameState={setGameState} />
            
           
        </div>
    )
}
