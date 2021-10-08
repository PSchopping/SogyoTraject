
import React, { useEffect, useState } from 'react';
import './SearchRecipes.css';
import useSortableData from "../Custom hooks/useSortableData.js";
import Emoji from "../components/Emoji.js";
import './StyleSheet.css'
import { useHistory } from "react-router-dom";
import { useLocation } from "react-router-dom";

const RecipeDiscount = props => {
    const location = useLocation();
    const [recipes: [], setRecipes] = useState([]);

   let recipe = location.state;


    useEffect(() => {
        getRecipesName()
    }, [recipes.length]);

    async function getRecipesName(e) {
        




        const response = await fetch('recipesearch/GetRecipes/' + recipe);
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
                            <th>Shop</th>
                            <th>Ingredient</th>
                            <th>Quantity</th>
                            <th>Unit</th>
                            <th>Discount</th>
                            <th>Amount to buy</th>
                        </tr>
                    </thead>
                    <tbody>
                        {recipes.map((recipe, i) => (
                            <tr key={i}>
                                <td >{recipe.shopName}</td>
                                <td >{recipe.name}</td>
                                <td>{recipe.quantity}</td>
                                <td>{recipe.units}</td>
                                <td>{recipe.discount}</td>
                                <td>{recipe.toBuy}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </form>
        );
    }
};

export default RecipeDiscount;