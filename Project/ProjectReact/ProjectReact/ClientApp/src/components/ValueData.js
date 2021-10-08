import React, { Component } from 'react';

export class ValueData extends Component {
    static displayName = ValueData.name;
    

    constructor(props) {
        super(props);
        this.state = { currentValue: 0 };
    }


    render() {
        return (
            <div>
                <h1>Post API</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-primary" onClick={this.populateValueData}>Increment</button>
            </div>
        );
    }

    async populateValueData() {
        const response = await fetch('values', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ "Inr": 1 })

        });
        
    }
}
