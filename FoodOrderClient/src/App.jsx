import React from 'react';
import OrderList from './components/OrderList';
import './App.css';

const App = () => {
    return (
        <div className="app-container">
            <h1 className="app-title">Food Order Management</h1>
            <OrderList />
        </div>
    );
};

export default App;
