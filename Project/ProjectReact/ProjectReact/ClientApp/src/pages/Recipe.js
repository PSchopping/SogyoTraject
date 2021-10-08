
import React, { useEffect, useState } from 'react';
import './SearchRecipes.css';
import useSortableData from "../Custom hooks/useSortableData.js";
import Emoji from "../components/Emoji.js";
import './StyleSheet.css'
import { useHistory } from "react-router-dom";
import { useLocation } from "react-router-dom";

const Recipe = props => {
    const location = useLocation();
    const [recipes: [], setRecipes] = useState([]);

   let recipe = location.state;


    useEffect(() => {
        getRecipesName()
    }, [recipes.length]);

    async function getRecipesName(e) {
        




        const response = await fetch('recipesearch/GetOverviewRecipes/' + recipe);
        const data = await response.json();
        setRecipes(data);
        console.log(recipes[0]);
    };

    
    if (recipes.length < 1) {
        return (
            <div className="loader-container">
                <div className="loader"></div>
            </div>
        );
    } else {
        return (
            <form>
                <h1>{recipes[0].receptName}</h1>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Ingredient</th>
                            <th>Quantity</th>
                            <th>Unit</th>
                        </tr>
                    </thead>
                    <tbody>
                        {recipes.map((recipe, i) => (
                            <tr key={i}>
                                <td >{recipe.name}</td>
                                <td>{recipe.quantity}</td>
                                <td>{recipe.units}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </form>
        );
    }
};

export default Recipe;