import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Wat eten wij vandaag?</h1>
            <h2>De app die de meestgestelde vraag beantwoordt</h2>

            <p>Maak jouw favoriete recepeten met de aanbiedingen van deze week.</p>
        <ul>
                <li>Vul jouw favoriete recepeten in via <Link to="/ingredients">Recipes</Link></li>
                <li>Vul aanbiedingen in via <Link to="/ingredients">Recipes</Link></li>
                <li>Vul producten die je al in huis hebt in via <Link to="/ingredients">Recipes</Link></li>
        </ul>
        </div>
    );
  }
}
