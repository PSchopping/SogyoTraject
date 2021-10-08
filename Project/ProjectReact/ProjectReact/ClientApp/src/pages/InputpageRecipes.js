import React, { useState } from 'react';

export function InputpageRecipes() {

    const [recipeName, setName] = useState("");
    

  
    const [recipe, setData] = useState([{
        name: '',
        quantity: '',
        unit: ''
    }]);

    function handleChangeName(event) {
        setName(event.target.value)
    };

    function handleChange(event,index) {
        const list = [...recipe];
        const { name, value } = event.target;
        if (value < 1) {
            list[index][name] = 1;
        } else if (value > 10000) {
            list[index][name] = 10000;
        } else {
            list[index][name] = value;
        }
        
        setData(list);
    }

    function addInput(e) {
        e.preventDefault()
        setData([...recipe, { name: '', quantity: '', unit: '' }]);

    }

    function handleRemoveClick(index) {
        const list = [...recipe];
        list.splice(index, 1);
        setData(list);
    };

    async function submitIngredient(e) {
        let nameIn = recipe.map(({ name }) => name)
        let unitsIn = recipe.map(({ unit }) => unit)
        let quanIn = recipe.map(({ quantity }) => Number(quantity))
        
        e.preventDefault()
        alert("Toegevoegd");
        
            const response = await fetch('ingredientsubmit/SubmitIngredients', {
                method: 'POST',
                headers: {
                    'Accept': "application/json; charset=utf-8",
                    'Content-Type': "application/json; charset=utf-8"
                },
                body: JSON.stringify({ "receptName": recipeName, "name": nameIn, "quantity": quanIn, "units": unitsIn })

            });
        window.location.reload();
    }


    return (
             
        <form >
            <input
                placeholder="Enter recipe name" type="text" onChange={handleChangeName}
            />
            <p>Enter your ingredient:</p>
            {recipe.map((x, i) => (
                <div key={i}>
                    
                    <input
                        placeholder="Enter ingredient name" type="text" value={x.name} name="name" onChange={event =>handleChange(event,i)}
                    />
                    <input
                        placeholder="Enter quantity" type="number" value={x.quantity} name="quantity" min="1" onChange={event => handleChange(event, i)}
                    />
                    <input
                        placeholder="Enter units" type="text" value={x.unit} name="unit" onChange={event => handleChange(event, i)}
                    />
                    <button onClick={event => handleRemoveClick(i)}> Remove </button>
                </div>
             ))}
            <button onClick={addInput}> Add </button>
            <button onClick={submitIngredient}> Submit </button>
        </form>
        );

}