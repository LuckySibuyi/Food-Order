import React, { useEffect, useState } from 'react';
import { getOrders, deleteOrder } from '../api/orderApi';
import OrderForm from './OrderForm';

const OrderList = () => {
    const [orders, setOrders] = useState([]);
    const [selectedOrderId, setSelectedOrderId] = useState(null);
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);

    const fetchOrders = () => {
        setLoading(true);
        setError('');
        getOrders()
            .then(res => {
                console.log('? Orders fetched:', res.data);
                setOrders(res.data);
            })
            .catch(err => {
                console.error('? Failed to fetch orders:', err);
                if (err.response) {
                    console.error('Status:', err.response.status);
                    console.error('Data:', err.response.data);
                } else if (err.request) {
                    console.error('No response received:', err.request);
                } else {
                    console.error('Error message:', err.message);
                }
                setError('Failed to load orders');
            })
            .finally(() => setLoading(false));
    };

    const handleDelete = (id) => {
        if (window.confirm('Delete this order?')) {
            deleteOrder(id)
                .then(() => {
                    console.log(`? Order ${id} deleted`);
                    fetchOrders();
                })
                .catch(err => {
                    console.error(`? Failed to delete order ${id}:`, err);
                    setError('Failed to delete');
                });
        }
    };

    useEffect(() => {
        fetchOrders();
    }, []);

    return (
        <div style={{ maxWidth: '600px', margin: '0 auto', textAlign: 'left' }}>
            <h2 style={{ textAlign: 'center' }}>Orders</h2>

            <OrderForm selectedOrderId={selectedOrderId} onSuccess={fetchOrders} />

            {loading && <p>Loading...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}

            <ul style={{ listStyle: 'none', padding: 0 }}>
                {orders.map(order => (
                    <li key={order.orderId} style={{
                        border: '1px solid #ccc',
                        padding: '10px',
                        marginBottom: '10px',
                        borderRadius: '6px',
                        backgroundColor: '#f8f8f8'
                    }}>
                        <strong>{order.customerName}</strong> - {order.orderStatus}
                        <br />
                        <button onClick={() => setSelectedOrderId(order.orderId)} style={{ marginRight: '10px' }}>
                            Edit
                        </button>
                        <button onClick={() => handleDelete(order.orderId)}>
                            Delete
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default OrderList;
