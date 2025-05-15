import React, { useState, useEffect } from 'react';
import './OrderForm.css';
import { addOrder, updateOrder, getOrder } from '../api/orderApi';

const OrderForm = ({ selectedOrderId, onSuccess }) => {
    const [order, setOrder] = useState({
        customerName: '',
        customerAddress: '',
        customerPhone: '',
        customerEmail: '',
        orderStatus: '',
        orderDate: '',
        deliveryDate: '',
        deliveryTime: '',
        quantity: 1,
    });

    const [message, setMessage] = useState('');

    useEffect(() => {
        if (selectedOrderId) {
            getOrder(selectedOrderId)
                .then(res => setOrder(res.data))
                .catch(err => console.error('Fetch order failed:', err));
        }
    }, [selectedOrderId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setOrder(prev => ({ ...prev, [name]: value }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (selectedOrderId) {
                await updateOrder(selectedOrderId, order);
                setMessage('Order updated successfully');
            } else {
                await addOrder(order);
                setMessage('Order added successfully');
            }

            setOrder({
                customerName: '',
                customerAddress: '',
                customerPhone: '',
                customerEmail: '',
                orderStatus: '',
                orderDate: '',
                deliveryDate: '',
                deliveryTime: '',
                quantity: 1,
            });

            onSuccess();
            setTimeout(() => setMessage(''), 3000);
        } catch (error) {
            console.error('Submit failed:', error);
            setMessage('Failed to submit order');
        }
    };

    return (
        <form className="order-form" onSubmit={handleSubmit}>
            <h3>{selectedOrderId ? 'Edit Order' : 'New Order'}</h3>
            {message && <p className="success-msg">{message}</p>}

            <input name="customerName" value={order.customerName} onChange={handleChange} placeholder="Customer Name" required />
            <input name="customerAddress" value={order.customerAddress} onChange={handleChange} placeholder="Customer Address" />
            <input name="customerPhone" value={order.customerPhone} onChange={handleChange} placeholder="Customer Phone" />
            <input name="customerEmail" type="email" value={order.customerEmail} onChange={handleChange} placeholder="Customer Email" />
            <input name="orderStatus" value={order.orderStatus} onChange={handleChange} placeholder="Order Status" />
            <input type="date" name="orderDate" value={order.orderDate} onChange={handleChange} />
            <input type="date" name="deliveryDate" value={order.deliveryDate} onChange={handleChange} />
            <input type="datetime-local" name="deliveryTime" value={order.deliveryTime} onChange={handleChange} />
            <input type="number" name="quantity" value={order.quantity} onChange={handleChange} required />

            <button type="submit">Save Order</button>
        </form>
    );
};

export default OrderForm;
