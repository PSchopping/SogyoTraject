
import React, { useEffect, useState } from 'react';
import './SearchRecipes.css';
import useSortableData from "../Custom hooks/useSortableData.js";
import Emoji from "../components/Emoji.js";
import './StyleSheet.css'
import { useHistory } from "react-router-dom";

export function RecipesOverview() {

    const [recipes: [], setRecipes] = useState([]);
    const { items, requestSort, sortConfig } = useSortableData(recipes);

    const getClassNamesFor = (row) => {
        if (!sortConfig) {
            return;
        }
        return sortConfig.key === row ? sortConfig.direction : undefined;
    };

    

    
    useEffect(() => {
        getRecipes()
    },[recipes.length]);

    
    async function getRecipes() {
        
        

        const response = await fetch('recipesearch/GetOverviewRecipes');
        const data = await response.json();
            setRecipes(data);
    };

    let history = useHistory();

    async function getRecipesName(e) {
        e.preventDefault()
        
        history.push({
            pathname: '/recipe',
            state: e.target.innerText
        });
                
    };

    async function remove(index,e) {
        e.preventDefault()
        const remove = recipes[index]
        const response = await fetch('ingredientsubmit/DeleteIngredients', {
            method: 'POST',
            headers: {
                'Accept': "application/json; charset=utf-8",
                'Content-Type': "application/json; charset=utf-8"
            },
            body: JSON.stringify({ "ingredientID":remove.id, "receptName": remove.receptName, "name": remove.name, "quantity": remove.quantity, "units": remove.units })

        });

        
        const list = [...recipes];
        list.splice(index, 1);
        setRecipes(list);
    };
    
 

    if (recipes.length < 1) {
        return (
            <div className="loader-container">
                <div className="loader"></div>
            </div>
        );
    } else {
        return (

            <form >
                <div>
                    <table className='table table-striped' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>
                                    <button type="button"
                                        onClick={() => requestSort('receptName')}
                                        className={getClassNamesFor('receptName')}>
                                        <Emoji symbol="↕️" label="arrow" />
                                        
                                    </button>
                                    Recipe
                                </th>
                                <th>
                                    <button type="button"
                                        onClick={() => requestSort('name')}
                                        className={getClassNamesFor('name')}>
                                        <Emoji symbol="↕️" label="arrow" />
                                        
                                    </button>
                                    Ingredient
                                        </th>
                                <th>Quantity</th>
                                <th>Units</th>
                                <th>Remove ingredient</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            {items.map((recipe, i) => (
                                <tr key={i}>
                                    <td onClick={getRecipesName}>{recipe.receptName}</td>
                                    <td>{recipe.name}</td>
                                    <td>{recipe.quantity}</td>
                                    <td>{recipe.units}</td>
                                    <td><button onClick={event => remove(i,event)}> Remove </button></td>
                                </tr>
                            ))}
                        </tbody>
                    </table>

                </div>

            </form>
        );
    }

}