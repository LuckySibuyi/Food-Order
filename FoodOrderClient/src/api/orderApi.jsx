import axios from 'axios';

// Base API URL
const API_BASE_URL = 'https://localhost:7274/api/order';

// Axios instance for clean, consistent requests
const axiosInstance = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

// CRUD API functions
export const getOrders = () => axiosInstance.get('/');
export const getOrder = (id) => axiosInstance.get(`/${id}`);
export const addOrder = (order) => axiosInstance.post('/', order);
export const updateOrder = (id, order) => axiosInstance.put(`/${id}`, order);
export const deleteOrder = (id) => axiosInstance.delete(`/${id}`);
