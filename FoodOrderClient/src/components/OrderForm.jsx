import React, { useState, useEffect } from 'react';
import './OrderForm.css';
import { addOrder, updateOrder, getOrder } from '../api/orderApi';

const OrderForm = ({ selectedOrderId, onSuccess }) => {
    const [order, setOrder] = useState({
        customerName: '',
        customerAddress: '',
        customerPhone: '',
        customerEmail: '',
        quantity: 0,
    });

    const [message, setMessage] = useState('');

    useEffect(() => {
        if (selectedOrderId) {
            getOrder(selectedOrderId)
                .then(res => {
                    // Map only the editable fields from fetched order
                    const fetched = res.data;
                    setOrder({
                        customerName: fetched.customerName || '',
                        customerAddress: fetched.customerAddress || '',
                        customerPhone: fetched.customerPhone || '',
                        customerEmail: fetched.customerEmail || '',
                        quantity: fetched.quantity || 0,
                    });
                })
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
                quantity: 1,
            });

            onSuccess();
            setTimeout(() => setMessage(''), 3000);
        } catch (error) {
            console.error('Submit failed:', error.response?.data || error.message);
            setMessage('Failed to submit order');
        }
    };

    return (
        <form className="order-form" onSubmit={handleSubmit}>
            <h3>{selectedOrderId ? 'Edit Order' : 'New Order'}</h3>
            {message && <p className="success-msg">{message}</p>}

            <input
                name="customerName"
                value={order.customerName}
                onChange={handleChange}
                placeholder="Customer Name"
                required
            />
            <input
                name="customerAddress"
                value={order.customerAddress}
                onChange={handleChange}
                placeholder="Customer Address"
            />
            <input
                name="customerPhone"
                value={order.customerPhone}
                onChange={handleChange}
                placeholder="Customer Phone"
            />
            <input
                name="customerEmail"
                type="email"
                value={order.customerEmail}
                onChange={handleChange}
                placeholder="Customer Email"
            />
            <input
                type="number"
                name="quantity"
                value={order.quantity}
                onChange={handleChange}
                min={1}
                required
            />

            <button type="submit">Save Order</button>
        </form>
    );
};

export default OrderForm;
