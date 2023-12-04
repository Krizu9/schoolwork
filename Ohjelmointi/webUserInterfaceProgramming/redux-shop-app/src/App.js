import React, { useEffect } from 'react';
import './App.css';
import axios from 'axios';
import { useDispatch, useSelector } from 'react-redux';
import { addProduct } from './store/slice.js';
import { addItemToCart, removeItemFromCart } from './store/cardSlice.js'



function App() {

  function ProductList() {

    const dispatch = useDispatch();
    const products = useSelector(state => state.products);

    useEffect(() => {
      axios.get('https://fakestoreapi.com/products')
        .then(response => {
          const products = response.data;
          products.forEach(product => {
            dispatch(addProduct(product));
          });
        });
    }, []);

    const addProductToCart = (product) => {
      dispatch(addItemToCart(product));
    }


    return (
      <div className="productContainer">
        {products.map(product => (
          <div className="productCard">
            <button onClick={() => addProductToCart(product)} className="button">Buy</button>
            <div key={product.id} className="product">
              <h3>{product.title}</h3>
              <p>{product.description}</p>
              <p>{product.price}</p>
              <img className="image" src={product.image} alt={product.title} />
            </div>
          </div>
        ))}
      </div>
    );
  }

  function ShoppingCart() {
    const cartItems = useSelector(state => state.cart);
    const dispatch = useDispatch();

    const totalPrice = cartItems.reduce((total, item) => total + item.price, 0).toFixed(2);

    const removeProductToCart = (item) => {
      dispatch(removeItemFromCart(item));
    }

    return (
      <div className="shoppingCart">
        <h1>Shopping cart</h1>
        <h1>Click to remove item</h1>
        <ul>
          {cartItems.map(item => (
            <li onClick={() => removeProductToCart(item)} key={item.id}>
              {item.title} - {item.quantity}x {item.price}€
            </li>
          ))}
          <div className="total">Total Price: {totalPrice}€</div>
        </ul>
      </div>
    );
  }

  return (
    <div className="App">
      <h1>Redux-Shop</h1>
      <div className="content">
        <ProductList />
        <ShoppingCart />
      </div>
    </div>
  );
}

export default App;
