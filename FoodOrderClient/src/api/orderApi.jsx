import axios from 'axios';

const API_BASE_URL = 'https://localhost:7274/api/order';

export const getOrders = () => axios.get(API_BASE_URL);
export const getOrder = (id) => axios.get(`${API_BASE_URL}/${id}`);
export const addOrder = (order) => axios.post(API_BASE_URL, order);
export const updateOrder = (id, order) => axios.put(`${API_BASE_URL}/${id}`, order);
export const deleteOrder = (id) => axios.delete(`${API_BASE_URL}?orderid=${id}`);
