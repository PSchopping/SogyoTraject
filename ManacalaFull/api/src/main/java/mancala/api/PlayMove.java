package mancala.api;

import java.io.IOException;
import jakarta.servlet.http.*;
import jakarta.servlet.ServletException;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.*;

import mancala.api.models.*;
import mancala.domain.MancalaImpl;

@Path("/playmove")
public class PlayMove {
    @POST
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response initialize(
        @Context HttpServletRequest request,
			Move move) {
        
        //String namePlayer1 = move.getNameplayer1();
		//String namePlayer2 = move.getNameplayer2();
        int index = move.getIndex();
        int player = move.getPlayer();
        
		
        HttpSession session = request.getSession(false);
        mancala.domain.Mancala mancala = (mancala.domain.Mancala)session.getAttribute("mancala");
        String namePlayer1 = (String)session.getAttribute("player1");
		String namePlayer2 = (String)session.getAttribute("player2");
        

        
        
    
        String responsePlay = mancala.playPit(index,player);
        session.setAttribute("text", responsePlay);        
        System.out.println("hoi");
		var output = new Mancala(mancala, namePlayer1, namePlayer2);
		return Response.status(200).entity(output).build();
	}
}
