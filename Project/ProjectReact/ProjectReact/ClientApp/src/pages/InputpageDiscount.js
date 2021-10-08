import React, { useState } from 'react';

export function InputpageDiscount() {

    const [shopName, setName] = useState("");

  
    const [products, setData] = useState([{
        name: '',
        quantity: '',
        unit: '',
        discount: ''
    }]);

    function handleChangeName(event) {
        setName(event.target.value)
    };

    function handleChange(event,index) {
        const list = [...products];
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
        setData([...products, { name: '', quantity: '', unit: '', discount: ''}]);

    }

    function handleRemoveClick(index) {
        const list = [...products];
        list.splice(index, 1);
        setData(list);
    };

    async function submitDiscount(e) {
        let nameIn = products.map(({ name }) => name)
        let unitsIn = products.map(({ unit }) => unit)
        let quanIn = products.map(({ quantity }) => Number(quantity))
        let discIn = products.map(({ discount }) => discount)

        e.preventDefault()
        alert("Toegevoegd");
        
            const response = await fetch('discountsubmit/SubmitDiscount', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': "application/json; charset=utf-8"
                },
                body: JSON.stringify({ "shopName": shopName, "name": nameIn, "quantity": quanIn, "units": unitsIn, "discount": discIn })

            });
        
    }


    return (
             
        <form >
            <input
                placeholder="Enter shop name" type="text"  onChange={handleChangeName}
            />
            
            <p>Enter your ingredient:</p>
            {products.map((x, i) => (
                <div key={i}>
                    <input
                        placeholder="Enter ingredient name" type="text" value={x.name} name="name" onChange={event => handleChange(event, i)}
                    />
                    <input
                        placeholder="Enter quantity" type="number" min="1" max="10000" value={x.quantity} name="quantity" onChange={event => handleChange(event, i)}
                    />
                    <input
                        placeholder="Enter units" type="text" value={x.unit} name="unit" onChange={event => handleChange(event, i)}
                    />
                    <input
                        placeholder="Enter discount" type="text" value={x.discount} name="discount" onChange={event => handleChange(event, i)}
                    />
                    <button onClick={event => handleRemoveClick(i)}> Remove </button>
                </div>
            ))}
            <button onClick={addInput}> Add </button>
            <button onClick={submitDiscount}> Submit </button>
        </form>
        );

}