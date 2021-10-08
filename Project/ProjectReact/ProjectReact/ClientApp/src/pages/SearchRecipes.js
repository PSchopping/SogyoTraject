import React, { useState, useEffect } from 'react';
import './SearchRecipes.css'
import { useHistory } from "react-router-dom";


export function SearchRecipes() {

    const [recipes: [], setRecipes] = useState([]);
    const [averagediscount: [], setAverage] = useState([]);
    const [percentages: [], setPercentage] = useState([]);
    const[percentagesInhouse: [], setPercentageInhouse] = useState([]);
    let history = useHistory();
    
    useEffect(() => {
        getSummary()
    },[percentages.length]);

    
    async function getRecipes(e) {
        e.preventDefault()
        

        const response = await fetch('recipesearch/GetRecipes');
        const data = await response.json();
            setRecipes(data);
    };
    
    async function getRecipesName(e) {
        e.preventDefault()
        console.log(e.target.innerText)
        history.push({
            pathname: '/recipediscount',
            state: e.target.innerText
        });
    };

  
        async function getAverage() {

        

        const response = await fetch('recipesearch/GetAverageDiscount');
        const data = await response.json();
        setAverage(data);
    };

    async function getSummary(e) {
        

        getPercentages();
        getAverage();
        getInhousePercentages();

    };


    async function getPercentages() {



        const response = await fetch('recipesearch/GetPercentageIngredients');
        const data = await response.json();
        setPercentage(data);
    };

    async function getInhousePercentages() {



        const response = await fetch('recipesearch/GetPercentageIngredientsInhouse');
        const data = await response.json();
        console.log("Deze dingen =")
        console.log(data)
        setPercentageInhouse(data);
    };

    if (percentages.length < 1 || percentagesInhouse.length < 1  ) {
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
                                <th>Recipe</th>
                                <th>Average discount (%)</th>
                                <th>Number of ingredients</th>
                                <th>Number of ingredients in discount </th>
                                <th>Number of ingredients in discount (% of total)</th>
                                <th>Number of products inhouse (% of total)</th>
                            </tr>
                        </thead>
                        <tbody>
                            {averagediscount.map((aver, i) => (
                                <tr key={i}>
                                    <td onClick={getRecipesName}>{aver.recipeName}</td>
                                    <td>{aver.averagePriceOff}</td>
                                    <td>{percentages[(percentages.map(perc => perc.recipeName).indexOf(aver.recipeName))].total}</td>
                                    <td>{aver.numberDiscount}</td>
                                    <td>{percentages[(percentages.map(perc => perc.recipeName).indexOf(aver.recipeName))].percentage}</td>
                                    {(percentagesInhouse.map(perc => perc.recipeName).indexOf(aver.recipeName)) > -1 &&
                                        <td>{percentagesInhouse[(percentagesInhouse.map(perc => perc.recipeName).indexOf(aver.recipeName))].percentage}</td>
                                    }
                                    {(percentagesInhouse.map(perc => perc.recipeName).indexOf(aver.recipeName)) < 0 &&
                                        <td>0</td>
                                    }
                                </tr>
                            ))}
                        </tbody>
                    </table>

                </div>

                
            </form>
        );
    }

}