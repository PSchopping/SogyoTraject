import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ValueData } from './components/ValueData';
import { InputpageRecipes } from './pages/InputpageRecipes';
import { InputpageDiscount } from './pages/InputpageDiscount';
import './custom.css'
import { SearchRecipes } from './pages/SearchRecipes';
import { RecipesOverview } from './pages/RecipesOverview';
import { InhouseProducts } from './pages/InhouseProducts';
import Recipe from './pages/Recipe';
import RecipeDiscount from './pages/RecipeDiscount';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path ='/ingredients'>
                <InputpageRecipes/>
            </Route>
            <Route path='/discounts'>
                <InputpageDiscount />
            </Route>
            <Route path='/search'>
                <SearchRecipes />
            </Route>
            <Route path='/test'>
                <FetchData />
            </Route>
            <Route path='/overviewrecipes'>
                <RecipesOverview />
            </Route>
            <Route path='/inhouseproducts'>
                <InhouseProducts />
            </Route>
            <Route path='/recipe'>
                <Recipe />
            </Route>
            <Route path='/recipediscount'>
                <RecipeDiscount />
            </Route>
      </Layout>
    );
  }
}
